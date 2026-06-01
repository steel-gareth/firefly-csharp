using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using Attachments = EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Models.TransactionLinks;

[JsonConverter(typeof(JsonModelConverter<TransactionLinkRead, TransactionLinkReadFromRaw>))]
public sealed record class TransactionLinkRead : JsonModel
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

    public required Attachments::ObjectLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attachments::ObjectLink>("links");
        }
        init { this._rawData.Set("links", value); }
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
        this.Links.Validate();
        _ = this.Type;
    }

    public TransactionLinkRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionLinkRead(TransactionLinkRead transactionLinkRead)
        : base(transactionLinkRead) { }
#pragma warning restore CS8618

    public TransactionLinkRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionLinkRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionLinkReadFromRaw.FromRawUnchecked"/>
    public static TransactionLinkRead FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionLinkReadFromRaw : IFromRawJson<TransactionLinkRead>
{
    /// <inheritdoc/>
    public TransactionLinkRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TransactionLinkRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    /// <summary>
    /// The inward transaction transaction_journal_id for the link. This becomes the
    /// 'is paid by' transaction of the set.
    /// </summary>
    public required string InwardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inward_id");
        }
        init { this._rawData.Set("inward_id", value); }
    }

    /// <summary>
    /// The link type ID to use. You can also use the link_type_name field.
    /// </summary>
    public required string LinkTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("link_type_id");
        }
        init { this._rawData.Set("link_type_id", value); }
    }

    /// <summary>
    /// The outward transaction transaction_journal_id for the link. This becomes
    /// the 'pays for' transaction of the set.
    /// </summary>
    public required string OutwardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outward_id");
        }
        init { this._rawData.Set("outward_id", value); }
    }

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
    /// The link type name to use. You can also use the link_type_id field.
    /// </summary>
    public string? LinkTypeName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("link_type_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("link_type_name", value);
        }
    }

    /// <summary>
    /// Optional. Some notes.
    /// </summary>
    public string? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notes");
        }
        init { this._rawData.Set("notes", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InwardID;
        _ = this.LinkTypeID;
        _ = this.OutwardID;
        _ = this.CreatedAt;
        _ = this.LinkTypeName;
        _ = this.Notes;
        _ = this.UpdatedAt;
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
