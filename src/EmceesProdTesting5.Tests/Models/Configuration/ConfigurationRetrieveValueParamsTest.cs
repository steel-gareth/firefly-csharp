using System;
using System.Net.Http;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Configuration;

namespace EmceesProdTesting5.Tests.Models.Configuration;

public class ConfigurationRetrieveValueParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConfigurationRetrieveValueParams
        {
            Name = ConfigValueFilter.ConfigurationIsDemoSite,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ApiEnum<string, ConfigValueFilter> expectedName = ConfigValueFilter.ConfigurationIsDemoSite;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConfigurationRetrieveValueParams
        {
            Name = ConfigValueFilter.ConfigurationIsDemoSite,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConfigurationRetrieveValueParams
        {
            Name = ConfigValueFilter.ConfigurationIsDemoSite,

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ConfigurationRetrieveValueParams parameters = new()
        {
            Name = ConfigValueFilter.ConfigurationIsDemoSite,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/configuration/configuration.is_demo_site"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ConfigurationRetrieveValueParams parameters = new()
        {
            Name = ConfigValueFilter.ConfigurationIsDemoSite,
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
        var parameters = new ConfigurationRetrieveValueParams
        {
            Name = ConfigValueFilter.ConfigurationIsDemoSite,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ConfigurationRetrieveValueParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
