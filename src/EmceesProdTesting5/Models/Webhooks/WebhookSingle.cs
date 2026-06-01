using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookSingle, WebhookSingleFromRaw>))]
public sealed record class WebhookSingle : JsonModel
{
    public required Webhook Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Webhook>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public WebhookSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookSingle(WebhookSingle webhookSingle)
        : base(webhookSingle) { }
#pragma warning restore CS8618

    public WebhookSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookSingleFromRaw.FromRawUnchecked"/>
    public static WebhookSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookSingle(Webhook data)
        : this()
    {
        this.Data = data;
    }
}

class WebhookSingleFromRaw : IFromRawJson<WebhookSingle>
{
    /// <inheritdoc/>
    public WebhookSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookSingle.FromRawUnchecked(rawData);
}
