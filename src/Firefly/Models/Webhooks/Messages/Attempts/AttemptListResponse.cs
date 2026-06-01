using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.Webhooks.Messages.Attempts;

[JsonConverter(typeof(JsonModelConverter<AttemptListResponse, AttemptListResponseFromRaw>))]
public sealed record class AttemptListResponse : JsonModel
{
    public required IReadOnlyList<WebhookAttempt> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WebhookAttempt>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WebhookAttempt>>(
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

    public AttemptListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttemptListResponse(AttemptListResponse attemptListResponse)
        : base(attemptListResponse) { }
#pragma warning restore CS8618

    public AttemptListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttemptListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttemptListResponseFromRaw.FromRawUnchecked"/>
    public static AttemptListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttemptListResponseFromRaw : IFromRawJson<AttemptListResponse>
{
    /// <inheritdoc/>
    public AttemptListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AttemptListResponse.FromRawUnchecked(rawData);
}
