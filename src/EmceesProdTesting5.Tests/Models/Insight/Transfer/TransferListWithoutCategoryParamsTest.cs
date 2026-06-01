using System;
using System.Collections.Generic;
using System.Net.Http;
using EmceesProdTesting5.Models.Insight.Transfer;

namespace EmceesProdTesting5.Tests.Models.Insight.Transfer;

public class TransferListWithoutCategoryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransferListWithoutCategoryParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedEnd = "2019-12-27";
        string expectedStart = "2019-12-27";
        List<long> expectedAccounts = [1, 2, 3];
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.NotNull(parameters.Accounts);
        Assert.Equal(expectedAccounts.Count, parameters.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], parameters.Accounts[i]);
        }
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransferListWithoutCategoryParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TransferListWithoutCategoryParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        TransferListWithoutCategoryParams parameters = new()
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/insight/transfer/no-category?end=2019-12-27&start=2019-12-27&accounts=1%2c2%2c3"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TransferListWithoutCategoryParams parameters = new()
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
        var parameters = new TransferListWithoutCategoryParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        TransferListWithoutCategoryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
