using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.Categories;

[JsonConverter(typeof(JsonModelConverter<CategoryListResponse, CategoryListResponseFromRaw>))]
public sealed record class CategoryListResponse : JsonModel
{
    public required IReadOnlyList<CategoryRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CategoryRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CategoryRead>>(
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

    public CategoryListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CategoryListResponse(CategoryListResponse categoryListResponse)
        : base(categoryListResponse) { }
#pragma warning restore CS8618

    public CategoryListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryListResponseFromRaw.FromRawUnchecked"/>
    public static CategoryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryListResponseFromRaw : IFromRawJson<CategoryListResponse>
{
    /// <inheritdoc/>
    public CategoryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CategoryListResponse.FromRawUnchecked(rawData);
}
