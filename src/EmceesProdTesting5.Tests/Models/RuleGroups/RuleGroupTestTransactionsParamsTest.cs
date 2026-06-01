using System;
using System.Collections.Generic;
using System.Net.Http;
using EmceesProdTesting5.Models.RuleGroups;

namespace EmceesProdTesting5.Tests.Models.RuleGroups;

public class RuleGroupTestTransactionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleGroupTestTransactionsParams
        {
            ID = "123",
            Accounts = [1, 2, 3],
            End = "2026-04-30",
            Limit = 10,
            Page = 1,
            SearchLimit = 0,
            Start = "2026-04-01",
            TriggeredLimit = 0,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        List<long> expectedAccounts = [1, 2, 3];
        string expectedEnd = "2026-04-30";
        int expectedLimit = 10;
        int expectedPage = 1;
        long expectedSearchLimit = 0;
        string expectedStart = "2026-04-01";
        long expectedTriggeredLimit = 0;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Accounts);
        Assert.Equal(expectedAccounts.Count, parameters.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], parameters.Accounts[i]);
        }
        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedSearchLimit, parameters.SearchLimit);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.Equal(expectedTriggeredLimit, parameters.TriggeredLimit);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleGroupTestTransactionsParams { ID = "123" };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SearchLimit);
        Assert.False(parameters.RawQueryData.ContainsKey("search_limit"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
        Assert.Null(parameters.TriggeredLimit);
        Assert.False(parameters.RawQueryData.ContainsKey("triggered_limit"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RuleGroupTestTransactionsParams
        {
            ID = "123",

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            End = null,
            Limit = null,
            Page = null,
            SearchLimit = null,
            Start = null,
            TriggeredLimit = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SearchLimit);
        Assert.False(parameters.RawQueryData.ContainsKey("search_limit"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
        Assert.Null(parameters.TriggeredLimit);
        Assert.False(parameters.RawQueryData.ContainsKey("triggered_limit"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        RuleGroupTestTransactionsParams parameters = new()
        {
            ID = "123",
            Accounts = [1, 2, 3],
            End = "2026-04-30",
            Limit = 10,
            Page = 1,
            SearchLimit = 0,
            Start = "2026-04-01",
            TriggeredLimit = 0,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/rule-groups/123/test?accounts=1%2c2%2c3&end=2026-04-30&limit=10&page=1&search_limit=0&start=2026-04-01&triggered_limit=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RuleGroupTestTransactionsParams parameters = new()
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
        var parameters = new RuleGroupTestTransactionsParams
        {
            ID = "123",
            Accounts = [1, 2, 3],
            End = "2026-04-30",
            Limit = 10,
            Page = 1,
            SearchLimit = 0,
            Start = "2026-04-01",
            TriggeredLimit = 0,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        RuleGroupTestTransactionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
