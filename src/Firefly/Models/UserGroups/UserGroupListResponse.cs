using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.UserGroups;

[JsonConverter(typeof(JsonModelConverter<UserGroupListResponse, UserGroupListResponseFromRaw>))]
public sealed record class UserGroupListResponse : JsonModel
{
    public required IReadOnlyList<UserGroupRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserGroupRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserGroupRead>>(
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

    public UserGroupListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserGroupListResponse(UserGroupListResponse userGroupListResponse)
        : base(userGroupListResponse) { }
#pragma warning restore CS8618

    public UserGroupListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserGroupListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserGroupListResponseFromRaw.FromRawUnchecked"/>
    public static UserGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserGroupListResponseFromRaw : IFromRawJson<UserGroupListResponse>
{
    /// <inheritdoc/>
    public UserGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserGroupListResponse.FromRawUnchecked(rawData);
}
