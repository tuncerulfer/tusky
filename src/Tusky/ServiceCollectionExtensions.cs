using System;
using Microsoft.Extensions.DependencyInjection;

namespace Tusky
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTusky(this IServiceCollection services, Action<TuskyOptions> configureOptions)
        {
            services.PostConfigure(configureOptions);
            services.AddSingleton<ITuskyContext, TuskyContext>();
            services.AddScoped((sp) => sp.GetService<ITuskyContext>().SessionFactory.OpenSession());
            services.AddTransient((sp) => sp.GetService<ITuskyContext>().SessionFactory.OpenStatelessSession());
        }
    }
}
