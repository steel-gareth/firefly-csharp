using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Categories;

[JsonConverter(typeof(JsonModelConverter<CategorySingle, CategorySingleFromRaw>))]
public sealed record class CategorySingle : JsonModel
{
    public required CategoryRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CategoryRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CategorySingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CategorySingle(CategorySingle categorySingle)
        : base(categorySingle) { }
#pragma warning restore CS8618

    public CategorySingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategorySingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategorySingleFromRaw.FromRawUnchecked"/>
    public static CategorySingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CategorySingle(CategoryRead data)
        : this()
    {
        this.Data = data;
    }
}

class CategorySingleFromRaw : IFromRawJson<CategorySingle>
{
    /// <inheritdoc/>
    public CategorySingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CategorySingle.FromRawUnchecked(rawData);
}
