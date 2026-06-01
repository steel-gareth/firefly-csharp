using System;
using System.Net.Http;
using EmceesProdTesting5.Models.Preferences;

namespace EmceesProdTesting5.Tests.Models.Preferences;

public class PreferenceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreferenceRetrieveParams
        {
            Name = "currencyPreference",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedName = "currencyPreference";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PreferenceRetrieveParams { Name = "currencyPreference" };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PreferenceRetrieveParams
        {
            Name = "currencyPreference",

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        PreferenceRetrieveParams parameters = new() { Name = "currencyPreference" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://demo.firefly-iii.org/api/v1/preferences/currencyPreference"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PreferenceRetrieveParams parameters = new()
        {
            Name = "currencyPreference",
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
        var parameters = new PreferenceRetrieveParams
        {
            Name = "currencyPreference",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        PreferenceRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
