using System.Text.Json;
using Firefly.Core;
using Firefly.Models.About;

namespace Firefly.Tests.Models.About;

public class AboutRetrieveInfoResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AboutRetrieveInfoResponse
        {
            Data = new()
            {
                ApiVersion = "6.6.2",
                Driver = "mysql",
                Os = "Linux",
                PhpVersion = "8.1.5",
                Version = "6.6.2",
            },
        };

        AboutRetrieveInfoResponseData expectedData = new()
        {
            ApiVersion = "6.6.2",
            Driver = "mysql",
            Os = "Linux",
            PhpVersion = "8.1.5",
            Version = "6.6.2",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AboutRetrieveInfoResponse
        {
            Data = new()
            {
                ApiVersion = "6.6.2",
                Driver = "mysql",
                Os = "Linux",
                PhpVersion = "8.1.5",
                Version = "6.6.2",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AboutRetrieveInfoResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AboutRetrieveInfoResponse
        {
            Data = new()
            {
                ApiVersion = "6.6.2",
                Driver = "mysql",
                Os = "Linux",
                PhpVersion = "8.1.5",
                Version = "6.6.2",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AboutRetrieveInfoResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AboutRetrieveInfoResponseData expectedData = new()
        {
            ApiVersion = "6.6.2",
            Driver = "mysql",
            Os = "Linux",
            PhpVersion = "8.1.5",
            Version = "6.6.2",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AboutRetrieveInfoResponse
        {
            Data = new()
            {
                ApiVersion = "6.6.2",
                Driver = "mysql",
                Os = "Linux",
                PhpVersion = "8.1.5",
                Version = "6.6.2",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AboutRetrieveInfoResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AboutRetrieveInfoResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AboutRetrieveInfoResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AboutRetrieveInfoResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AboutRetrieveInfoResponse
        {
            Data = new()
            {
                ApiVersion = "6.6.2",
                Driver = "mysql",
                Os = "Linux",
                PhpVersion = "8.1.5",
                Version = "6.6.2",
            },
        };

        AboutRetrieveInfoResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AboutRetrieveInfoResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AboutRetrieveInfoResponseData
        {
            ApiVersion = "6.6.2",
            Driver = "mysql",
            Os = "Linux",
            PhpVersion = "8.1.5",
            Version = "6.6.2",
        };

        string expectedApiVersion = "6.6.2";
        string expectedDriver = "mysql";
        string expectedOs = "Linux";
        string expectedPhpVersion = "8.1.5";
        string expectedVersion = "6.6.2";

        Assert.Equal(expectedApiVersion, model.ApiVersion);
        Assert.Equal(expectedDriver, model.Driver);
        Assert.Equal(expectedOs, model.Os);
        Assert.Equal(expectedPhpVersion, model.PhpVersion);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AboutRetrieveInfoResponseData
        {
            ApiVersion = "6.6.2",
            Driver = "mysql",
            Os = "Linux",
            PhpVersion = "8.1.5",
            Version = "6.6.2",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AboutRetrieveInfoResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AboutRetrieveInfoResponseData
        {
            ApiVersion = "6.6.2",
            Driver = "mysql",
            Os = "Linux",
            PhpVersion = "8.1.5",
            Version = "6.6.2",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AboutRetrieveInfoResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiVersion = "6.6.2";
        string expectedDriver = "mysql";
        string expectedOs = "Linux";
        string expectedPhpVersion = "8.1.5";
        string expectedVersion = "6.6.2";

        Assert.Equal(expectedApiVersion, deserialized.ApiVersion);
        Assert.Equal(expectedDriver, deserialized.Driver);
        Assert.Equal(expectedOs, deserialized.Os);
        Assert.Equal(expectedPhpVersion, deserialized.PhpVersion);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AboutRetrieveInfoResponseData
        {
            ApiVersion = "6.6.2",
            Driver = "mysql",
            Os = "Linux",
            PhpVersion = "8.1.5",
            Version = "6.6.2",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AboutRetrieveInfoResponseData { };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("api_version"));
        Assert.Null(model.Driver);
        Assert.False(model.RawData.ContainsKey("driver"));
        Assert.Null(model.Os);
        Assert.False(model.RawData.ContainsKey("os"));
        Assert.Null(model.PhpVersion);
        Assert.False(model.RawData.ContainsKey("php_version"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AboutRetrieveInfoResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AboutRetrieveInfoResponseData
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            Driver = null,
            Os = null,
            PhpVersion = null,
            Version = null,
        };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("api_version"));
        Assert.Null(model.Driver);
        Assert.False(model.RawData.ContainsKey("driver"));
        Assert.Null(model.Os);
        Assert.False(model.RawData.ContainsKey("os"));
        Assert.Null(model.PhpVersion);
        Assert.False(model.RawData.ContainsKey("php_version"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AboutRetrieveInfoResponseData
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            Driver = null,
            Os = null,
            PhpVersion = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AboutRetrieveInfoResponseData
        {
            ApiVersion = "6.6.2",
            Driver = "mysql",
            Os = "Linux",
            PhpVersion = "8.1.5",
            Version = "6.6.2",
        };

        AboutRetrieveInfoResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
