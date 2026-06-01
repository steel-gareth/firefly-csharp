using System;
using System.Net.Http;
using Firefly.Core;
using Firefly.Models.Data.Export;

namespace Firefly.Tests.Models.Data.Export;

public class ExportExportTransactionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExportExportTransactionsParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = "accounts",
            Type = ExportFileFilter.Csv,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedEnd = "2019-12-27";
        string expectedStart = "2019-12-27";
        string expectedAccounts = "accounts";
        ApiEnum<string, ExportFileFilter> expectedType = ExportFileFilter.Csv;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.Equal(expectedAccounts, parameters.Accounts);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExportExportTransactionsParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExportExportTransactionsParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            Type = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExportExportTransactionsParams parameters = new()
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = "accounts",
            Type = ExportFileFilter.Csv,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/data/export/transactions?end=2019-12-27&start=2019-12-27&accounts=accounts&type=csv"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExportExportTransactionsParams parameters = new()
        {
            End = "2019-12-27",
            Start = "2019-12-27",
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
        var parameters = new ExportExportTransactionsParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = "accounts",
            Type = ExportFileFilter.Csv,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExportExportTransactionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
