using System;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Configuration;

namespace Firefly.Tests.Models.Configuration;

public class ConfigurationUpdateValueParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConfigurationUpdateValueParams
        {
            Name = Name.ConfigurationIsDemoSite,
            Value = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ApiEnum<string, Name> expectedName = Name.ConfigurationIsDemoSite;
        PolymorphicProperty expectedValue = true;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedValue, parameters.Value);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConfigurationUpdateValueParams
        {
            Name = Name.ConfigurationIsDemoSite,
            Value = true,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConfigurationUpdateValueParams
        {
            Name = Name.ConfigurationIsDemoSite,
            Value = true,

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        ConfigurationUpdateValueParams parameters = new()
        {
            Name = Name.ConfigurationIsDemoSite,
            Value = true,
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
        ConfigurationUpdateValueParams parameters = new()
        {
            Name = Name.ConfigurationIsDemoSite,
            Value = true,
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
        var parameters = new ConfigurationUpdateValueParams
        {
            Name = Name.ConfigurationIsDemoSite,
            Value = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ConfigurationUpdateValueParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class NameTest : TestBase
{
    [Theory]
    [InlineData(Name.ConfigurationIsDemoSite)]
    [InlineData(Name.ConfigurationPermissionUpdateCheck)]
    [InlineData(Name.ConfigurationLastUpdateCheck)]
    [InlineData(Name.ConfigurationSingleUserMode)]
    [InlineData(Name.ConfigurationEnableExchangeRates)]
    [InlineData(Name.ConfigurationUseRunningBalance)]
    [InlineData(Name.ConfigurationEnableExternalMap)]
    [InlineData(Name.ConfigurationEnableExternalRates)]
    [InlineData(Name.ConfigurationAllowWebhooks)]
    [InlineData(Name.ConfigurationValidUrlProtocols)]
    public void Validation_Works(Name rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Name> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Name>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Name.ConfigurationIsDemoSite)]
    [InlineData(Name.ConfigurationPermissionUpdateCheck)]
    [InlineData(Name.ConfigurationLastUpdateCheck)]
    [InlineData(Name.ConfigurationSingleUserMode)]
    [InlineData(Name.ConfigurationEnableExchangeRates)]
    [InlineData(Name.ConfigurationUseRunningBalance)]
    [InlineData(Name.ConfigurationEnableExternalMap)]
    [InlineData(Name.ConfigurationEnableExternalRates)]
    [InlineData(Name.ConfigurationAllowWebhooks)]
    [InlineData(Name.ConfigurationValidUrlProtocols)]
    public void SerializationRoundtrip_Works(Name rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Name> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Name>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Name>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Name>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
