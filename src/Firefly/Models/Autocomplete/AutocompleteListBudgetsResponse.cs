using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListBudgetsResponse,
        AutocompleteListBudgetsResponseFromRaw
    >)
)]
public sealed record class AutocompleteListBudgetsResponse : JsonModel
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

    /// <summary>
    /// Name of the budget found by an auto-complete search.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Is the budget active or not?
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Active;
    }

    public AutocompleteListBudgetsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListBudgetsResponse(
        AutocompleteListBudgetsResponse autocompleteListBudgetsResponse
    )
        : base(autocompleteListBudgetsResponse) { }
#pragma warning restore CS8618

    public AutocompleteListBudgetsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListBudgetsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListBudgetsResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListBudgetsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListBudgetsResponseFromRaw : IFromRawJson<AutocompleteListBudgetsResponse>
{
    /// <inheritdoc/>
    public AutocompleteListBudgetsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListBudgetsResponse.FromRawUnchecked(rawData);
}
