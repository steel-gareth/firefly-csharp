using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Webhooks.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageRetrieveResponse, MessageRetrieveResponseFromRaw>))]
public sealed record class MessageRetrieveResponse : JsonModel
{
    public required WebhookMessage Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WebhookMessage>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public MessageRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveResponse(MessageRetrieveResponse messageRetrieveResponse)
        : base(messageRetrieveResponse) { }
#pragma warning restore CS8618

    public MessageRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageRetrieveResponse(WebhookMessage data)
        : this()
    {
        this.Data = data;
    }
}

class MessageRetrieveResponseFromRaw : IFromRawJson<MessageRetrieveResponse>
{
    /// <inheritdoc/>
    public MessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveResponse.FromRawUnchecked(rawData);
}
