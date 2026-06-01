using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.Recurrences;

[JsonConverter(typeof(JsonModelConverter<RecurrenceArray, RecurrenceArrayFromRaw>))]
public sealed record class RecurrenceArray : JsonModel
{
    public required IReadOnlyList<RecurrenceRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RecurrenceRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RecurrenceRead>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PageLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageLink>("links");
        }
        init { this._rawData.Set("links", value); }
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
        this.Links.Validate();
        this.Meta.Validate();
    }

    public RecurrenceArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecurrenceArray(RecurrenceArray recurrenceArray)
        : base(recurrenceArray) { }
#pragma warning restore CS8618

    public RecurrenceArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurrenceArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurrenceArrayFromRaw.FromRawUnchecked"/>
    public static RecurrenceArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurrenceArrayFromRaw : IFromRawJson<RecurrenceArray>
{
    /// <inheritdoc/>
    public RecurrenceArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RecurrenceArray.FromRawUnchecked(rawData);
}
