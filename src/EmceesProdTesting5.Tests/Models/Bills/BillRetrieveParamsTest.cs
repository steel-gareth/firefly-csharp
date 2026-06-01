using System;
using System.Net.Http;
using EmceesProdTesting5.Models.Bills;

namespace EmceesProdTesting5.Tests.Models.Bills;

public class BillRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BillRetrieveParams
        {
            ID = "123",
            End = "2026-04-30",
            Start = "2026-04-01",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedEnd = "2026-04-30";
        string expectedStart = "2026-04-01";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BillRetrieveParams { ID = "123" };

        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BillRetrieveParams
        {
            ID = "123",

            // Null should be interpreted as omitted for these properties
            End = null,
            Start = null,
            XTraceID = null,
        };

        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        BillRetrieveParams parameters = new()
        {
            ID = "123",
            End = "2026-04-30",
            Start = "2026-04-01",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/bills/123?end=2026-04-30&start=2026-04-01"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BillRetrieveParams parameters = new()
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
        var parameters = new BillRetrieveParams
        {
            ID = "123",
            End = "2026-04-30",
            Start = "2026-04-01",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        BillRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
