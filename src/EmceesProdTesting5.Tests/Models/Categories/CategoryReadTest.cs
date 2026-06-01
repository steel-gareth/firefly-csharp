using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Categories;
using AvailableBudgets = EmceesProdTesting5.Models.AvailableBudgets;

namespace EmceesProdTesting5.Tests.Models.Categories;

public class CategoryReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CategoryRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "Lunch",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Earned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Notes = "Some example notes",
                ObjectHasCurrencySetting = false,
                PcEarned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcSpent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcTransferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                Spent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Transferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "categories",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Notes = "Some example notes",
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "categories";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CategoryRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "Lunch",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Earned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Notes = "Some example notes",
                ObjectHasCurrencySetting = false,
                PcEarned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcSpent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcTransferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                Spent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Transferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "categories",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CategoryRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CategoryRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "Lunch",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Earned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Notes = "Some example notes",
                ObjectHasCurrencySetting = false,
                PcEarned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcSpent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcTransferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                Spent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Transferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "categories",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CategoryRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Notes = "Some example notes",
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "categories";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CategoryRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "Lunch",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Earned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Notes = "Some example notes",
                ObjectHasCurrencySetting = false,
                PcEarned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcSpent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcTransferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                Spent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Transferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "categories",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CategoryRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "Lunch",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Earned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Notes = "Some example notes",
                ObjectHasCurrencySetting = false,
                PcEarned =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcSpent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PcTransferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                Spent =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                Transferred =
                [
                    new()
                    {
                        CurrencyCode = "USD",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencySymbol = "$",
                        Sum = "123.45",
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "categories",
        };

        CategoryRead copied = new(model);

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
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Notes = "Some example notes",
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string expectedName = "Lunch";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedEarned =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        string expectedNotes = "Some example notes";
        bool expectedObjectHasCurrencySetting = false;
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedPcEarned =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedPcSpent =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedPcTransferred =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedSpent =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedTransferred =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Earned);
        Assert.Equal(expectedEarned.Count, model.Earned.Count);
        for (int i = 0; i < expectedEarned.Count; i++)
        {
            Assert.Equal(expectedEarned[i], model.Earned[i]);
        }
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.NotNull(model.PcEarned);
        Assert.Equal(expectedPcEarned.Count, model.PcEarned.Count);
        for (int i = 0; i < expectedPcEarned.Count; i++)
        {
            Assert.Equal(expectedPcEarned[i], model.PcEarned[i]);
        }
        Assert.NotNull(model.PcSpent);
        Assert.Equal(expectedPcSpent.Count, model.PcSpent.Count);
        for (int i = 0; i < expectedPcSpent.Count; i++)
        {
            Assert.Equal(expectedPcSpent[i], model.PcSpent[i]);
        }
        Assert.NotNull(model.PcTransferred);
        Assert.Equal(expectedPcTransferred.Count, model.PcTransferred.Count);
        for (int i = 0; i < expectedPcTransferred.Count; i++)
        {
            Assert.Equal(expectedPcTransferred[i], model.PcTransferred[i]);
        }
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, model.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.NotNull(model.Spent);
        Assert.Equal(expectedSpent.Count, model.Spent.Count);
        for (int i = 0; i < expectedSpent.Count; i++)
        {
            Assert.Equal(expectedSpent[i], model.Spent[i]);
        }
        Assert.NotNull(model.Transferred);
        Assert.Equal(expectedTransferred.Count, model.Transferred.Count);
        for (int i = 0; i < expectedTransferred.Count; i++)
        {
            Assert.Equal(expectedTransferred[i], model.Transferred[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Notes = "Some example notes",
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
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
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Notes = "Some example notes",
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "Lunch";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedEarned =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        string expectedNotes = "Some example notes";
        bool expectedObjectHasCurrencySetting = false;
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedPcEarned =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedPcSpent =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedPcTransferred =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedSpent =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        List<AvailableBudgets::ArrayEntryWithCurrencyAndSum> expectedTransferred =
        [
            new()
            {
                CurrencyCode = "USD",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencySymbol = "$",
                Sum = "123.45",
            },
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Earned);
        Assert.Equal(expectedEarned.Count, deserialized.Earned.Count);
        for (int i = 0; i < expectedEarned.Count; i++)
        {
            Assert.Equal(expectedEarned[i], deserialized.Earned[i]);
        }
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.NotNull(deserialized.PcEarned);
        Assert.Equal(expectedPcEarned.Count, deserialized.PcEarned.Count);
        for (int i = 0; i < expectedPcEarned.Count; i++)
        {
            Assert.Equal(expectedPcEarned[i], deserialized.PcEarned[i]);
        }
        Assert.NotNull(deserialized.PcSpent);
        Assert.Equal(expectedPcSpent.Count, deserialized.PcSpent.Count);
        for (int i = 0; i < expectedPcSpent.Count; i++)
        {
            Assert.Equal(expectedPcSpent[i], deserialized.PcSpent[i]);
        }
        Assert.NotNull(deserialized.PcTransferred);
        Assert.Equal(expectedPcTransferred.Count, deserialized.PcTransferred.Count);
        for (int i = 0; i < expectedPcTransferred.Count; i++)
        {
            Assert.Equal(expectedPcTransferred[i], deserialized.PcTransferred[i]);
        }
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, deserialized.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.NotNull(deserialized.Spent);
        Assert.Equal(expectedSpent.Count, deserialized.Spent.Count);
        for (int i = 0; i < expectedSpent.Count; i++)
        {
            Assert.Equal(expectedSpent[i], deserialized.Spent[i]);
        }
        Assert.NotNull(deserialized.Transferred);
        Assert.Equal(expectedTransferred.Count, deserialized.Transferred.Count);
        for (int i = 0; i < expectedTransferred.Count; i++)
        {
            Assert.Equal(expectedTransferred[i], deserialized.Transferred[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Notes = "Some example notes",
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes { Name = "Lunch", Notes = "Some example notes" };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Earned);
        Assert.False(model.RawData.ContainsKey("earned"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.PcEarned);
        Assert.False(model.RawData.ContainsKey("pc_earned"));
        Assert.Null(model.PcSpent);
        Assert.False(model.RawData.ContainsKey("pc_spent"));
        Assert.Null(model.PcTransferred);
        Assert.False(model.RawData.ContainsKey("pc_transferred"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencyName);
        Assert.False(model.RawData.ContainsKey("primary_currency_name"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.Spent);
        Assert.False(model.RawData.ContainsKey("spent"));
        Assert.Null(model.Transferred);
        Assert.False(model.RawData.ContainsKey("transferred"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes { Name = "Lunch", Notes = "Some example notes" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            Notes = "Some example notes",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Earned = null,
            ObjectHasCurrencySetting = null,
            PcEarned = null,
            PcSpent = null,
            PcTransferred = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            Spent = null,
            Transferred = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Earned);
        Assert.False(model.RawData.ContainsKey("earned"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.PcEarned);
        Assert.False(model.RawData.ContainsKey("pc_earned"));
        Assert.Null(model.PcSpent);
        Assert.False(model.RawData.ContainsKey("pc_spent"));
        Assert.Null(model.PcTransferred);
        Assert.False(model.RawData.ContainsKey("pc_transferred"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencyName);
        Assert.False(model.RawData.ContainsKey("primary_currency_name"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.Spent);
        Assert.False(model.RawData.ContainsKey("spent"));
        Assert.Null(model.Transferred);
        Assert.False(model.RawData.ContainsKey("transferred"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            Notes = "Some example notes",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Earned = null,
            ObjectHasCurrencySetting = null,
            PcEarned = null,
            PcSpent = null,
            PcTransferred = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            Spent = null,
            Transferred = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            Notes = null,
        };

        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            Notes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            Name = "Lunch",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Earned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Notes = "Some example notes",
            ObjectHasCurrencySetting = false,
            PcEarned =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcSpent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PcTransferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            Spent =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            Transferred =
            [
                new()
                {
                    CurrencyCode = "USD",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencySymbol = "$",
                    Sum = "123.45",
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
