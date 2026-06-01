using System;
using System.Net.Http;
using Firefly.Models.ExchangeRates;

namespace Firefly.Tests.Models.ExchangeRates;

public class ExchangeRateRetrieveByDateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExchangeRateRetrieveByDateParams
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Limit = 10,
            Page = 1,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedFrom = "EUR";
        string expectedTo = "USD";
        string expectedDate = "2026-04-01";
        int expectedLimit = 10;
        int expectedPage = 1;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExchangeRateRetrieveByDateParams
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExchangeRateRetrieveByDateParams
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Page = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExchangeRateRetrieveByDateParams parameters = new()
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Limit = 10,
            Page = 1,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/exchange-rates/EUR/USD/2026-04-01?limit=10&page=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExchangeRateRetrieveByDateParams parameters = new()
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
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
        var parameters = new ExchangeRateRetrieveByDateParams
        {
            From = "EUR",
            To = "USD",
            Date = "2026-04-01",
            Limit = 10,
            Page = 1,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExchangeRateRetrieveByDateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
