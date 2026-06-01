using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Rules;

namespace EmceesProdTesting5.Tests.Models.Rules;

public class RuleSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RuleSingle
        {
            Data = new()
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
            },
        };

        RuleRead expectedData = new()
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RuleSingle
        {
            Data = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RuleSingle
        {
            Data = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RuleRead expectedData = new()
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RuleSingle
        {
            Data = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RuleSingle
        {
            Data = new()
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
            },
        };

        RuleSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
