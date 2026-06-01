using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<AutocompleteListRulesResponse, AutocompleteListRulesResponseFromRaw>)
)]
public sealed record class AutocompleteListRulesResponse : JsonModel
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
    /// Name of the rule found by an auto-complete search.
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
    /// Is the bill active or not?
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

    /// <summary>
    /// Description of the rule found by auto-complete.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Active;
        _ = this.Description;
    }

    public AutocompleteListRulesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListRulesResponse(
        AutocompleteListRulesResponse autocompleteListRulesResponse
    )
        : base(autocompleteListRulesResponse) { }
#pragma warning restore CS8618

    public AutocompleteListRulesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListRulesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListRulesResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListRulesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListRulesResponseFromRaw : IFromRawJson<AutocompleteListRulesResponse>
{
    /// <inheritdoc/>
    public AutocompleteListRulesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListRulesResponse.FromRawUnchecked(rawData);
}
