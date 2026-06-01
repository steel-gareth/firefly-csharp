using System;
using System.Net.Http;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Recurrences;

namespace EmceesProdTesting5.Tests.Models.Recurrences;

public class RecurrenceListTransactionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RecurrenceListTransactionsParams
        {
            ID = "123",
            End = "2026-04-30",
            Limit = 10,
            Page = 1,
            Start = "2026-04-01",
            Type = TransactionTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedEnd = "2026-04-30";
        int expectedLimit = 10;
        int expectedPage = 1;
        string expectedStart = "2026-04-01";
        ApiEnum<string, TransactionTypeFilter> expectedType = TransactionTypeFilter.All;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RecurrenceListTransactionsParams { ID = "123" };

        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RecurrenceListTransactionsParams
        {
            ID = "123",

            // Null should be interpreted as omitted for these properties
            End = null,
            Limit = null,
            Page = null,
            Start = null,
            Type = null,
            XTraceID = null,
        };

        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        RecurrenceListTransactionsParams parameters = new()
        {
            ID = "123",
            End = "2026-04-30",
            Limit = 10,
            Page = 1,
            Start = "2026-04-01",
            Type = TransactionTypeFilter.All,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/recurrences/123/transactions?end=2026-04-30&limit=10&page=1&start=2026-04-01&type=all"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RecurrenceListTransactionsParams parameters = new()
        {
            ID = "123",
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
        var parameters = new RecurrenceListTransactionsParams
        {
            ID = "123",
            End = "2026-04-30",
            Limit = 10,
            Page = 1,
            Start = "2026-04-01",
            Type = TransactionTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        RecurrenceListTransactionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
