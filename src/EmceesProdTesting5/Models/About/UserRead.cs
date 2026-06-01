using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Attachments;
using EmceesProdTesting5.Models.Users;

namespace EmceesProdTesting5.Models.About;

[JsonConverter(typeof(JsonModelConverter<UserRead, UserReadFromRaw>))]
public sealed record class UserRead : JsonModel
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

    public required User Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<User>("attributes");
        }
        init { this._rawData.Set("attributes", value); }
    }

    public required ObjectLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ObjectLink>("links");
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

    public UserRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRead(UserRead userRead)
        : base(userRead) { }
#pragma warning restore CS8618

    public UserRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserReadFromRaw.FromRawUnchecked"/>
    public static UserRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserReadFromRaw : IFromRawJson<UserRead>
{
    /// <inheritdoc/>
    public UserRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserRead.FromRawUnchecked(rawData);
}
