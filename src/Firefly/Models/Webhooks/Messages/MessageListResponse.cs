using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.Webhooks.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageListResponse, MessageListResponseFromRaw>))]
public sealed record class MessageListResponse : JsonModel
{
    public required IReadOnlyList<WebhookMessage> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WebhookMessage>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WebhookMessage>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Meta Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>("meta");
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public MessageListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageListResponse(MessageListResponse messageListResponse)
        : base(messageListResponse) { }
#pragma warning restore CS8618

    public MessageListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageListResponseFromRaw.FromRawUnchecked"/>
    public static MessageListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageListResponseFromRaw : IFromRawJson<MessageListResponse>
{
    /// <inheritdoc/>
    public MessageListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageListResponse.FromRawUnchecked(rawData);
}
