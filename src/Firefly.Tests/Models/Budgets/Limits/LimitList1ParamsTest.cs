using System;
using System.Net.Http;
using Firefly.Models.Budgets.Limits;

namespace Firefly.Tests.Models.Budgets.Limits;

public class LimitList1ParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LimitList1Params
        {
            End = "2026-04-30",
            Start = "2026-04-01",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedEnd = "2026-04-30";
        string expectedStart = "2026-04-01";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LimitList1Params { End = "2026-04-30", Start = "2026-04-01" };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LimitList1Params
        {
            End = "2026-04-30",
            Start = "2026-04-01",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        LimitList1Params parameters = new() { End = "2026-04-30", Start = "2026-04-01" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/budget-limits?end=2026-04-30&start=2026-04-01"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        LimitList1Params parameters = new()
        {
            End = "2026-04-30",
            Start = "2026-04-01",
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
        var parameters = new LimitList1Params
        {
            End = "2026-04-30",
            Start = "2026-04-01",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        LimitList1Params copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
