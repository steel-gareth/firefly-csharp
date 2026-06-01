using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Webhooks;

namespace EmceesProdTesting5.Tests.Models.Webhooks;

public class WebhookResponseTest : TestBase
{
    [Theory]
    [InlineData(WebhookResponse.Transactions)]
    [InlineData(WebhookResponse.Accounts)]
    [InlineData(WebhookResponse.Budget)]
    [InlineData(WebhookResponse.Relevant)]
    [InlineData(WebhookResponse.None)]
    public void Validation_Works(WebhookResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookResponse>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookResponse.Transactions)]
    [InlineData(WebhookResponse.Accounts)]
    [InlineData(WebhookResponse.Budget)]
    [InlineData(WebhookResponse.Relevant)]
    [InlineData(WebhookResponse.None)]
    public void SerializationRoundtrip_Works(WebhookResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookResponse>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookResponse>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookResponse>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
