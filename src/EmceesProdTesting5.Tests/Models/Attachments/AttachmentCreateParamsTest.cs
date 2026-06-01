using System;
using System.Net.Http;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Models.Attachments;

public class AttachmentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AttachmentCreateParams
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            Filename = "file.pdf",
            Notes = "Some notes",
            Title = "Some PDF file",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedAttachableID = "134";
        ApiEnum<string, AttachableType> expectedAttachableType = AttachableType.Bill;
        string expectedFilename = "file.pdf";
        string expectedNotes = "Some notes";
        string expectedTitle = "Some PDF file";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedAttachableID, parameters.AttachableID);
        Assert.Equal(expectedAttachableType, parameters.AttachableType);
        Assert.Equal(expectedFilename, parameters.Filename);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AttachmentCreateParams
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            Filename = "file.pdf",
            Notes = "Some notes",
        };

        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AttachmentCreateParams
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            Filename = "file.pdf",
            Notes = "Some notes",

            // Null should be interpreted as omitted for these properties
            Title = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AttachmentCreateParams
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
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
        var parameters = new AttachmentCreateParams
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
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
        AttachmentCreateParams parameters = new()
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            Filename = "file.pdf",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/attachments"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AttachmentCreateParams parameters = new()
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            Filename = "file.pdf",
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
        var parameters = new AttachmentCreateParams
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            Filename = "file.pdf",
            Notes = "Some notes",
            Title = "Some PDF file",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AttachmentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
