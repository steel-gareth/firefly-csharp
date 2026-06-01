using System;
using System.Collections.Generic;
using System.Net.Http;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Autocomplete;

namespace Firefly.Tests.Models.Autocomplete;

public class AutocompleteListAccountsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AutocompleteListAccountsParams
        {
            Date = "date",
            Limit = 0,
            Query = "query",
            Types = [AccountTypeFilter.All],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedDate = "date";
        int expectedLimit = 0;
        string expectedQuery = "query";
        List<ApiEnum<string, AccountTypeFilter>> expectedTypes = [AccountTypeFilter.All];
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.NotNull(parameters.Types);
        Assert.Equal(expectedTypes.Count, parameters.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], parameters.Types[i]);
        }
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AutocompleteListAccountsParams { };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawQueryData.ContainsKey("query"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AutocompleteListAccountsParams
        {
            // Null should be interpreted as omitted for these properties
            Date = null,
            Limit = null,
            Query = null,
            Types = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawQueryData.ContainsKey("query"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        AutocompleteListAccountsParams parameters = new()
        {
            Date = "date",
            Limit = 0,
            Query = "query",
            Types = [AccountTypeFilter.All],
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/autocomplete/accounts?date=date&limit=0&query=query&types=all"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AutocompleteListAccountsParams parameters = new()
        {
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
        var parameters = new AutocompleteListAccountsParams
        {
            Date = "date",
            Limit = 0,
            Query = "query",
            Types = [AccountTypeFilter.All],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AutocompleteListAccountsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
