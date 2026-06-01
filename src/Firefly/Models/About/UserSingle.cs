using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.About;

[JsonConverter(typeof(JsonModelConverter<UserSingle, UserSingleFromRaw>))]
public sealed record class UserSingle : JsonModel
{
    public required UserRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public UserSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSingle(UserSingle userSingle)
        : base(userSingle) { }
#pragma warning restore CS8618

    public UserSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserSingleFromRaw.FromRawUnchecked"/>
    public static UserSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserSingle(UserRead data)
        : this()
    {
        this.Data = data;
    }
}

class UserSingleFromRaw : IFromRawJson<UserSingle>
{
    /// <inheritdoc/>
    public UserSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserSingle.FromRawUnchecked(rawData);
}
