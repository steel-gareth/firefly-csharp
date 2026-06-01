using System;
using System.Net.Http;
using Firefly.Models.Data.Bulk;

namespace Firefly.Tests.Models.Data.Bulk;

public class BulkUpdateTransactionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkUpdateTransactionsParams
        {
            Query = "query",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedQuery = "query";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BulkUpdateTransactionsParams { Query = "query" };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BulkUpdateTransactionsParams
        {
            Query = "query",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        BulkUpdateTransactionsParams parameters = new() { Query = "query" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/data/bulk/transactions?query=query"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BulkUpdateTransactionsParams parameters = new()
        {
            Query = "query",
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
        var parameters = new BulkUpdateTransactionsParams
        {
            Query = "query",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        BulkUpdateTransactionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
