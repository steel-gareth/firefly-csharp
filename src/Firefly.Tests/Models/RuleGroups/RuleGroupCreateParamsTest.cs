using System;
using System.Net.Http;
using Firefly.Models.RuleGroups;

namespace Firefly.Tests.Models.RuleGroups;

public class RuleGroupCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleGroupCreateParams
        {
            Title = "Default rule group",
            Active = true,
            Description = "Description of this rule group",
            Order = 4,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedTitle = "Default rule group";
        bool expectedActive = true;
        string expectedDescription = "Description of this rule group";
        int expectedOrder = 4;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleGroupCreateParams
        {
            Title = "Default rule group",
            Description = "Description of this rule group",
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RuleGroupCreateParams
        {
            Title = "Default rule group",
            Description = "Description of this rule group",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleGroupCreateParams
        {
            Title = "Default rule group",
            Active = true,
            Order = 4,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RuleGroupCreateParams
        {
            Title = "Default rule group",
            Active = true,
            Order = 4,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        RuleGroupCreateParams parameters = new() { Title = "Default rule group" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/rule-groups"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RuleGroupCreateParams parameters = new()
        {
            Title = "Default rule group",
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
        var parameters = new RuleGroupCreateParams
        {
            Title = "Default rule group",
            Active = true,
            Description = "Description of this rule group",
            Order = 4,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        RuleGroupCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
