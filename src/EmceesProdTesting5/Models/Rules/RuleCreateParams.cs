using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Rules;

/// <summary>
/// Creates a new rule. The data required can be submitted as a JSON body or as a
/// list of parameters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RuleCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required IReadOnlyList<global::EmceesProdTesting5.Models.Rules.Action> Actions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<global::EmceesProdTesting5.Models.Rules.Action>
            >("actions");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<global::EmceesProdTesting5.Models.Rules.Action>>(
                "actions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ID of the rule group under which the rule must be stored. Either this field
    /// or rule_group_title is mandatory.
    /// </summary>
    public required string RuleGroupID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("rule_group_id");
        }
        init { this._rawBodyData.Set("rule_group_id", value); }
    }

    public required string Title
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("title");
        }
        init { this._rawBodyData.Set("title", value); }
    }

    /// <summary>
    /// Which action is necessary for the rule to fire? Use either store-journal,
    /// update-journal or manual-activation.
    /// </summary>
    public required ApiEnum<string, RuleTriggerType> Trigger
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, RuleTriggerType>>("trigger");
        }
        init { this._rawBodyData.Set("trigger", value); }
    }

    public required IReadOnlyList<Trigger> Triggers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Trigger>>("triggers");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Trigger>>(
                "triggers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether or not the rule is even active. Default is true.
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("active", value);
        }
    }

    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    public int? Order
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("order", value);
        }
    }

    /// <summary>
    /// Title of the rule group under which the rule must be stored. Either this
    /// field or rule_group_id is mandatory.
    /// </summary>
    public string? RuleGroupTitle
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("rule_group_title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("rule_group_title", value);
        }
    }

    /// <summary>
    /// If this value is true and the rule is triggered, other rules  after this
    /// one in the group will be skipped. Default value is false.
    /// </summary>
    public bool? StopProcessing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("stop_processing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("stop_processing", value);
        }
    }

    /// <summary>
    /// If the rule is set to be strict, ALL triggers must hit in order for the rule
    /// to fire. Otherwise, just one is enough. Default value is true.
    /// </summary>
    public bool? Strict
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("strict");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("strict", value);
        }
    }

    public string? XTraceID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-Trace-Id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-Trace-Id", value);
        }
    }

    public RuleCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleCreateParams(RuleCreateParams ruleCreateParams)
        : base(ruleCreateParams)
    {
        this._rawBodyData = new(ruleCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RuleCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RuleCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(RuleCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/rules")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        request.Headers.Add("Accept", "application/vnd.api+json");
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(
    typeof(JsonModelConverter<global::EmceesProdTesting5.Models.Rules.Action, ActionFromRaw>)
)]
public sealed record class Action : JsonModel
{
    /// <summary>
    /// The type of thing this action will do. A limited set is possible.
    /// </summary>
    public required ApiEnum<string, RuleActionKeyword> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RuleActionKeyword>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The accompanying value the action will set, change or update. Can be empty,
    /// but for some types this value is mandatory.
    /// </summary>
    public required string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// If the action is active. Defaults to true.
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
    /// Order of the action
    /// </summary>
    public int? Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("order", value);
        }
    }

    /// <summary>
    /// When true, other actions will not be fired after this action has fired. Defaults
    /// to false.
    /// </summary>
    public bool? StopProcessing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stop_processing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stop_processing", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
        _ = this.Active;
        _ = this.Order;
        _ = this.StopProcessing;
    }

    public Action() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Action(global::EmceesProdTesting5.Models.Rules.Action action)
        : base(action) { }
#pragma warning restore CS8618

    public Action(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Action(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActionFromRaw.FromRawUnchecked"/>
    public static global::EmceesProdTesting5.Models.Rules.Action FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActionFromRaw : IFromRawJson<global::EmceesProdTesting5.Models.Rules.Action>
{
    /// <inheritdoc/>
    public global::EmceesProdTesting5.Models.Rules.Action FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::EmceesProdTesting5.Models.Rules.Action.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Trigger, TriggerFromRaw>))]
public sealed record class Trigger : JsonModel
{
    /// <summary>
    /// The type of thing this trigger responds to. A limited set is possible
    /// </summary>
    public required ApiEnum<string, RuleTriggerKeyword> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RuleTriggerKeyword>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The accompanying value the trigger responds to. This value is often mandatory,
    /// but this depends on the trigger.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// If the trigger is active. Defaults to true.
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
    /// Order of the trigger
    /// </summary>
    public int? Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("order", value);
        }
    }

    /// <summary>
    /// If 'prohibited' is true, this rule trigger will be negated. 'Description is'
    /// will become 'Description is NOT' etc.
    /// </summary>
    public bool? Prohibited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("prohibited");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prohibited", value);
        }
    }

    /// <summary>
    /// When true, other triggers will not be checked if this trigger was triggered.
    /// Defaults to false.
    /// </summary>
    public bool? StopProcessing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stop_processing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stop_processing", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
        _ = this.Active;
        _ = this.Order;
        _ = this.Prohibited;
        _ = this.StopProcessing;
    }

    public Trigger() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Trigger(Trigger trigger)
        : base(trigger) { }
#pragma warning restore CS8618

    public Trigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TriggerFromRaw.FromRawUnchecked"/>
    public static Trigger FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TriggerFromRaw : IFromRawJson<Trigger>
{
    /// <inheritdoc/>
    public Trigger FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trigger.FromRawUnchecked(rawData);
}
