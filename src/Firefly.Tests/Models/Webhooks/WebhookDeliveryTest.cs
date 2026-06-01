using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Webhooks;

namespace Firefly.Tests.Models.Webhooks;

public class WebhookDeliveryTest : TestBase
{
    [Theory]
    [InlineData(WebhookDelivery.Json)]
    public void Validation_Works(WebhookDelivery rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookDelivery> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookDelivery>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookDelivery.Json)]
    public void SerializationRoundtrip_Works(WebhookDelivery rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookDelivery> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookDelivery>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookDelivery>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookDelivery>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
