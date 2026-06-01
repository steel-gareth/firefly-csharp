using System;
using System.Net.Http;
using Firefly.Core;
using Firefly.Models.Data.Export;

namespace Firefly.Tests.Models.Data.Export;

public class ExportExportBillsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExportExportBillsParams
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
        var parameters = new ExportExportBillsParams { };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExportExportBillsParams
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
        ExportExportBillsParams parameters = new() { Type = ExportFileFilter.Csv };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/data/export/bills?type=csv"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExportExportBillsParams parameters = new()
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
        var parameters = new ExportExportBillsParams
        {
            Type = ExportFileFilter.Csv,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExportExportBillsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
