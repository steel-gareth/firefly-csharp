using System;
using System.Net.Http;
using EmceesProdTesting5.Models.LinkTypes;

namespace EmceesProdTesting5.Tests.Models.LinkTypes;

public class LinkTypeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LinkTypeCreateParams
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedInward = "is (partially) paid for by";
        string expectedName = "Paid";
        string expectedOutward = "(partially) pays for";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedInward, parameters.Inward);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOutward, parameters.Outward);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LinkTypeCreateParams
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LinkTypeCreateParams
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        LinkTypeCreateParams parameters = new()
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/link-types"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        LinkTypeCreateParams parameters = new()
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
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
        var parameters = new LinkTypeCreateParams
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        LinkTypeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
