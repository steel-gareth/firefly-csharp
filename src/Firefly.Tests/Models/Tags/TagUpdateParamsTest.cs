using System;
using System.Net.Http;
using Firefly.Models.Tags;

namespace Firefly.Tests.Models.Tags;

public class TagUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TagUpdateParams
        {
            Tag = "groceries",
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            TagValue = "expensive",
            ZoomLevel = 6,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedTag = "groceries";
        string expectedDate = "2026-04-01";
        string expectedDescription = "Tag for expensive stuff";
        double expectedLatitude = 51.983333;
        double expectedLongitude = 5.916667;
        string expectedTagValue = "expensive";
        int expectedZoomLevel = 6;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedTag, parameters.Tag);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedLatitude, parameters.Latitude);
        Assert.Equal(expectedLongitude, parameters.Longitude);
        Assert.Equal(expectedTagValue, parameters.TagValue);
        Assert.Equal(expectedZoomLevel, parameters.ZoomLevel);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TagUpdateParams
        {
            Tag = "groceries",
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            ZoomLevel = 6,
        };

        Assert.Null(parameters.TagValue);
        Assert.False(parameters.RawBodyData.ContainsKey("tag"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TagUpdateParams
        {
            Tag = "groceries",
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            ZoomLevel = 6,

            // Null should be interpreted as omitted for these properties
            TagValue = null,
            XTraceID = null,
        };

        Assert.Null(parameters.TagValue);
        Assert.False(parameters.RawBodyData.ContainsKey("tag"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TagUpdateParams
        {
            Tag = "groceries",
            TagValue = "expensive",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawBodyData.ContainsKey("date"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Latitude);
        Assert.False(parameters.RawBodyData.ContainsKey("latitude"));
        Assert.Null(parameters.Longitude);
        Assert.False(parameters.RawBodyData.ContainsKey("longitude"));
        Assert.Null(parameters.ZoomLevel);
        Assert.False(parameters.RawBodyData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TagUpdateParams
        {
            Tag = "groceries",
            TagValue = "expensive",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Date = null,
            Description = null,
            Latitude = null,
            Longitude = null,
            ZoomLevel = null,
        };

        Assert.Null(parameters.Date);
        Assert.True(parameters.RawBodyData.ContainsKey("date"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Latitude);
        Assert.True(parameters.RawBodyData.ContainsKey("latitude"));
        Assert.Null(parameters.Longitude);
        Assert.True(parameters.RawBodyData.ContainsKey("longitude"));
        Assert.Null(parameters.ZoomLevel);
        Assert.True(parameters.RawBodyData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void Url_Works()
    {
        TagUpdateParams parameters = new() { Tag = "groceries" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/tags/groceries"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TagUpdateParams parameters = new()
        {
            Tag = "groceries",
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
        var parameters = new TagUpdateParams
        {
            Tag = "groceries",
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            TagValue = "expensive",
            ZoomLevel = 6,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        TagUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
