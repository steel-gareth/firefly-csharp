using System;
using System.Net.Http;
using EmceesProdTesting5.Models.ExchangeRates;

namespace EmceesProdTesting5.Tests.Models.ExchangeRates;

public class ExchangeRateUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExchangeRateUpdateParams
        {
            ID = "123",
            Date = "2026-04-01",
            Rate = "2.3456",
            From = "USD",
            To = "EUR",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedDate = "2026-04-01";
        string expectedRate = "2.3456";
        string expectedFrom = "USD";
        string expectedTo = "EUR";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedRate, parameters.Rate);
        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExchangeRateUpdateParams
        {
            ID = "123",
            Date = "2026-04-01",
            Rate = "2.3456",
            From = "USD",
            To = "EUR",
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExchangeRateUpdateParams
        {
            ID = "123",
            Date = "2026-04-01",
            Rate = "2.3456",
            From = "USD",
            To = "EUR",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExchangeRateUpdateParams
        {
            ID = "123",
            Date = "2026-04-01",
            Rate = "2.3456",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.From);
        Assert.False(parameters.RawBodyData.ContainsKey("from"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExchangeRateUpdateParams
        {
            ID = "123",
            Date = "2026-04-01",
            Rate = "2.3456",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            From = null,
            To = null,
        };

        Assert.Null(parameters.From);
        Assert.True(parameters.RawBodyData.ContainsKey("from"));
        Assert.Null(parameters.To);
        Assert.True(parameters.RawBodyData.ContainsKey("to"));
    }

    [Fact]
    public void Url_Works()
    {
        ExchangeRateUpdateParams parameters = new()
        {
            ID = "123",
            Date = "2026-04-01",
            Rate = "2.3456",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/exchange-rates/123"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExchangeRateUpdateParams parameters = new()
        {
            ID = "123",
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
        var parameters = new ExchangeRateUpdateParams
        {
            ID = "123",
            Date = "2026-04-01",
            Rate = "2.3456",
            From = "USD",
            To = "EUR",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExchangeRateUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
