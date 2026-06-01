using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Bills;
using Firefly.Models.Rules;

namespace Firefly.Tests.Models.Bills;

public class RuleArrayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RuleArray
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        List<RuleRead> expectedData =
        [
            new()
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
        ];
        PageLink expectedLinks = new()
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };
        Meta expectedMeta = new()
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedMeta, model.Meta);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RuleArray
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleArray>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RuleArray
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleArray>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<RuleRead> expectedData =
        [
            new()
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
        ];
        PageLink expectedLinks = new()
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };
        Meta expectedMeta = new()
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedMeta, deserialized.Meta);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RuleArray
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RuleArray
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        RuleArray copied = new(model);

        Assert.Equal(model, copied);
    }
}
