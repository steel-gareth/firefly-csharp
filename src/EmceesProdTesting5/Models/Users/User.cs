using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Users;

[JsonConverter(typeof(JsonModelConverter<User, UserFromRaw>))]
public sealed record class User : JsonModel
{
    /// <summary>
    /// The new users email address.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Boolean to indicate if the user is blocked.
    /// </summary>
    public bool? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("blocked");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blocked", value);
        }
    }

    /// <summary>
    /// If you say the user must be blocked, this will be the reason code.
    /// </summary>
    public ApiEnum<string, UserBlockedCode>? BlockedCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UserBlockedCode>>("blocked_code");
        }
        init { this._rawData.Set("blocked_code", value); }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Role for the user. Can be empty or omitted.
    /// </summary>
    public ApiEnum<string, UserRole>? Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UserRole>>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Blocked;
        this.BlockedCode?.Validate();
        _ = this.CreatedAt;
        this.Role?.Validate();
        _ = this.UpdatedAt;
    }

    public User() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public User(User user)
        : base(user) { }
#pragma warning restore CS8618

    public User(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    User(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserFromRaw.FromRawUnchecked"/>
    public static User FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public User(string email)
        : this()
    {
        this.Email = email;
    }
}

class UserFromRaw : IFromRawJson<User>
{
    /// <inheritdoc/>
    public User FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        User.FromRawUnchecked(rawData);
}

/// <summary>
/// If you say the user must be blocked, this will be the reason code.
/// </summary>
[JsonConverter(typeof(UserBlockedCodeConverter))]
public enum UserBlockedCode
{
    EmailChanged,
}

sealed class UserBlockedCodeConverter : JsonConverter<UserBlockedCode>
{
    public override UserBlockedCode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_changed" => UserBlockedCode.EmailChanged,
            _ => (UserBlockedCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserBlockedCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserBlockedCode.EmailChanged => "email_changed",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Role for the user. Can be empty or omitted.
/// </summary>
[JsonConverter(typeof(UserRoleConverter))]
public enum UserRole
{
    Owner,
    Demo,
}

sealed class UserRoleConverter : JsonConverter<UserRole>
{
    public override UserRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => UserRole.Owner,
            "demo" => UserRole.Demo,
            _ => (UserRole)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, UserRole value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRole.Owner => "owner",
                UserRole.Demo => "demo",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
