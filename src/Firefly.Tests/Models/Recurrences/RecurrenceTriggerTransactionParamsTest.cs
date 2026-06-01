using System;
using System.Net.Http;
using Firefly.Models.Recurrences;

namespace Firefly.Tests.Models.Recurrences;

public class RecurrenceTriggerTransactionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RecurrenceTriggerTransactionParams
        {
            ID = "123",
            Date = "2019-12-27",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedDate = "2019-12-27";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RecurrenceTriggerTransactionParams { ID = "123", Date = "2019-12-27" };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RecurrenceTriggerTransactionParams
        {
            ID = "123",
            Date = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        RecurrenceTriggerTransactionParams parameters = new() { ID = "123", Date = "2019-12-27" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/recurrences/123/trigger?date=2019-12-27"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RecurrenceTriggerTransactionParams parameters = new()
        {
            ID = "123",
            Date = "2019-12-27",
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
        var parameters = new RecurrenceTriggerTransactionParams
        {
            ID = "123",
            Date = "2019-12-27",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        RecurrenceTriggerTransactionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
