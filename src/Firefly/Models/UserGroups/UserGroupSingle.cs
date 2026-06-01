using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.UserGroups;

[JsonConverter(typeof(JsonModelConverter<UserGroupSingle, UserGroupSingleFromRaw>))]
public sealed record class UserGroupSingle : JsonModel
{
    public required UserGroupRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserGroupRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public UserGroupSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserGroupSingle(UserGroupSingle userGroupSingle)
        : base(userGroupSingle) { }
#pragma warning restore CS8618

    public UserGroupSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserGroupSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserGroupSingleFromRaw.FromRawUnchecked"/>
    public static UserGroupSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserGroupSingle(UserGroupRead data)
        : this()
    {
        this.Data = data;
    }
}

class UserGroupSingleFromRaw : IFromRawJson<UserGroupSingle>
{
    /// <inheritdoc/>
    public UserGroupSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserGroupSingle.FromRawUnchecked(rawData);
}
