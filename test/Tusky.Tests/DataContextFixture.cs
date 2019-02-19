using System;
using System.IO;
using System.Reflection;
using Tusky.Config;
using Tusky.Criterion;
using Tusky.Types;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using Npgsql;
using Xunit;

namespace Tusky.Tests
{
    public class DataContextFixture : IDisposable
    {
        protected IConfigurationRoot Configuration { get; set; }
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;
        private readonly string _assemblyName = "Tusky.Tests"; 
        private readonly string _connectionString;
        private readonly string _databaseName;

        public DataContextFixture()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            _connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            var connectionStringBuilder = new NpgsqlConnectionStringBuilder(_connectionString);
            connectionStringBuilder.TryGetValue("Database", out var databaseNameValue);

            _databaseName = databaseNameValue as string;
            if (string.IsNullOrEmpty(_databaseName))
            {
                throw new ArgumentException("Invalid database name", "Database");
            }

            CreateDatabase();
            ExecuteSchema();

            _configuration = new Configuration();
            _configuration.SetProperty("connection.connection_string", _connectionString);
            _configuration.SetProperty("connection.driver_class", typeof(TuskyDriver).AssemblyQualifiedName);
            _configuration.SetProperty("dialect", typeof(PostgreSQLDialect).AssemblyQualifiedName);

            var mappings = _configuration.GetMappings();
            mappings.AddDefaultArrayTypes();
            mappings.AddDefaultListTypeDefs();
            mappings.AddDefaultRangeTypeDefs();
            mappings.AddDefaultNetworkTypes();
            mappings.AddNodaTimeTypeDefs();
            mappings.AddNodaTimeRangeTypeDefs();

            TypeUtil.RegisterDefaultArrayTypes(2);
            TypeUtil.RegisterDefaultListTypes();
            TypeUtil.RegisterDefaultRangeTypes();
            TypeUtil.RegisterNodaTimeTypes();
            TypeUtil.RegisterNodaTimeRangeTypes();

            ArrayProjections.RegisterHooks();
            ArrayRestrictions.RegisterHooks();
            ListProjections.RegisterHooks();
            ListRestrictions.RegisterHooks();
            RangeProjections.RegisterHooks();
            RangeRestrictions.RegisterHooks();

            _configuration.AddAssembly(_assemblyName);

            BuildSessionFactory();

            NpgsqlConnection.GlobalTypeMapper.UseNodaTime();
        }

        public void Dispose()
        {
            _sessionFactory.Close();
            _sessionFactory.Dispose();
            _configuration = null;
        }

        internal void BuildSessionFactory()
        {
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        internal virtual ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        internal virtual IStatelessSession OpenStatelessSession()
        {
            return _sessionFactory.OpenStatelessSession();
        }

        private void CreateDatabase()
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder(_connectionString);
            connectionStringBuilder.Remove("Database");

            var connectionString = connectionStringBuilder.ToString();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                ExecuteNonQuery(conn, $"DROP DATABASE IF EXISTS {_databaseName}");
                ExecuteNonQuery(conn, $"CREATE DATABASE {_databaseName}");
            }
        }

        private void ExecuteSchema()
        {
            var schema = ReadResource("DataContextSchema.sql");
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                ExecuteNonQuery(conn, schema);
                conn.ReloadTypes();
            }
        }

        private void ExecuteNonQuery(NpgsqlConnection conn, string statement)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = statement;
                cmd.ExecuteNonQuery();
            }
        }

        private string ReadResource(string resourceName)
        {
            var content = string.Empty;
            var assembly = Assembly.Load(_assemblyName);
            var resourcePath = _assemblyName + "." + resourceName;

            using (var stream = assembly.GetManifestResourceStream(resourcePath))
            using (var reader = new StreamReader(stream))
            {
                content = reader.ReadToEnd();
            }

            return content;
        }
    }

    [CollectionDefinition("DataContext")]
    public class DataContextCollection : ICollectionFixture<DataContextFixture>
    {
    }
}
