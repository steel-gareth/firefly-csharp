using System;
using System.Net.Http;
using Firefly.Models.Summary;

namespace Firefly.Tests.Models.Summary;

public class SummaryRetrieveBasicParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SummaryRetrieveBasicParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            CurrencyCode = "currency_code",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedEnd = "2019-12-27";
        string expectedStart = "2019-12-27";
        string expectedCurrencyCode = "currency_code";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.Equal(expectedCurrencyCode, parameters.CurrencyCode);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SummaryRetrieveBasicParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
        };

        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawQueryData.ContainsKey("currency_code"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SummaryRetrieveBasicParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            XTraceID = null,
        };

        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawQueryData.ContainsKey("currency_code"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        SummaryRetrieveBasicParams parameters = new()
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            CurrencyCode = "currency_code",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/summary/basic?end=2019-12-27&start=2019-12-27&currency_code=currency_code"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SummaryRetrieveBasicParams parameters = new()
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
        var parameters = new SummaryRetrieveBasicParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            CurrencyCode = "currency_code",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        SummaryRetrieveBasicParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
