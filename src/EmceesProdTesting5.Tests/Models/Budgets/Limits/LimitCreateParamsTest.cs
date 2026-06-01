using System;
using System.Net.Http;
using EmceesProdTesting5.Models.Budgets.Limits;

namespace EmceesProdTesting5.Tests.Models.Budgets.Limits;

public class LimitCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LimitCreateParams
        {
            ID = "123",
            Amount = "123.45",
            End = "2026-04-30",
            Start = "2026-04-01",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            FireWebhooks = true,
            Notes = "Some example notes",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedAmount = "123.45";
        string expectedEnd = "2026-04-30";
        string expectedStart = "2026-04-01";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        bool expectedFireWebhooks = true;
        string expectedNotes = "Some example notes";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.Equal(expectedCurrencyCode, parameters.CurrencyCode);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedFireWebhooks, parameters.FireWebhooks);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LimitCreateParams
        {
            ID = "123",
            Amount = "123.45",
            End = "2026-04-30",
            Start = "2026-04-01",
            Notes = "Some example notes",
        };

        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_code"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_id"));
        Assert.Null(parameters.FireWebhooks);
        Assert.False(parameters.RawBodyData.ContainsKey("fire_webhooks"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LimitCreateParams
        {
            ID = "123",
            Amount = "123.45",
            End = "2026-04-30",
            Start = "2026-04-01",
            Notes = "Some example notes",

            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyID = null,
            FireWebhooks = null,
            XTraceID = null,
        };

        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_code"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_id"));
        Assert.Null(parameters.FireWebhooks);
        Assert.False(parameters.RawBodyData.ContainsKey("fire_webhooks"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LimitCreateParams
        {
            ID = "123",
            Amount = "123.45",
            End = "2026-04-30",
            Start = "2026-04-01",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            FireWebhooks = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LimitCreateParams
        {
            ID = "123",
            Amount = "123.45",
            End = "2026-04-30",
            Start = "2026-04-01",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            FireWebhooks = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        LimitCreateParams parameters = new()
        {
            ID = "123",
            Amount = "123.45",
            End = "2026-04-30",
            Start = "2026-04-01",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/budgets/123/limits"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        LimitCreateParams parameters = new()
        {
            ID = "123",
            Amount = "123.45",
            End = "2026-04-30",
            Start = "2026-04-01",
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
        var parameters = new LimitCreateParams
        {
            ID = "123",
            Amount = "123.45",
            End = "2026-04-30",
            Start = "2026-04-01",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            FireWebhooks = true,
            Notes = "Some example notes",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        LimitCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
