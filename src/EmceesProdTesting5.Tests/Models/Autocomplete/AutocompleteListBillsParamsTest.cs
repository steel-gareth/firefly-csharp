using System;
using System.Net.Http;
using EmceesProdTesting5.Models.Autocomplete;

namespace EmceesProdTesting5.Tests.Models.Autocomplete;

public class AutocompleteListBillsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AutocompleteListBillsParams
        {
            Limit = 0,
            Query = "query",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        int expectedLimit = 0;
        string expectedQuery = "query";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AutocompleteListBillsParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawQueryData.ContainsKey("query"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AutocompleteListBillsParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Query = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawQueryData.ContainsKey("query"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        AutocompleteListBillsParams parameters = new() { Limit = 0, Query = "query" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/autocomplete/bills?limit=0&query=query"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AutocompleteListBillsParams parameters = new()
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
        var parameters = new AutocompleteListBillsParams
        {
            Limit = 0,
            Query = "query",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AutocompleteListBillsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
