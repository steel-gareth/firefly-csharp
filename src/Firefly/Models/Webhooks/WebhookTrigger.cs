using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Webhooks;

/// <summary>
/// The trigger for the webhook.
/// </summary>
[JsonConverter(typeof(WebhookTriggerConverter))]
public enum WebhookTrigger
{
    Any,
    StoreTransaction,
    UpdateTransaction,
    DestroyTransaction,
    StoreBudget,
    UpdateBudget,
    DestroyBudget,
    StoreUpdateBudgetLimit,
}

sealed class WebhookTriggerConverter : JsonConverter<WebhookTrigger>
{
    public override WebhookTrigger Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ANY" => WebhookTrigger.Any,
            "STORE_TRANSACTION" => WebhookTrigger.StoreTransaction,
            "UPDATE_TRANSACTION" => WebhookTrigger.UpdateTransaction,
            "DESTROY_TRANSACTION" => WebhookTrigger.DestroyTransaction,
            "STORE_BUDGET" => WebhookTrigger.StoreBudget,
            "UPDATE_BUDGET" => WebhookTrigger.UpdateBudget,
            "DESTROY_BUDGET" => WebhookTrigger.DestroyBudget,
            "STORE_UPDATE_BUDGET_LIMIT" => WebhookTrigger.StoreUpdateBudgetLimit,
            _ => (WebhookTrigger)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookTrigger value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookTrigger.Any => "ANY",
                WebhookTrigger.StoreTransaction => "STORE_TRANSACTION",
                WebhookTrigger.UpdateTransaction => "UPDATE_TRANSACTION",
                WebhookTrigger.DestroyTransaction => "DESTROY_TRANSACTION",
                WebhookTrigger.StoreBudget => "STORE_BUDGET",
                WebhookTrigger.UpdateBudget => "UPDATE_BUDGET",
                WebhookTrigger.DestroyBudget => "DESTROY_BUDGET",
                WebhookTrigger.StoreUpdateBudgetLimit => "STORE_UPDATE_BUDGET_LIMIT",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
