using System;
using System.Net.Http;
using EmceesProdTesting5.Models.Budgets.Limits;

namespace EmceesProdTesting5.Tests.Models.Budgets.Limits;

public class LimitUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LimitUpdateParams
        {
            ID = "123",
            LimitID = "123",
            Amount = "123.45",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            CurrencyName = "Euro",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            FireWebhooks = true,
            Notes = "Some example notes",
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedLimitID = "123";
        string expectedAmount = "123.45";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        bool expectedFireWebhooks = true;
        string expectedNotes = "Some example notes";
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLimitID, parameters.LimitID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCurrencyCode, parameters.CurrencyCode);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedCurrencyName, parameters.CurrencyName);
        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedFireWebhooks, parameters.FireWebhooks);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LimitUpdateParams
        {
            ID = "123",
            LimitID = "123",
            Notes = "Some example notes",
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_code"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_id"));
        Assert.Null(parameters.CurrencyName);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_name"));
        Assert.Null(parameters.End);
        Assert.False(parameters.RawBodyData.ContainsKey("end"));
        Assert.Null(parameters.FireWebhooks);
        Assert.False(parameters.RawBodyData.ContainsKey("fire_webhooks"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawBodyData.ContainsKey("start"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LimitUpdateParams
        {
            ID = "123",
            LimitID = "123",
            Notes = "Some example notes",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            CurrencyCode = null,
            CurrencyID = null,
            CurrencyName = null,
            End = null,
            FireWebhooks = null,
            Start = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_code"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_id"));
        Assert.Null(parameters.CurrencyName);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_name"));
        Assert.Null(parameters.End);
        Assert.False(parameters.RawBodyData.ContainsKey("end"));
        Assert.Null(parameters.FireWebhooks);
        Assert.False(parameters.RawBodyData.ContainsKey("fire_webhooks"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawBodyData.ContainsKey("start"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LimitUpdateParams
        {
            ID = "123",
            LimitID = "123",
            Amount = "123.45",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            CurrencyName = "Euro",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            FireWebhooks = true,
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LimitUpdateParams
        {
            ID = "123",
            LimitID = "123",
            Amount = "123.45",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            CurrencyName = "Euro",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            FireWebhooks = true,
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        LimitUpdateParams parameters = new() { ID = "123", LimitID = "123" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/budgets/123/limits/123"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        LimitUpdateParams parameters = new()
        {
            ID = "123",
            LimitID = "123",
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
        var parameters = new LimitUpdateParams
        {
            ID = "123",
            LimitID = "123",
            Amount = "123.45",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            CurrencyName = "Euro",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            FireWebhooks = true,
            Notes = "Some example notes",
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        LimitUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
