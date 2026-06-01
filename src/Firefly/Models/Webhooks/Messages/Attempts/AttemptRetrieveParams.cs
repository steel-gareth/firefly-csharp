using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;

namespace Firefly.Models.Webhooks.Messages.Attempts;

/// <summary>
/// When a webhook message fails to send it will store the failure in an "attempt".
/// You can view and analyse these. Webhooks messages that receive too many attempts
/// (failures) will not be fired. You must first clear out old attempts and try again.
/// This endpoint shows you the details of a single attempt. The ID of the attempt
/// must match the corresponding webhook and webhook message.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AttemptRetrieveParams : ParamsBase
{
    public required string ID { get; init; }

    public required long MessageID { get; init; }

    public long? AttemptID { get; init; }

    public string? XTraceID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-Trace-Id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-Trace-Id", value);
        }
    }

    public AttemptRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttemptRetrieveParams(AttemptRetrieveParams attemptRetrieveParams)
        : base(attemptRetrieveParams)
    {
        this.ID = attemptRetrieveParams.ID;
        this.MessageID = attemptRetrieveParams.MessageID;
        this.AttemptID = attemptRetrieveParams.AttemptID;
    }
#pragma warning restore CS8618

    public AttemptRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttemptRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id,
        long messageID,
        long attemptID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
        this.MessageID = messageID;
        this.AttemptID = attemptID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AttemptRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id,
        long messageID,
        long attemptID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id,
            messageID,
            attemptID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["MessageID"] = JsonSerializer.SerializeToElement(this.MessageID),
                    ["AttemptID"] = JsonSerializer.SerializeToElement(this.AttemptID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AttemptRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && this.MessageID.Equals(other.MessageID)
            && (this.AttemptID?.Equals(other.AttemptID) ?? other.AttemptID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/webhooks/{0}/messages/{1}/attempts/{2}",
                    this.ID,
                    this.MessageID,
                    this.AttemptID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        request.Headers.Add("Accept", "application/vnd.api+json");
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
