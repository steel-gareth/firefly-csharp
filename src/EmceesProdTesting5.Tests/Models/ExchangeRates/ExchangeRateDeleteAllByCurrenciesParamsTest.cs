using System;
using System.Net.Http;
using EmceesProdTesting5.Models.ExchangeRates;

namespace EmceesProdTesting5.Tests.Models.ExchangeRates;

public class ExchangeRateDeleteAllByCurrenciesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExchangeRateDeleteAllByCurrenciesParams
        {
            From = "EUR",
            To = "USD",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedFrom = "EUR";
        string expectedTo = "USD";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExchangeRateDeleteAllByCurrenciesParams { From = "EUR", To = "USD" };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExchangeRateDeleteAllByCurrenciesParams
        {
            From = "EUR",
            To = "USD",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExchangeRateDeleteAllByCurrenciesParams parameters = new() { From = "EUR", To = "USD" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/exchange-rates/EUR/USD"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExchangeRateDeleteAllByCurrenciesParams parameters = new()
        {
            From = "EUR",
            To = "USD",
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
        var parameters = new ExchangeRateDeleteAllByCurrenciesParams
        {
            From = "EUR",
            To = "USD",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExchangeRateDeleteAllByCurrenciesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
