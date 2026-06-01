using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Webhooks.Messages.Attempts;

[JsonConverter(typeof(JsonModelConverter<WebhookAttempt, WebhookAttemptFromRaw>))]
public sealed record class WebhookAttempt : JsonModel
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

    public WebhookAttempt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookAttempt(WebhookAttempt webhookAttempt)
        : base(webhookAttempt) { }
#pragma warning restore CS8618

    public WebhookAttempt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookAttempt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookAttemptFromRaw.FromRawUnchecked"/>
    public static WebhookAttempt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookAttemptFromRaw : IFromRawJson<WebhookAttempt>
{
    /// <inheritdoc/>
    public WebhookAttempt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookAttempt.FromRawUnchecked(rawData);
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
    /// Internal log for this attempt. May contain sensitive user data.
    /// </summary>
    public string? Logs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logs");
        }
        init { this._rawData.Set("logs", value); }
    }

    /// <summary>
    /// Webhook receiver response for this attempt, if any. May contain sensitive
    /// user data.
    /// </summary>
    public string? Response
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("response");
        }
        init { this._rawData.Set("response", value); }
    }

    /// <summary>
    /// The HTTP status code of the error, if any.
    /// </summary>
    public int? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("status_code");
        }
        init { this._rawData.Set("status_code", value); }
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
    /// The ID of the webhook message this attempt belongs to.
    /// </summary>
    public string? WebhookMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_message_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhook_message_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Logs;
        _ = this.Response;
        _ = this.StatusCode;
        _ = this.UpdatedAt;
        _ = this.WebhookMessageID;
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
