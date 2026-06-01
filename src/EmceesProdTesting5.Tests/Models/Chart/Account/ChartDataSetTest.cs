using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Chart.Account;

namespace EmceesProdTesting5.Tests.Models.Chart.Account;

public class ChartDataSetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChartDataSet
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Entries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Label = "Checking account",
            PcEntries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Period = ChartDataSetPeriod.V1M,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Type = "line",
            YAxisID = 0,
        };

        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        JsonElement expectedEntries = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedLabel = "Checking account";
        JsonElement expectedPcEntries = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, ChartDataSetPeriod> expectedPeriod = ChartDataSetPeriod.V1M;
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedType = "line";
        int expectedYAxisID = 0;

        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.NotNull(model.Entries);
        Assert.True(JsonElement.DeepEquals(expectedEntries, model.Entries.Value));
        Assert.Equal(expectedLabel, model.Label);
        Assert.NotNull(model.PcEntries);
        Assert.True(JsonElement.DeepEquals(expectedPcEntries, model.PcEntries.Value));
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, model.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedYAxisID, model.YAxisID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChartDataSet
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Entries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Label = "Checking account",
            PcEntries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Period = ChartDataSetPeriod.V1M,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Type = "line",
            YAxisID = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChartDataSet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChartDataSet
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Entries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Label = "Checking account",
            PcEntries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Period = ChartDataSetPeriod.V1M,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Type = "line",
            YAxisID = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChartDataSet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        JsonElement expectedEntries = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedLabel = "Checking account";
        JsonElement expectedPcEntries = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, ChartDataSetPeriod> expectedPeriod = ChartDataSetPeriod.V1M;
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedType = "line";
        int expectedYAxisID = 0;

        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.NotNull(deserialized.Entries);
        Assert.True(JsonElement.DeepEquals(expectedEntries, deserialized.Entries.Value));
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.NotNull(deserialized.PcEntries);
        Assert.True(JsonElement.DeepEquals(expectedPcEntries, deserialized.PcEntries.Value));
        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, deserialized.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedYAxisID, deserialized.YAxisID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChartDataSet
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Entries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Label = "Checking account",
            PcEntries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Period = ChartDataSetPeriod.V1M,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Type = "line",
            YAxisID = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChartDataSet { };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencyName);
        Assert.False(model.RawData.ContainsKey("currency_name"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.Entries);
        Assert.False(model.RawData.ContainsKey("entries"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.PcEntries);
        Assert.False(model.RawData.ContainsKey("pc_entries"));
        Assert.Null(model.Period);
        Assert.False(model.RawData.ContainsKey("period"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencyName);
        Assert.False(model.RawData.ContainsKey("primary_currency_name"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.YAxisID);
        Assert.False(model.RawData.ContainsKey("yAxisID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChartDataSet { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChartDataSet
        {
            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            Date = null,
            EndDate = null,
            Entries = null,
            Label = null,
            PcEntries = null,
            Period = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            StartDate = null,
            Type = null,
            YAxisID = null,
        };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencyName);
        Assert.False(model.RawData.ContainsKey("currency_name"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.Entries);
        Assert.False(model.RawData.ContainsKey("entries"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.PcEntries);
        Assert.False(model.RawData.ContainsKey("pc_entries"));
        Assert.Null(model.Period);
        Assert.False(model.RawData.ContainsKey("period"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencyName);
        Assert.False(model.RawData.ContainsKey("primary_currency_name"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.YAxisID);
        Assert.False(model.RawData.ContainsKey("yAxisID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChartDataSet
        {
            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            Date = null,
            EndDate = null,
            Entries = null,
            Label = null,
            PcEntries = null,
            Period = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            StartDate = null,
            Type = null,
            YAxisID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChartDataSet
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Entries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Label = "Checking account",
            PcEntries = JsonSerializer.Deserialize<JsonElement>("{}"),
            Period = ChartDataSetPeriod.V1M,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Type = "line",
            YAxisID = 0,
        };

        ChartDataSet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChartDataSetPeriodTest : TestBase
{
    [Theory]
    [InlineData(ChartDataSetPeriod.V1D)]
    [InlineData(ChartDataSetPeriod.V1W)]
    [InlineData(ChartDataSetPeriod.V1M)]
    [InlineData(ChartDataSetPeriod.V3M)]
    [InlineData(ChartDataSetPeriod.V1Y)]
    [InlineData(ChartDataSetPeriod.Custom)]
    public void Validation_Works(ChartDataSetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChartDataSetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChartDataSetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChartDataSetPeriod.V1D)]
    [InlineData(ChartDataSetPeriod.V1W)]
    [InlineData(ChartDataSetPeriod.V1M)]
    [InlineData(ChartDataSetPeriod.V3M)]
    [InlineData(ChartDataSetPeriod.V1Y)]
    [InlineData(ChartDataSetPeriod.Custom)]
    public void SerializationRoundtrip_Works(ChartDataSetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChartDataSetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChartDataSetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChartDataSetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChartDataSetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
