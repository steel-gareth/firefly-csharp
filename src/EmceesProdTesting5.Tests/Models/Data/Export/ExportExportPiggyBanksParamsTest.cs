using System;
using System.Net.Http;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Data.Export;

namespace EmceesProdTesting5.Tests.Models.Data.Export;

public class ExportExportPiggyBanksParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExportExportPiggyBanksParams
        {
            Type = ExportFileFilter.Csv,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ApiEnum<string, ExportFileFilter> expectedType = ExportFileFilter.Csv;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExportExportPiggyBanksParams { };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExportExportPiggyBanksParams
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExportExportPiggyBanksParams parameters = new() { Type = ExportFileFilter.Csv };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/data/export/piggy-banks?type=csv"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExportExportPiggyBanksParams parameters = new()
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
        var parameters = new ExportExportPiggyBanksParams
        {
            Type = ExportFileFilter.Csv,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExportExportPiggyBanksParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
