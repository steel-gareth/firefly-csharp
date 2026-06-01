using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.RuleGroups;

namespace EmceesProdTesting5.Tests.Models.RuleGroups;

public class RuleGroupSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RuleGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Title = "Default rule group",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Description of this rule group",
                    Order = 4,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "rules_group",
            },
        };

        RuleGroupRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Title = "Default rule group",
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "Description of this rule group",
                Order = 4,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "rules_group",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RuleGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Title = "Default rule group",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Description of this rule group",
                    Order = 4,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "rules_group",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleGroupSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RuleGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Title = "Default rule group",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Description of this rule group",
                    Order = 4,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "rules_group",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleGroupSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RuleGroupRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Title = "Default rule group",
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "Description of this rule group",
                Order = 4,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "rules_group",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RuleGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Title = "Default rule group",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Description of this rule group",
                    Order = 4,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "rules_group",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RuleGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Title = "Default rule group",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Description of this rule group",
                    Order = 4,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "rules_group",
            },
        };

        RuleGroupSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
