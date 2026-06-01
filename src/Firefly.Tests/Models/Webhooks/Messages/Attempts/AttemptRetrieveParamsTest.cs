using System;
using System.Net.Http;
using Firefly.Models.Webhooks.Messages.Attempts;

namespace Firefly.Tests.Models.Webhooks.Messages.Attempts;

public class AttemptRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AttemptRetrieveParams
        {
            ID = "123",
            MessageID = 1,
            AttemptID = 1,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        long expectedMessageID = 1;
        long expectedAttemptID = 1;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMessageID, parameters.MessageID);
        Assert.Equal(expectedAttemptID, parameters.AttemptID);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AttemptRetrieveParams
        {
            ID = "123",
            MessageID = 1,
            AttemptID = 1,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AttemptRetrieveParams
        {
            ID = "123",
            MessageID = 1,
            AttemptID = 1,

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        AttemptRetrieveParams parameters = new()
        {
            ID = "123",
            MessageID = 1,
            AttemptID = 1,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/webhooks/123/messages/1/attempts/1"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AttemptRetrieveParams parameters = new()
        {
            ID = "123",
            MessageID = 1,
            AttemptID = 1,
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
        var parameters = new AttemptRetrieveParams
        {
            ID = "123",
            MessageID = 1,
            AttemptID = 1,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AttemptRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
