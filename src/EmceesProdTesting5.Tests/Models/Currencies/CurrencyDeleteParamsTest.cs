using System;
using System.Net.Http;
using EmceesProdTesting5.Models.Currencies;

namespace EmceesProdTesting5.Tests.Models.Currencies;

public class CurrencyDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CurrencyDeleteParams
        {
            Code = "GBP",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedCode = "GBP";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedCode, parameters.Code);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CurrencyDeleteParams { Code = "GBP" };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CurrencyDeleteParams
        {
            Code = "GBP",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        CurrencyDeleteParams parameters = new() { Code = "GBP" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/currencies/GBP"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CurrencyDeleteParams parameters = new()
        {
            Code = "GBP",
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
        var parameters = new CurrencyDeleteParams
        {
            Code = "GBP",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        CurrencyDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
