using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Webhooks;

/// <summary>
/// Indicator for what Firefly III will deliver to the webhook URL.
/// </summary>
[JsonConverter(typeof(WebhookResponseConverter))]
public enum WebhookResponse
{
    Transactions,
    Accounts,
    Budget,
    Relevant,
    None,
}

sealed class WebhookResponseConverter : JsonConverter<WebhookResponse>
{
    public override WebhookResponse Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "TRANSACTIONS" => WebhookResponse.Transactions,
            "ACCOUNTS" => WebhookResponse.Accounts,
            "BUDGET" => WebhookResponse.Budget,
            "RELEVANT" => WebhookResponse.Relevant,
            "NONE" => WebhookResponse.None,
            _ => (WebhookResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookResponse.Transactions => "TRANSACTIONS",
                WebhookResponse.Accounts => "ACCOUNTS",
                WebhookResponse.Budget => "BUDGET",
                WebhookResponse.Relevant => "RELEVANT",
                WebhookResponse.None => "NONE",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
