using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using Attachments = EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Models.UserGroups;

[JsonConverter(typeof(JsonModelConverter<UserGroupRead, UserGroupReadFromRaw>))]
public sealed record class UserGroupRead : JsonModel
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

    public required Attributes Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attributes>("attributes");
        }
        init { this._rawData.Set("attributes", value); }
    }

    public required Attachments::ObjectLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attachments::ObjectLink>("links");
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

    public UserGroupRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserGroupRead(UserGroupRead userGroupRead)
        : base(userGroupRead) { }
#pragma warning restore CS8618

    public UserGroupRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserGroupRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserGroupReadFromRaw.FromRawUnchecked"/>
    public static UserGroupRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserGroupReadFromRaw : IFromRawJson<UserGroupRead>
{
    /// <inheritdoc/>
    public UserGroupRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserGroupRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    /// <summary>
    /// Can the current user see the members of this user group?
    /// </summary>
    public bool? CanSeeMembers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("can_see_members");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("can_see_members", value);
        }
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
    /// Is this user group ('financial administration') currently the active administration?
    /// </summary>
    public bool? InUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("in_use");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("in_use", value);
        }
    }

    public IReadOnlyList<Member>? Members
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Member>>("members");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Member>?>(
                "members",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Returns the primary currency code of the user group.
    /// </summary>
    public string? PrimaryCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_code", value);
        }
    }

    /// <summary>
    /// Returns the primary currency decimal places of the user group.
    /// </summary>
    public int? PrimaryCurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("primary_currency_decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_decimal_places", value);
        }
    }

    /// <summary>
    /// Returns the primary currency ID of the user group.
    /// </summary>
    public string? PrimaryCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_id", value);
        }
    }

    /// <summary>
    /// Returns the primary currency symbol of the user group.
    /// </summary>
    public string? PrimaryCurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_symbol", value);
        }
    }

    /// <summary>
    /// Title of the user group. By default, it is the same as the user's email address.
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
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
        _ = this.CanSeeMembers;
        _ = this.CreatedAt;
        _ = this.InUse;
        foreach (var item in this.Members ?? [])
        {
            item.Validate();
        }
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencySymbol;
        _ = this.Title;
        _ = this.UpdatedAt;
    }

    public Attributes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attributes(Attributes attributes)
        : base(attributes) { }
#pragma warning restore CS8618

    public Attributes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attributes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttributesFromRaw.FromRawUnchecked"/>
    public static Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttributesFromRaw : IFromRawJson<Attributes>
{
    /// <inheritdoc/>
    public Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attributes.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Member, MemberFromRaw>))]
public sealed record class Member : JsonModel
{
    public IReadOnlyList<ApiEnum<string, Role>>? Roles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Role>>>("roles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Role>>?>(
                "roles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The email address of the member
    /// </summary>
    public string? UserEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_email", value);
        }
    }

    /// <summary>
    /// The ID of the member.
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <summary>
    /// Is this you? (the current user)
    /// </summary>
    public bool? You
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("you");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("you", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Roles ?? [])
        {
            item.Validate();
        }
        _ = this.UserEmail;
        _ = this.UserID;
        _ = this.You;
    }

    public Member() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Member(Member member)
        : base(member) { }
#pragma warning restore CS8618

    public Member(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Member(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemberFromRaw.FromRawUnchecked"/>
    public static Member FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemberFromRaw : IFromRawJson<Member>
{
    /// <inheritdoc/>
    public Member FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Member.FromRawUnchecked(rawData);
}

/// <summary>
/// The possible roles of the user in this user group are documented here: https://docs.firefly-iii.org/references/firefly-iii/api/
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    Ro,
    MngTrx,
    MngMeta,
    ReadBudgets,
    ReadPiggies,
    ReadSubscriptions,
    ReadRules,
    ReadRecurring,
    ReadWebhooks,
    ReadCurrencies,
    MngBudgets,
    MngPiggies,
    MngSubscriptions,
    MngRules,
    MngRecurring,
    MngWebhooks,
    MngCurrencies,
    ViewReports,
    ViewMemberships,
    Full,
    Owner,
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ro" => Role.Ro,
            "mng_trx" => Role.MngTrx,
            "mng_meta" => Role.MngMeta,
            "read_budgets" => Role.ReadBudgets,
            "read_piggies" => Role.ReadPiggies,
            "read_subscriptions" => Role.ReadSubscriptions,
            "read_rules" => Role.ReadRules,
            "read_recurring" => Role.ReadRecurring,
            "read_webhooks" => Role.ReadWebhooks,
            "read_currencies" => Role.ReadCurrencies,
            "mng_budgets" => Role.MngBudgets,
            "mng_piggies" => Role.MngPiggies,
            "mng_subscriptions" => Role.MngSubscriptions,
            "mng_rules" => Role.MngRules,
            "mng_recurring" => Role.MngRecurring,
            "mng_webhooks" => Role.MngWebhooks,
            "mng_currencies" => Role.MngCurrencies,
            "view_reports" => Role.ViewReports,
            "view_memberships" => Role.ViewMemberships,
            "full" => Role.Full,
            "owner" => Role.Owner,
            _ => (Role)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Role.Ro => "ro",
                Role.MngTrx => "mng_trx",
                Role.MngMeta => "mng_meta",
                Role.ReadBudgets => "read_budgets",
                Role.ReadPiggies => "read_piggies",
                Role.ReadSubscriptions => "read_subscriptions",
                Role.ReadRules => "read_rules",
                Role.ReadRecurring => "read_recurring",
                Role.ReadWebhooks => "read_webhooks",
                Role.ReadCurrencies => "read_currencies",
                Role.MngBudgets => "mng_budgets",
                Role.MngPiggies => "mng_piggies",
                Role.MngSubscriptions => "mng_subscriptions",
                Role.MngRules => "mng_rules",
                Role.MngRecurring => "mng_recurring",
                Role.MngWebhooks => "mng_webhooks",
                Role.MngCurrencies => "mng_currencies",
                Role.ViewReports => "view_reports",
                Role.ViewMemberships => "view_memberships",
                Role.Full => "full",
                Role.Owner => "owner",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
