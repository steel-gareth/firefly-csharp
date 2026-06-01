using System;
using System.Net.Http;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Models.Attachments;

public class AttachmentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AttachmentListParams
        {
            Limit = 10,
            Page = 1,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        int expectedLimit = 10;
        int expectedPage = 1;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AttachmentListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AttachmentListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Page = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        AttachmentListParams parameters = new() { Limit = 10, Page = 1 };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/attachments?limit=10&page=1"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AttachmentListParams parameters = new()
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
        var parameters = new AttachmentListParams
        {
            Limit = 10,
            Page = 1,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AttachmentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
