using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Webhooks;

/// <summary>
/// Format of the delivered response.
/// </summary>
[JsonConverter(typeof(WebhookDeliveryConverter))]
public enum WebhookDelivery
{
    Json,
}

sealed class WebhookDeliveryConverter : JsonConverter<WebhookDelivery>
{
    public override WebhookDelivery Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "JSON" => WebhookDelivery.Json,
            _ => (WebhookDelivery)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookDelivery value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookDelivery.Json => "JSON",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
