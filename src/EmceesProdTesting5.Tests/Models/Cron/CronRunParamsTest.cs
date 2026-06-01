using System;
using System.Net.Http;
using EmceesProdTesting5.Models.Cron;

namespace EmceesProdTesting5.Tests.Models.Cron;

public class CronRunParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CronRunParams
        {
            CliToken = "d5ea6b5fb774618dd6ad6ba6e0a7f55c",
            Date = "2026-04-01",
            Force = false,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedCliToken = "d5ea6b5fb774618dd6ad6ba6e0a7f55c";
        string expectedDate = "2026-04-01";
        bool expectedForce = false;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedCliToken, parameters.CliToken);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedForce, parameters.Force);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CronRunParams { CliToken = "d5ea6b5fb774618dd6ad6ba6e0a7f55c" };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
        Assert.Null(parameters.Force);
        Assert.False(parameters.RawQueryData.ContainsKey("force"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CronRunParams
        {
            CliToken = "d5ea6b5fb774618dd6ad6ba6e0a7f55c",

            // Null should be interpreted as omitted for these properties
            Date = null,
            Force = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
        Assert.Null(parameters.Force);
        Assert.False(parameters.RawQueryData.ContainsKey("force"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        CronRunParams parameters = new()
        {
            CliToken = "d5ea6b5fb774618dd6ad6ba6e0a7f55c",
            Date = "2026-04-01",
            Force = false,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/cron/d5ea6b5fb774618dd6ad6ba6e0a7f55c?date=2026-04-01&force=false"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CronRunParams parameters = new()
        {
            CliToken = "d5ea6b5fb774618dd6ad6ba6e0a7f55c",
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
        var parameters = new CronRunParams
        {
            CliToken = "d5ea6b5fb774618dd6ad6ba6e0a7f55c",
            Date = "2026-04-01",
            Force = false,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        CronRunParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
