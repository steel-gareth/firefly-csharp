using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.About;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.Users;

[JsonConverter(typeof(JsonModelConverter<UserListResponse, UserListResponseFromRaw>))]
public sealed record class UserListResponse : JsonModel
{
    public required IReadOnlyList<UserRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserRead>>(
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

    public UserListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListResponse(UserListResponse userListResponse)
        : base(userListResponse) { }
#pragma warning restore CS8618

    public UserListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListResponseFromRaw.FromRawUnchecked"/>
    public static UserListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserListResponseFromRaw : IFromRawJson<UserListResponse>
{
    /// <inheritdoc/>
    public UserListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserListResponse.FromRawUnchecked(rawData);
}
