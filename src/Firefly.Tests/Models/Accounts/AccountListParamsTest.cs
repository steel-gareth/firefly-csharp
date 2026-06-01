using System;
using System.Net.Http;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Tests.Models.Accounts;

public class AccountListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountListParams
        {
            Date = "2019-12-27",
            End = "2019-12-27",
            Limit = 10,
            Page = 1,
            Start = "2019-12-27",
            Type = AccountTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedDate = "2019-12-27";
        string expectedEnd = "2019-12-27";
        int expectedLimit = 10;
        int expectedPage = 1;
        string expectedStart = "2019-12-27";
        ApiEnum<string, AccountTypeFilter> expectedType = AccountTypeFilter.All;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedDate, parameters.Date);
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
        var parameters = new AccountListParams { };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
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
        var parameters = new AccountListParams
        {
            // Null should be interpreted as omitted for these properties
            Date = null,
            End = null,
            Limit = null,
            Page = null,
            Start = null,
            Type = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
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
        AccountListParams parameters = new()
        {
            Date = "2019-12-27",
            End = "2019-12-27",
            Limit = 10,
            Page = 1,
            Start = "2019-12-27",
            Type = AccountTypeFilter.All,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/accounts?date=2019-12-27&end=2019-12-27&limit=10&page=1&start=2019-12-27&type=all"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AccountListParams parameters = new() { XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00" };

        parameters.AddHeadersToRequest(requestMessage, new() { });

        Assert.Equal(
            ["40c71bbb-c676-4f24-83cf-cc725d7d7a00"],
            requestMessage.Headers.GetValues("X-Trace-Id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountListParams
        {
            Date = "2019-12-27",
            End = "2019-12-27",
            Limit = 10,
            Page = 1,
            Start = "2019-12-27",
            Type = AccountTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AccountListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
