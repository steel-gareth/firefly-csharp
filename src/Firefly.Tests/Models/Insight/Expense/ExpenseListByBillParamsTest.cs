using System;
using System.Collections.Generic;
using System.Net.Http;
using Firefly.Models.Insight.Expense;

namespace Firefly.Tests.Models.Insight.Expense;

public class ExpenseListByBillParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExpenseListByBillParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
            Bills = [1, 2, 3],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedEnd = "2019-12-27";
        string expectedStart = "2019-12-27";
        List<long> expectedAccounts = [1, 2, 3];
        List<long> expectedBills = [1, 2, 3];
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.NotNull(parameters.Accounts);
        Assert.Equal(expectedAccounts.Count, parameters.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], parameters.Accounts[i]);
        }
        Assert.NotNull(parameters.Bills);
        Assert.Equal(expectedBills.Count, parameters.Bills.Count);
        for (int i = 0; i < expectedBills.Count; i++)
        {
            Assert.Equal(expectedBills[i], parameters.Bills[i]);
        }
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExpenseListByBillParams { End = "2019-12-27", Start = "2019-12-27" };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.Bills);
        Assert.False(parameters.RawQueryData.ContainsKey("bills"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExpenseListByBillParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            Bills = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.Bills);
        Assert.False(parameters.RawQueryData.ContainsKey("bills"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExpenseListByBillParams parameters = new()
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
            Bills = [1, 2, 3],
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/insight/expense/bill?end=2019-12-27&start=2019-12-27&accounts=1%2c2%2c3&bills=1%2c2%2c3"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExpenseListByBillParams parameters = new()
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
        var parameters = new ExpenseListByBillParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
            Bills = [1, 2, 3],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ExpenseListByBillParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
