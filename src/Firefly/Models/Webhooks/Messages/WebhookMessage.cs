using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Webhooks.Messages;

[JsonConverter(typeof(JsonModelConverter<WebhookMessage, WebhookMessageFromRaw>))]
public sealed record class WebhookMessage : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required Attributes Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attributes>("attributes");
        }
        init { this._rawData.Set("attributes", value); }
    }

    /// <summary>
    /// Immutable value
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Attributes.Validate();
        _ = this.Type;
    }

    public WebhookMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookMessage(WebhookMessage webhookMessage)
        : base(webhookMessage) { }
#pragma warning restore CS8618

    public WebhookMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookMessageFromRaw.FromRawUnchecked"/>
    public static WebhookMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookMessageFromRaw : IFromRawJson<WebhookMessage>
{
    /// <inheritdoc/>
    public WebhookMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// If this message has errored out.
    /// </summary>
    public bool? Errored
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("errored");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errored", value);
        }
    }

    /// <summary>
    /// The actual message that is sent or will be sent as JSON string.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// If this message is sent yet.
    /// </summary>
    public bool? Sent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("sent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sent", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// Long UUID string for identification of this webhook message.
    /// </summary>
    public string? Uuid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uuid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uuid", value);
        }
    }

    /// <summary>
    /// The ID of the webhook this message belongs to.
    /// </summary>
    public string? WebhookID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhook_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Errored;
        _ = this.Message;
        _ = this.Sent;
        _ = this.UpdatedAt;
        _ = this.Uuid;
        _ = this.WebhookID;
    }

    public Attributes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attributes(Attributes attributes)
        : base(attributes) { }
#pragma warning restore CS8618

    public Attributes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attributes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttributesFromRaw.FromRawUnchecked"/>
    public static Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttributesFromRaw : IFromRawJson<Attributes>
{
    /// <inheritdoc/>
    public Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attributes.FromRawUnchecked(rawData);
}
