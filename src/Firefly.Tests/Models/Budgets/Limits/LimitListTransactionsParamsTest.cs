using System;
using System.Net.Http;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Budgets.Limits;

namespace Firefly.Tests.Models.Budgets.Limits;

public class LimitListTransactionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LimitListTransactionsParams
        {
            ID = "123",
            LimitID = "123",
            Limit = 10,
            Page = 1,
            Type = TransactionTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedLimitID = "123";
        int expectedLimit = 10;
        int expectedPage = 1;
        ApiEnum<string, TransactionTypeFilter> expectedType = TransactionTypeFilter.All;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLimitID, parameters.LimitID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LimitListTransactionsParams { ID = "123", LimitID = "123" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LimitListTransactionsParams
        {
            ID = "123",
            LimitID = "123",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Page = null,
            Type = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        LimitListTransactionsParams parameters = new()
        {
            ID = "123",
            LimitID = "123",
            Limit = 10,
            Page = 1,
            Type = TransactionTypeFilter.All,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/budgets/123/limits/123/transactions?limit=10&page=1&type=all"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        LimitListTransactionsParams parameters = new()
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
        var parameters = new LimitListTransactionsParams
        {
            ID = "123",
            LimitID = "123",
            Limit = 10,
            Page = 1,
            Type = TransactionTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        LimitListTransactionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
