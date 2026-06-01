using System;
using System.Net.Http;
using System.Text.Json;
using Firefly.Models.ExchangeRates;

namespace Firefly.Tests.Models.ExchangeRates;

public class ExchangeRateCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExchangeRateCreateParams
        {
            Date = "2026-04-01",
            From = "USD",
            Rates = JsonSerializer.Deserialize<JsonElement>("{}"),
            To = "EUR",
            Rate = "2.3456",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedDate = "2026-04-01";
        string expectedFrom = "USD";
        JsonElement expectedRates = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTo = "EUR";
        string expectedRate = "2.3456";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedFrom, parameters.From);
        Assert.True(JsonElement.DeepEquals(expectedRates, parameters.Rates));
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedRate, parameters.Rate);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExchangeRateCreateParams
        {
            Date = "2026-04-01",
            From = "USD",
            Rates = JsonSerializer.Deserialize<JsonElement>("{}"),
            To = "EUR",
        };

        Assert.Null(parameters.Rate);
        Assert.False(parameters.RawBodyData.ContainsKey("rate"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExchangeRateCreateParams
        {
            Date = "2026-04-01",
            From = "USD",
            Rates = JsonSerializer.Deserialize<JsonElement>("{}"),
            To = "EUR",

            // Null should be interpreted as omitted for these properties
            Rate = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Rate);
        Assert.False(parameters.RawBodyData.ContainsKey("rate"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExchangeRateCreateParams parameters = new()
        {
            Date = "2026-04-01",
            From = "USD",
            Rates = JsonSerializer.Deserialize<JsonElement>("{}"),
            To = "EUR",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/exchange-rates"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExchangeRateCreateParams parameters = new()
        {
            Date = "2026-04-01",
            From = "USD",
            Rates = JsonSerializer.Deserialize<JsonElement>("{}"),
            To = "EUR",
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
        var parameters = new ExchangeRateCreateParams
        {
            Date = "2026-04-01",
            From = "USD",
            Rates = JsonSerializer.Deserialize<JsonElement>("{}"),
            To = "EUR",
            Rate = "2.3456",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExchangeRateCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
