using System;
using System.Net.Http;
using Firefly.Models.Configuration;
using Firefly.Models.Preferences;

namespace Firefly.Tests.Models.Preferences;

public class PreferenceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreferenceUpdateParams
        {
            Name = "currencyPreference",
            Data = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedName = "currencyPreference";
        PolymorphicProperty expectedData = true;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedData, parameters.Data);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PreferenceUpdateParams { Name = "currencyPreference", Data = true };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PreferenceUpdateParams
        {
            Name = "currencyPreference",
            Data = true,

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        PreferenceUpdateParams parameters = new() { Name = "currencyPreference", Data = true };

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
        PreferenceUpdateParams parameters = new()
        {
            Name = "currencyPreference",
            Data = true,
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
        var parameters = new PreferenceUpdateParams
        {
            Name = "currencyPreference",
            Data = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        PreferenceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
