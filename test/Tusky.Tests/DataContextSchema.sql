-- Criterion

CREATE TABLE campaign (
    id serial,
    price_range numrange,
    discount_rate decimal
);

INSERT INTO campaign (price_range, discount_rate) VALUES
    ('[10.00, 25.75]', -0.10),
    ('[25.76, 50.40]', -0.20),
    ('[51.41, 99.99]', -0.30),
    ('[100,)',         -0.40);

-- Types

CREATE TABLE array_single_rank_model (
    id serial,
    int16_array_column int2[],
    int32_array_column int4[],
    int64_array_column int8[],
    decimal_array_column decimal[],
    single_array_column float4[],
    double_array_column float8[],
    string_array_column text[],
    boolean_array_column bool[],
    date_time_array_column timestamp[]
);

CREATE TABLE array_multiple_rank_model (
    id serial,
    int16_array_column int2[][],
    int32_array_column int4[][],
    int64_array_column int8[][],
    decimal_array_column decimal[][],
    single_array_column float4[][],
    double_array_column float8[][],
    string_array_column text[][],
    boolean_array_column bool[][],
    date_time_array_column timestamp[][]
);

CREATE TABLE list_model (
    id serial,
    int16_list_column int2[],
    int32_list_column int4[],
    int64_list_column int8[],
    decimal_list_column decimal[],
    single_list_column float4[],
    double_list_column float8[],
    string_list_column text[],
    boolean_list_column bool[],
    date_time_list_column timestamp[]
);

CREATE TYPE mood AS ENUM (
    'sad',
    'happy',
    'very_happy'
);

CREATE TABLE enum_model (
    id serial,
    current_mood mood
);

CREATE TABLE json_model (
    id serial,
    sample_object_json json,
    sample_object_jsonb jsonb
);

CREATE TABLE inet_model (
    id serial,
    ip_address inet
);

CREATE TABLE mac_addr_model (
    id serial,
    mac_address macaddr
);

CREATE TABLE nodatime_model (
    id serial,
    timestamp_one_column timestamp,
    timestamp_two_column timestamp,
    date_column date,
    time_column time,
    timestamptz_one_column timestamptz,
    timestamptz_two_column timestamptz,
    datetz_column date,
    timetz_column timetz,
    interval_column interval
);

CREATE TABLE range_model (
    id serial,
    int32_range_column int4range,
    int64_range_column int8range,
    decimal_range_column numrange,
    timestamp_range_column tsrange,
    timestamptz_one_range_column tstzrange,
    timestamptz_two_range_column tstzrange,
    date_range_column daterange
);
