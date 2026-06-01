using System;
using System.Net.Http;
using Firefly.Models.ExchangeRates;

namespace Firefly.Tests.Models.ExchangeRates;

public class ExchangeRateUpdateByDateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExchangeRateUpdateByDateParams
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Rate = "2.3456",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedFrom = "EUR";
        string expectedTo = "USD";
        string expectedDate = "2026-04-01";
        string expectedRate = "2.3456";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedRate, parameters.Rate);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExchangeRateUpdateByDateParams
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Rate = "2.3456",
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExchangeRateUpdateByDateParams
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Rate = "2.3456",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExchangeRateUpdateByDateParams parameters = new()
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Rate = "2.3456",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/exchange-rates/EUR/USD/2026-04-01"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExchangeRateUpdateByDateParams parameters = new()
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Rate = "2.3456",
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
        var parameters = new ExchangeRateUpdateByDateParams
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Rate = "2.3456",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExchangeRateUpdateByDateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
