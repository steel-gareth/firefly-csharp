using System;
using System.Net.Http;
using Firefly.Models.TransactionLinks;

namespace Firefly.Tests.Models.TransactionLinks;

public class TransactionLinkUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransactionLinkUpdateParams
        {
            ID = "123",
            InwardID = "131",
            LinkTypeID = "5",
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            OutwardID = "131",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedInwardID = "131";
        string expectedLinkTypeID = "5";
        string expectedLinkTypeName = "Is paid by";
        string expectedNotes = "Some example notes";
        string expectedOutwardID = "131";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedInwardID, parameters.InwardID);
        Assert.Equal(expectedLinkTypeID, parameters.LinkTypeID);
        Assert.Equal(expectedLinkTypeName, parameters.LinkTypeName);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedOutwardID, parameters.OutwardID);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransactionLinkUpdateParams
        {
            ID = "123",
            Notes = "Some example notes",
        };

        Assert.Null(parameters.InwardID);
        Assert.False(parameters.RawBodyData.ContainsKey("inward_id"));
        Assert.Null(parameters.LinkTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("link_type_id"));
        Assert.Null(parameters.LinkTypeName);
        Assert.False(parameters.RawBodyData.ContainsKey("link_type_name"));
        Assert.Null(parameters.OutwardID);
        Assert.False(parameters.RawBodyData.ContainsKey("outward_id"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TransactionLinkUpdateParams
        {
            ID = "123",
            Notes = "Some example notes",

            // Null should be interpreted as omitted for these properties
            InwardID = null,
            LinkTypeID = null,
            LinkTypeName = null,
            OutwardID = null,
            XTraceID = null,
        };

        Assert.Null(parameters.InwardID);
        Assert.False(parameters.RawBodyData.ContainsKey("inward_id"));
        Assert.Null(parameters.LinkTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("link_type_id"));
        Assert.Null(parameters.LinkTypeName);
        Assert.False(parameters.RawBodyData.ContainsKey("link_type_name"));
        Assert.Null(parameters.OutwardID);
        Assert.False(parameters.RawBodyData.ContainsKey("outward_id"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransactionLinkUpdateParams
        {
            ID = "123",
            InwardID = "131",
            LinkTypeID = "5",
            LinkTypeName = "Is paid by",
            OutwardID = "131",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TransactionLinkUpdateParams
        {
            ID = "123",
            InwardID = "131",
            LinkTypeID = "5",
            LinkTypeName = "Is paid by",
            OutwardID = "131",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        TransactionLinkUpdateParams parameters = new() { ID = "123" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/transaction-links/123"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TransactionLinkUpdateParams parameters = new()
        {
            ID = "123",
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
        var parameters = new TransactionLinkUpdateParams
        {
            ID = "123",
            InwardID = "131",
            LinkTypeID = "5",
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            OutwardID = "131",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        TransactionLinkUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
