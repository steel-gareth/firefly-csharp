using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Models.ExchangeRates;

namespace EmceesProdTesting5.Tests.Models.ExchangeRates;

public class ExchangeRateCreateByDateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExchangeRateCreateByDateParams
        {
            Date = "2026-04-01",
            DateValue = JsonSerializer.Deserialize<JsonElement>("{}"),
            From = "EUR",
            Rates = new Dictionary<string, string>() { { "USD", "1.2345" }, { "GBP", "6.3456" } },
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedDate = "2026-04-01";
        JsonElement expectedDateValue = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedFrom = "EUR";
        Dictionary<string, string> expectedRates = new()
        {
            { "USD", "1.2345" },
            { "GBP", "6.3456" },
        };
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedDate, parameters.Date);
        Assert.True(JsonElement.DeepEquals(expectedDateValue, parameters.DateValue));
        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedRates.Count, parameters.Rates.Count);
        foreach (var item in expectedRates)
        {
            Assert.True(parameters.Rates.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Rates[item.Key]);
        }
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExchangeRateCreateByDateParams
        {
            Date = "2026-04-01",
            DateValue = JsonSerializer.Deserialize<JsonElement>("{}"),
            From = "EUR",
            Rates = new Dictionary<string, string>() { { "USD", "1.2345" }, { "GBP", "6.3456" } },
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExchangeRateCreateByDateParams
        {
            Date = "2026-04-01",
            DateValue = JsonSerializer.Deserialize<JsonElement>("{}"),
            From = "EUR",
            Rates = new Dictionary<string, string>() { { "USD", "1.2345" }, { "GBP", "6.3456" } },

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExchangeRateCreateByDateParams parameters = new()
        {
            Date = "2026-04-01",
            DateValue = JsonSerializer.Deserialize<JsonElement>("{}"),
            From = "EUR",
            Rates = new Dictionary<string, string>() { { "USD", "1.2345" }, { "GBP", "6.3456" } },
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/exchange-rates/by-date/2026-04-01"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExchangeRateCreateByDateParams parameters = new()
        {
            Date = "2026-04-01",
            DateValue = JsonSerializer.Deserialize<JsonElement>("{}"),
            From = "EUR",
            Rates = new Dictionary<string, string>() { { "USD", "1.2345" }, { "GBP", "6.3456" } },
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
        var parameters = new ExchangeRateCreateByDateParams
        {
            Date = "2026-04-01",
            DateValue = JsonSerializer.Deserialize<JsonElement>("{}"),
            From = "EUR",
            Rates = new Dictionary<string, string>() { { "USD", "1.2345" }, { "GBP", "6.3456" } },
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExchangeRateCreateByDateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
