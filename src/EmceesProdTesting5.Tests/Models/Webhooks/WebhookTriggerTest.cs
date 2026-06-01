using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Webhooks;

namespace EmceesProdTesting5.Tests.Models.Webhooks;

public class WebhookTriggerTest : TestBase
{
    [Theory]
    [InlineData(WebhookTrigger.Any)]
    [InlineData(WebhookTrigger.StoreTransaction)]
    [InlineData(WebhookTrigger.UpdateTransaction)]
    [InlineData(WebhookTrigger.DestroyTransaction)]
    [InlineData(WebhookTrigger.StoreBudget)]
    [InlineData(WebhookTrigger.UpdateBudget)]
    [InlineData(WebhookTrigger.DestroyBudget)]
    [InlineData(WebhookTrigger.StoreUpdateBudgetLimit)]
    public void Validation_Works(WebhookTrigger rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookTrigger> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookTrigger>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookTrigger.Any)]
    [InlineData(WebhookTrigger.StoreTransaction)]
    [InlineData(WebhookTrigger.UpdateTransaction)]
    [InlineData(WebhookTrigger.DestroyTransaction)]
    [InlineData(WebhookTrigger.StoreBudget)]
    [InlineData(WebhookTrigger.UpdateBudget)]
    [InlineData(WebhookTrigger.DestroyBudget)]
    [InlineData(WebhookTrigger.StoreUpdateBudgetLimit)]
    public void SerializationRoundtrip_Works(WebhookTrigger rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookTrigger> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookTrigger>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookTrigger>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookTrigger>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
