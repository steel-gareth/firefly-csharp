using System;
using System.Net.Http;
using EmceesProdTesting5.Models.About;

namespace EmceesProdTesting5.Tests.Models.About;

public class AboutRetrieveInfoParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AboutRetrieveInfoParams
        {
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AboutRetrieveInfoParams { };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AboutRetrieveInfoParams
        {
            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        AboutRetrieveInfoParams parameters = new();

        var url = parameters.Url(new() { });

        Assert.True(TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/about"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AboutRetrieveInfoParams parameters = new()
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
        var parameters = new AboutRetrieveInfoParams
        {
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AboutRetrieveInfoParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
