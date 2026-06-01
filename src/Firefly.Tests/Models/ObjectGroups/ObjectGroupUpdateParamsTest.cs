using System;
using System.Net.Http;
using Firefly.Models.ObjectGroups;

namespace Firefly.Tests.Models.ObjectGroups;

public class ObjectGroupUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectGroupUpdateParams
        {
            ID = "123",
            Title = "My object group",
            Order = 1,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedTitle = "My object group";
        int expectedOrder = 1;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ObjectGroupUpdateParams { ID = "123", Title = "My object group" };

        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ObjectGroupUpdateParams
        {
            ID = "123",
            Title = "My object group",

            // Null should be interpreted as omitted for these properties
            Order = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ObjectGroupUpdateParams parameters = new() { ID = "123", Title = "My object group" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/object-groups/123"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ObjectGroupUpdateParams parameters = new()
        {
            ID = "123",
            Title = "My object group",
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
        var parameters = new ObjectGroupUpdateParams
        {
            ID = "123",
            Title = "My object group",
            Order = 1,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ObjectGroupUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
