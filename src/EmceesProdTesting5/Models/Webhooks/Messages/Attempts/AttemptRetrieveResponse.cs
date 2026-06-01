using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Webhooks.Messages.Attempts;

[JsonConverter(typeof(JsonModelConverter<AttemptRetrieveResponse, AttemptRetrieveResponseFromRaw>))]
public sealed record class AttemptRetrieveResponse : JsonModel
{
    public required WebhookAttempt Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WebhookAttempt>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AttemptRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttemptRetrieveResponse(AttemptRetrieveResponse attemptRetrieveResponse)
        : base(attemptRetrieveResponse) { }
#pragma warning restore CS8618

    public AttemptRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttemptRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttemptRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AttemptRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AttemptRetrieveResponse(WebhookAttempt data)
        : this()
    {
        this.Data = data;
    }
}

class AttemptRetrieveResponseFromRaw : IFromRawJson<AttemptRetrieveResponse>
{
    /// <inheritdoc/>
    public AttemptRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AttemptRetrieveResponse.FromRawUnchecked(rawData);
}
