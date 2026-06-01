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
/// Update existing rule.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RuleUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public IReadOnlyList<RuleUpdateParamsAction>? Actions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<RuleUpdateParamsAction>>(
                "actions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<RuleUpdateParamsAction>?>(
                "actions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
    /// ID of the rule group under which the rule must be stored. Either this field
    /// or rule_group_title is mandatory.
    /// </summary>
    public string? RuleGroupID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("rule_group_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("rule_group_id", value);
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

    public string? Title
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("title", value);
        }
    }

    /// <summary>
    /// Which action is necessary for the rule to fire? Use either store-journal,
    /// update-journal or manual-activation.
    /// </summary>
    public ApiEnum<string, RuleTriggerType>? Trigger
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RuleTriggerType>>("trigger");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("trigger", value);
        }
    }

    public IReadOnlyList<RuleUpdateParamsTrigger>? Triggers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<RuleUpdateParamsTrigger>>(
                "triggers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<RuleUpdateParamsTrigger>?>(
                "triggers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public RuleUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleUpdateParams(RuleUpdateParams ruleUpdateParams)
        : base(ruleUpdateParams)
    {
        this.ID = ruleUpdateParams.ID;

        this._rawBodyData = new(ruleUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RuleUpdateParams(
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
    RuleUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RuleUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(RuleUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/rules/{0}", this.ID)
        )
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

[JsonConverter(typeof(JsonModelConverter<RuleUpdateParamsAction, RuleUpdateParamsActionFromRaw>))]
public sealed record class RuleUpdateParamsAction : JsonModel
{
    /// <summary>
    /// If the action is active.
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
    /// When true, other actions will not be fired after this action has fired.
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

    /// <summary>
    /// The type of thing this action will do. A limited set is possible.
    /// </summary>
    public ApiEnum<string, RuleActionKeyword>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RuleActionKeyword>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// The accompanying value the action will set, change or update. Can be empty,
    /// but for some types this value is mandatory.
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        _ = this.Order;
        _ = this.StopProcessing;
        this.Type?.Validate();
        _ = this.Value;
    }

    public RuleUpdateParamsAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleUpdateParamsAction(RuleUpdateParamsAction ruleUpdateParamsAction)
        : base(ruleUpdateParamsAction) { }
#pragma warning restore CS8618

    public RuleUpdateParamsAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleUpdateParamsAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleUpdateParamsActionFromRaw.FromRawUnchecked"/>
    public static RuleUpdateParamsAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleUpdateParamsActionFromRaw : IFromRawJson<RuleUpdateParamsAction>
{
    /// <inheritdoc/>
    public RuleUpdateParamsAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RuleUpdateParamsAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RuleUpdateParamsTrigger, RuleUpdateParamsTriggerFromRaw>))]
public sealed record class RuleUpdateParamsTrigger : JsonModel
{
    /// <summary>
    /// If the trigger is active.
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
    /// When true, other triggers will not be checked if this trigger was triggered.
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

    /// <summary>
    /// The type of thing this trigger responds to. A limited set is possible
    /// </summary>
    public ApiEnum<string, RuleTriggerKeyword>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RuleTriggerKeyword>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// The accompanying value the trigger responds to. This value is often mandatory,
    /// but this depends on the trigger. If the rule trigger is something like 'has
    /// any tag', submit the string 'true'.
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        _ = this.Order;
        _ = this.StopProcessing;
        this.Type?.Validate();
        _ = this.Value;
    }

    public RuleUpdateParamsTrigger() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleUpdateParamsTrigger(RuleUpdateParamsTrigger ruleUpdateParamsTrigger)
        : base(ruleUpdateParamsTrigger) { }
#pragma warning restore CS8618

    public RuleUpdateParamsTrigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleUpdateParamsTrigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleUpdateParamsTriggerFromRaw.FromRawUnchecked"/>
    public static RuleUpdateParamsTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleUpdateParamsTriggerFromRaw : IFromRawJson<RuleUpdateParamsTrigger>
{
    /// <inheritdoc/>
    public RuleUpdateParamsTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RuleUpdateParamsTrigger.FromRawUnchecked(rawData);
}
