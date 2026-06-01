using System;
using System.Net.Http;
using EmceesProdTesting5.Models.TransactionLinks;

namespace EmceesProdTesting5.Tests.Models.TransactionLinks;

public class TransactionLinkCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransactionLinkCreateParams
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedInwardID = "131";
        string expectedLinkTypeID = "5";
        string expectedOutwardID = "131";
        string expectedLinkTypeName = "Is paid by";
        string expectedNotes = "Some example notes";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedInwardID, parameters.InwardID);
        Assert.Equal(expectedLinkTypeID, parameters.LinkTypeID);
        Assert.Equal(expectedOutwardID, parameters.OutwardID);
        Assert.Equal(expectedLinkTypeName, parameters.LinkTypeName);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransactionLinkCreateParams
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            Notes = "Some example notes",
        };

        Assert.Null(parameters.LinkTypeName);
        Assert.False(parameters.RawBodyData.ContainsKey("link_type_name"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TransactionLinkCreateParams
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            Notes = "Some example notes",

            // Null should be interpreted as omitted for these properties
            LinkTypeName = null,
            XTraceID = null,
        };

        Assert.Null(parameters.LinkTypeName);
        Assert.False(parameters.RawBodyData.ContainsKey("link_type_name"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransactionLinkCreateParams
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            LinkTypeName = "Is paid by",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TransactionLinkCreateParams
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            LinkTypeName = "Is paid by",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        TransactionLinkCreateParams parameters = new()
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/transaction-links"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TransactionLinkCreateParams parameters = new()
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
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
        var parameters = new TransactionLinkCreateParams
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        TransactionLinkCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
