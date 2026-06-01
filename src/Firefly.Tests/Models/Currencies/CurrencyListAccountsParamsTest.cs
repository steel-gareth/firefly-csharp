using System;
using System.Net.Http;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Currencies;

namespace Firefly.Tests.Models.Currencies;

public class CurrencyListAccountsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CurrencyListAccountsParams
        {
            Code = "USD",
            Date = "2019-12-27",
            Limit = 10,
            Page = 1,
            Type = AccountTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedCode = "USD";
        string expectedDate = "2019-12-27";
        int expectedLimit = 10;
        int expectedPage = 1;
        ApiEnum<string, AccountTypeFilter> expectedType = AccountTypeFilter.All;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedCode, parameters.Code);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CurrencyListAccountsParams { Code = "USD" };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
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
        var parameters = new CurrencyListAccountsParams
        {
            Code = "USD",

            // Null should be interpreted as omitted for these properties
            Date = null,
            Limit = null,
            Page = null,
            Type = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
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
        CurrencyListAccountsParams parameters = new()
        {
            Code = "USD",
            Date = "2019-12-27",
            Limit = 10,
            Page = 1,
            Type = AccountTypeFilter.All,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/currencies/USD/accounts?date=2019-12-27&limit=10&page=1&type=all"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CurrencyListAccountsParams parameters = new()
        {
            Code = "USD",
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
        var parameters = new CurrencyListAccountsParams
        {
            Code = "USD",
            Date = "2019-12-27",
            Limit = 10,
            Page = 1,
            Type = AccountTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        CurrencyListAccountsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
