using System;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Currencies;

namespace EmceesProdTesting5.Tests.Models.Currencies;

public class CurrencyUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CurrencyUpdateParams
        {
            Code = "EUR",
            CodeValue = "AMS",
            DecimalPlaces = 2,
            Enabled = true,
            Name = "Ankh-Morpork dollar",
            Primary = CurrencyUpdateParamsPrimary.True,
            Symbol = "AM$",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedCode = "EUR";
        string expectedCodeValue = "AMS";
        int expectedDecimalPlaces = 2;
        bool expectedEnabled = true;
        string expectedName = "Ankh-Morpork dollar";
        ApiEnum<bool, CurrencyUpdateParamsPrimary> expectedPrimary =
            CurrencyUpdateParamsPrimary.True;
        string expectedSymbol = "AM$";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedCode, parameters.Code);
        Assert.Equal(expectedCodeValue, parameters.CodeValue);
        Assert.Equal(expectedDecimalPlaces, parameters.DecimalPlaces);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPrimary, parameters.Primary);
        Assert.Equal(expectedSymbol, parameters.Symbol);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CurrencyUpdateParams { Code = "EUR" };

        Assert.Null(parameters.CodeValue);
        Assert.False(parameters.RawBodyData.ContainsKey("code"));
        Assert.Null(parameters.DecimalPlaces);
        Assert.False(parameters.RawBodyData.ContainsKey("decimal_places"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Primary);
        Assert.False(parameters.RawBodyData.ContainsKey("primary"));
        Assert.Null(parameters.Symbol);
        Assert.False(parameters.RawBodyData.ContainsKey("symbol"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CurrencyUpdateParams
        {
            Code = "EUR",

            // Null should be interpreted as omitted for these properties
            CodeValue = null,
            DecimalPlaces = null,
            Enabled = null,
            Name = null,
            Primary = null,
            Symbol = null,
            XTraceID = null,
        };

        Assert.Null(parameters.CodeValue);
        Assert.False(parameters.RawBodyData.ContainsKey("code"));
        Assert.Null(parameters.DecimalPlaces);
        Assert.False(parameters.RawBodyData.ContainsKey("decimal_places"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Primary);
        Assert.False(parameters.RawBodyData.ContainsKey("primary"));
        Assert.Null(parameters.Symbol);
        Assert.False(parameters.RawBodyData.ContainsKey("symbol"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        CurrencyUpdateParams parameters = new() { Code = "EUR" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/currencies/EUR"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CurrencyUpdateParams parameters = new()
        {
            Code = "EUR",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { });

        Assert.Equal(
            ["40c71bbb-c676-4f24-83cf-cc725d7d7a00"],
            requestMessage.Headers.GetValues("X-Trace-Id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CurrencyUpdateParams
        {
            Code = "EUR",
            CodeValue = "AMS",
            DecimalPlaces = 2,
            Enabled = true,
            Name = "Ankh-Morpork dollar",
            Primary = CurrencyUpdateParamsPrimary.True,
            Symbol = "AM$",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        CurrencyUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CurrencyUpdateParamsPrimaryTest : TestBase
{
    [Theory]
    [InlineData(CurrencyUpdateParamsPrimary.True)]
    public void Validation_Works(CurrencyUpdateParamsPrimary rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CurrencyUpdateParamsPrimary> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, CurrencyUpdateParamsPrimary>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CurrencyUpdateParamsPrimary.True)]
    public void SerializationRoundtrip_Works(CurrencyUpdateParamsPrimary rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CurrencyUpdateParamsPrimary> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, CurrencyUpdateParamsPrimary>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, CurrencyUpdateParamsPrimary>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, CurrencyUpdateParamsPrimary>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
