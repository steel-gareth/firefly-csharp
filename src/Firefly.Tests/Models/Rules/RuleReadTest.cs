using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Rules;
using Attachments = Firefly.Models.Attachments;

namespace Firefly.Tests.Models.Rules;

public class RuleReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RuleRead
        {
            ID = "2",
            Attributes = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = RuleActionKeyword.SetCategory,
                        Value = "Daily groceries",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                RuleGroupID = "81",
                Title = "First rule title.",
                Trigger = RuleTriggerType.StoreJournal,
                Triggers =
                [
                    new()
                    {
                        Type = RuleTriggerKeyword.FromAccountStarts,
                        Value = "tag1",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        Prohibited = false,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "First rule description",
                Order = 5,
                RuleGroupTitle = "New rule group",
                StopProcessing = false,
                Strict = true,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "rules",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "rules";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RuleRead
        {
            ID = "2",
            Attributes = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = RuleActionKeyword.SetCategory,
                        Value = "Daily groceries",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                RuleGroupID = "81",
                Title = "First rule title.",
                Trigger = RuleTriggerType.StoreJournal,
                Triggers =
                [
                    new()
                    {
                        Type = RuleTriggerKeyword.FromAccountStarts,
                        Value = "tag1",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        Prohibited = false,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "First rule description",
                Order = 5,
                RuleGroupTitle = "New rule group",
                StopProcessing = false,
                Strict = true,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "rules",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleRead>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RuleRead
        {
            ID = "2",
            Attributes = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = RuleActionKeyword.SetCategory,
                        Value = "Daily groceries",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                RuleGroupID = "81",
                Title = "First rule title.",
                Trigger = RuleTriggerType.StoreJournal,
                Triggers =
                [
                    new()
                    {
                        Type = RuleTriggerKeyword.FromAccountStarts,
                        Value = "tag1",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        Prohibited = false,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "First rule description",
                Order = 5,
                RuleGroupTitle = "New rule group",
                StopProcessing = false,
                Strict = true,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "rules",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "rules";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RuleRead
        {
            ID = "2",
            Attributes = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = RuleActionKeyword.SetCategory,
                        Value = "Daily groceries",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                RuleGroupID = "81",
                Title = "First rule title.",
                Trigger = RuleTriggerType.StoreJournal,
                Triggers =
                [
                    new()
                    {
                        Type = RuleTriggerKeyword.FromAccountStarts,
                        Value = "tag1",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        Prohibited = false,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "First rule description",
                Order = 5,
                RuleGroupTitle = "New rule group",
                StopProcessing = false,
                Strict = true,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "rules",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RuleRead
        {
            ID = "2",
            Attributes = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = RuleActionKeyword.SetCategory,
                        Value = "Daily groceries",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                RuleGroupID = "81",
                Title = "First rule title.",
                Trigger = RuleTriggerType.StoreJournal,
                Triggers =
                [
                    new()
                    {
                        Type = RuleTriggerKeyword.FromAccountStarts,
                        Value = "tag1",
                        ID = "2",
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Order = 5,
                        Prohibited = false,
                        StopProcessing = false,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "First rule description",
                Order = 5,
                RuleGroupTitle = "New rule group",
                StopProcessing = false,
                Strict = true,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "rules",
        };

        RuleRead copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttributesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        List<AttributesAction> expectedActions =
        [
            new()
            {
                Type = RuleActionKeyword.SetCategory,
                Value = "Daily groceries",
                ID = "2",
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 5,
                StopProcessing = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
        ];
        string expectedRuleGroupID = "81";
        string expectedTitle = "First rule title.";
        ApiEnum<string, RuleTriggerType> expectedTrigger = RuleTriggerType.StoreJournal;
        List<AttributesTrigger> expectedTriggers =
        [
            new()
            {
                Type = RuleTriggerKeyword.FromAccountStarts,
                Value = "tag1",
                ID = "2",
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 5,
                Prohibited = false,
                StopProcessing = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
        ];
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "First rule description";
        int expectedOrder = 5;
        string expectedRuleGroupTitle = "New rule group";
        bool expectedStopProcessing = false;
        bool expectedStrict = true;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedActions.Count, model.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], model.Actions[i]);
        }
        Assert.Equal(expectedRuleGroupID, model.RuleGroupID);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedTrigger, model.Trigger);
        Assert.Equal(expectedTriggers.Count, model.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], model.Triggers[i]);
        }
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedRuleGroupTitle, model.RuleGroupTitle);
        Assert.Equal(expectedStopProcessing, model.StopProcessing);
        Assert.Equal(expectedStrict, model.Strict);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AttributesAction> expectedActions =
        [
            new()
            {
                Type = RuleActionKeyword.SetCategory,
                Value = "Daily groceries",
                ID = "2",
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 5,
                StopProcessing = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
        ];
        string expectedRuleGroupID = "81";
        string expectedTitle = "First rule title.";
        ApiEnum<string, RuleTriggerType> expectedTrigger = RuleTriggerType.StoreJournal;
        List<AttributesTrigger> expectedTriggers =
        [
            new()
            {
                Type = RuleTriggerKeyword.FromAccountStarts,
                Value = "tag1",
                ID = "2",
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 5,
                Prohibited = false,
                StopProcessing = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
        ];
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "First rule description";
        int expectedOrder = 5;
        string expectedRuleGroupTitle = "New rule group";
        bool expectedStopProcessing = false;
        bool expectedStrict = true;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedActions.Count, deserialized.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], deserialized.Actions[i]);
        }
        Assert.Equal(expectedRuleGroupID, deserialized.RuleGroupID);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedTrigger, deserialized.Trigger);
        Assert.Equal(expectedTriggers.Count, deserialized.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], deserialized.Triggers[i]);
        }
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedRuleGroupTitle, deserialized.RuleGroupTitle);
        Assert.Equal(expectedStopProcessing, deserialized.StopProcessing);
        Assert.Equal(expectedStrict, deserialized.Strict);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.RuleGroupTitle);
        Assert.False(model.RawData.ContainsKey("rule_group_title"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],

            // Null should be interpreted as omitted for these properties
            Active = null,
            CreatedAt = null,
            Description = null,
            Order = null,
            RuleGroupTitle = null,
            StopProcessing = null,
            Strict = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.RuleGroupTitle);
        Assert.False(model.RawData.ContainsKey("rule_group_title"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],

            // Null should be interpreted as omitted for these properties
            Active = null,
            CreatedAt = null,
            Description = null,
            Order = null,
            RuleGroupTitle = null,
            StopProcessing = null,
            Strict = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            Actions =
            [
                new()
                {
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    ID = "2",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttributesActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        ApiEnum<string, RuleActionKeyword> expectedType = RuleActionKeyword.SetCategory;
        string expectedValue = "Daily groceries";
        string expectedID = "2";
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedOrder = 5;
        bool expectedStopProcessing = false;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedStopProcessing, model.StopProcessing);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttributesAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttributesAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RuleActionKeyword> expectedType = RuleActionKeyword.SetCategory;
        string expectedValue = "Daily groceries";
        string expectedID = "2";
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedOrder = 5;
        bool expectedStopProcessing = false;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedStopProcessing, deserialized.StopProcessing);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Active = null,
            CreatedAt = null,
            Order = null,
            StopProcessing = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Active = null,
            CreatedAt = null,
            Order = null,
            StopProcessing = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttributesAction
        {
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        AttributesAction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttributesTriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        ApiEnum<string, RuleTriggerKeyword> expectedType = RuleTriggerKeyword.FromAccountStarts;
        string expectedValue = "tag1";
        string expectedID = "2";
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedOrder = 5;
        bool expectedProhibited = false;
        bool expectedStopProcessing = false;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedProhibited, model.Prohibited);
        Assert.Equal(expectedStopProcessing, model.StopProcessing);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttributesTrigger>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttributesTrigger>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RuleTriggerKeyword> expectedType = RuleTriggerKeyword.FromAccountStarts;
        string expectedValue = "tag1";
        string expectedID = "2";
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedOrder = 5;
        bool expectedProhibited = false;
        bool expectedStopProcessing = false;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedProhibited, deserialized.Prohibited);
        Assert.Equal(expectedStopProcessing, deserialized.StopProcessing);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.Prohibited);
        Assert.False(model.RawData.ContainsKey("prohibited"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Active = null,
            CreatedAt = null,
            Order = null,
            Prohibited = null,
            StopProcessing = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.Prohibited);
        Assert.False(model.RawData.ContainsKey("prohibited"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Active = null,
            CreatedAt = null,
            Order = null,
            Prohibited = null,
            StopProcessing = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttributesTrigger
        {
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            ID = "2",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        AttributesTrigger copied = new(model);

        Assert.Equal(model, copied);
    }
}
