using System;
using System.Net.Http;
using Firefly.Models.UserGroups;

namespace Firefly.Tests.Models.UserGroups;

public class UserGroupUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserGroupUpdateParams
        {
            ID = "1",
            Title = "New user group title",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyID = "1",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "1";
        string expectedTitle = "New user group title";
        string expectedPrimaryCurrencyCode = "EUR";
        string expectedPrimaryCurrencyID = "1";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedPrimaryCurrencyCode, parameters.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyID, parameters.PrimaryCurrencyID);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserGroupUpdateParams { ID = "1", Title = "New user group title" };

        Assert.Null(parameters.PrimaryCurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("primary_currency_code"));
        Assert.Null(parameters.PrimaryCurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("primary_currency_id"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserGroupUpdateParams
        {
            ID = "1",
            Title = "New user group title",

            // Null should be interpreted as omitted for these properties
            PrimaryCurrencyCode = null,
            PrimaryCurrencyID = null,
            XTraceID = null,
        };

        Assert.Null(parameters.PrimaryCurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("primary_currency_code"));
        Assert.Null(parameters.PrimaryCurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("primary_currency_id"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        UserGroupUpdateParams parameters = new() { ID = "1", Title = "New user group title" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/user-groups/1"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserGroupUpdateParams parameters = new()
        {
            ID = "1",
            Title = "New user group title",
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
        var parameters = new UserGroupUpdateParams
        {
            ID = "1",
            Title = "New user group title",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyID = "1",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        UserGroupUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
