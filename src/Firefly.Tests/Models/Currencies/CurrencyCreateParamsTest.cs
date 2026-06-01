using System;
using System.Net.Http;
using Firefly.Models.Currencies;

namespace Firefly.Tests.Models.Currencies;

public class CurrencyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CurrencyCreateParams
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            DecimalPlaces = 2,
            Enabled = true,
            Primary = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedCode = "AMS";
        string expectedName = "Ankh-Morpork dollar";
        string expectedSymbol = "AM$";
        int expectedDecimalPlaces = 2;
        bool expectedEnabled = true;
        bool expectedPrimary = true;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedCode, parameters.Code);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSymbol, parameters.Symbol);
        Assert.Equal(expectedDecimalPlaces, parameters.DecimalPlaces);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedPrimary, parameters.Primary);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CurrencyCreateParams
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
        };

        Assert.Null(parameters.DecimalPlaces);
        Assert.False(parameters.RawBodyData.ContainsKey("decimal_places"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Primary);
        Assert.False(parameters.RawBodyData.ContainsKey("primary"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CurrencyCreateParams
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",

            // Null should be interpreted as omitted for these properties
            DecimalPlaces = null,
            Enabled = null,
            Primary = null,
            XTraceID = null,
        };

        Assert.Null(parameters.DecimalPlaces);
        Assert.False(parameters.RawBodyData.ContainsKey("decimal_places"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Primary);
        Assert.False(parameters.RawBodyData.ContainsKey("primary"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        CurrencyCreateParams parameters = new()
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/currencies"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CurrencyCreateParams parameters = new()
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
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
        var parameters = new CurrencyCreateParams
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            DecimalPlaces = 2,
            Enabled = true,
            Primary = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        CurrencyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
