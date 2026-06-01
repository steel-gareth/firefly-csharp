using System;
using System.Collections.Generic;
using System.Net.Http;
using Firefly.Models.ExchangeRates;

namespace Firefly.Tests.Models.ExchangeRates;

public class ExchangeRateCreateByCurrenciesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExchangeRateCreateByCurrenciesParams
        {
            From = "EUR",
            To = "USD",
            Body = new Dictionary<string, string>()
            {
                { "2025-08-01", "1.2345" },
                { "2025-08-02", "6.3456" },
            },
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedFrom = "EUR";
        string expectedTo = "USD";
        Dictionary<string, string> expectedBody = new()
        {
            { "2025-08-01", "1.2345" },
            { "2025-08-02", "6.3456" },
        };
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedBody.Count, parameters.Body.Count);
        foreach (var item in expectedBody)
        {
            Assert.True(parameters.Body.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Body[item.Key]);
        }
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExchangeRateCreateByCurrenciesParams
        {
            From = "EUR",
            To = "USD",
            Body = new Dictionary<string, string>()
            {
                { "2025-08-01", "1.2345" },
                { "2025-08-02", "6.3456" },
            },
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExchangeRateCreateByCurrenciesParams
        {
            From = "EUR",
            To = "USD",
            Body = new Dictionary<string, string>()
            {
                { "2025-08-01", "1.2345" },
                { "2025-08-02", "6.3456" },
            },

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExchangeRateCreateByCurrenciesParams parameters = new()
        {
            From = "EUR",
            To = "USD",
            Body = new Dictionary<string, string>()
            {
                { "2025-08-01", "1.2345" },
                { "2025-08-02", "6.3456" },
            },
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/exchange-rates/by-currencies/EUR/USD"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExchangeRateCreateByCurrenciesParams parameters = new()
        {
            From = "EUR",
            To = "USD",
            Body = new Dictionary<string, string>()
            {
                { "2025-08-01", "1.2345" },
                { "2025-08-02", "6.3456" },
            },
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
        var parameters = new ExchangeRateCreateByCurrenciesParams
        {
            From = "EUR",
            To = "USD",
            Body = new Dictionary<string, string>()
            {
                { "2025-08-01", "1.2345" },
                { "2025-08-02", "6.3456" },
            },
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExchangeRateCreateByCurrenciesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
