using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using Attachments = EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Models.Rules;

[JsonConverter(typeof(JsonModelConverter<RuleRead, RuleReadFromRaw>))]
public sealed record class RuleRead : JsonModel
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

    public RuleRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleRead(RuleRead ruleRead)
        : base(ruleRead) { }
#pragma warning restore CS8618

    public RuleRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleReadFromRaw.FromRawUnchecked"/>
    public static RuleRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleReadFromRaw : IFromRawJson<RuleRead>
{
    /// <inheritdoc/>
    public RuleRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RuleRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    public required IReadOnlyList<AttributesAction> Actions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AttributesAction>>("actions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AttributesAction>>(
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rule_group_id");
        }
        init { this._rawData.Set("rule_group_id", value); }
    }

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <summary>
    /// Which action is necessary for the rule to fire? Use either store-journal,
    /// update-journal or manual-activation.
    /// </summary>
    public required ApiEnum<string, RuleTriggerType> Trigger
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RuleTriggerType>>("trigger");
        }
        init { this._rawData.Set("trigger", value); }
    }

    public required IReadOnlyList<AttributesTrigger> Triggers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AttributesTrigger>>("triggers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AttributesTrigger>>(
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

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

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
    /// Title of the rule group under which the rule must be stored. Either this
    /// field or rule_group_id is mandatory.
    /// </summary>
    public string? RuleGroupTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rule_group_title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rule_group_title", value);
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
    /// If the rule is set to be strict, ALL triggers must hit in order for the rule
    /// to fire. Otherwise, just one is enough. Default value is true.
    /// </summary>
    public bool? Strict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("strict", value);
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
        foreach (var item in this.Actions)
        {
            item.Validate();
        }
        _ = this.RuleGroupID;
        _ = this.Title;
        this.Trigger.Validate();
        foreach (var item in this.Triggers)
        {
            item.Validate();
        }
        _ = this.Active;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Order;
        _ = this.RuleGroupTitle;
        _ = this.StopProcessing;
        _ = this.Strict;
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

[JsonConverter(typeof(JsonModelConverter<AttributesAction, AttributesActionFromRaw>))]
public sealed record class AttributesAction : JsonModel
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

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
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
        this.Type.Validate();
        _ = this.Value;
        _ = this.ID;
        _ = this.Active;
        _ = this.CreatedAt;
        _ = this.Order;
        _ = this.StopProcessing;
        _ = this.UpdatedAt;
    }

    public AttributesAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttributesAction(AttributesAction attributesAction)
        : base(attributesAction) { }
#pragma warning restore CS8618

    public AttributesAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttributesAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttributesActionFromRaw.FromRawUnchecked"/>
    public static AttributesAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttributesActionFromRaw : IFromRawJson<AttributesAction>
{
    /// <inheritdoc/>
    public AttributesAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AttributesAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AttributesTrigger, AttributesTriggerFromRaw>))]
public sealed record class AttributesTrigger : JsonModel
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

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
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
        this.Type.Validate();
        _ = this.Value;
        _ = this.ID;
        _ = this.Active;
        _ = this.CreatedAt;
        _ = this.Order;
        _ = this.Prohibited;
        _ = this.StopProcessing;
        _ = this.UpdatedAt;
    }

    public AttributesTrigger() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttributesTrigger(AttributesTrigger attributesTrigger)
        : base(attributesTrigger) { }
#pragma warning restore CS8618

    public AttributesTrigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttributesTrigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttributesTriggerFromRaw.FromRawUnchecked"/>
    public static AttributesTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttributesTriggerFromRaw : IFromRawJson<AttributesTrigger>
{
    /// <inheritdoc/>
    public AttributesTrigger FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AttributesTrigger.FromRawUnchecked(rawData);
}
