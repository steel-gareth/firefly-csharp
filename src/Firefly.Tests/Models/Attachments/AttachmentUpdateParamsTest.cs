using System;
using System.Net.Http;
using Firefly.Models.Attachments;

namespace Firefly.Tests.Models.Attachments;

public class AttachmentUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AttachmentUpdateParams
        {
            ID = "123",
            Filename = "file.pdf",
            Notes = "Some notes",
            Title = "Some PDF file",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedFilename = "file.pdf";
        string expectedNotes = "Some notes";
        string expectedTitle = "Some PDF file";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFilename, parameters.Filename);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AttachmentUpdateParams { ID = "123", Notes = "Some notes" };

        Assert.Null(parameters.Filename);
        Assert.False(parameters.RawBodyData.ContainsKey("filename"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AttachmentUpdateParams
        {
            ID = "123",
            Notes = "Some notes",

            // Null should be interpreted as omitted for these properties
            Filename = null,
            Title = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Filename);
        Assert.False(parameters.RawBodyData.ContainsKey("filename"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AttachmentUpdateParams
        {
            ID = "123",
            Filename = "file.pdf",
            Title = "Some PDF file",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AttachmentUpdateParams
        {
            ID = "123",
            Filename = "file.pdf",
            Title = "Some PDF file",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        AttachmentUpdateParams parameters = new() { ID = "123" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/attachments/123"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AttachmentUpdateParams parameters = new()
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
        var parameters = new AttachmentUpdateParams
        {
            ID = "123",
            Filename = "file.pdf",
            Notes = "Some notes",
            Title = "Some PDF file",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AttachmentUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
