using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.AvailableBudgets;

namespace EmceesProdTesting5.Tests.Models.AvailableBudgets;

public class AvailableBudgetReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AvailableBudgetRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
                PcSpentInBudgets =
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
                PcSpentOutsideBudgets =
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
                SpentInBudgets =
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
                SpentOutsideBudgets =
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "available_budgets",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Amount = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcSpentInBudgets =
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
            PcSpentOutsideBudgets =
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
            SpentInBudgets =
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
            SpentOutsideBudgets =
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "available_budgets";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AvailableBudgetRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
                PcSpentInBudgets =
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
                PcSpentOutsideBudgets =
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
                SpentInBudgets =
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
                SpentOutsideBudgets =
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "available_budgets",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AvailableBudgetRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AvailableBudgetRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
                PcSpentInBudgets =
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
                PcSpentOutsideBudgets =
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
                SpentInBudgets =
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
                SpentOutsideBudgets =
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "available_budgets",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AvailableBudgetRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Amount = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcSpentInBudgets =
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
            PcSpentOutsideBudgets =
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
            SpentInBudgets =
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
            SpentOutsideBudgets =
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "available_budgets";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AvailableBudgetRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
                PcSpentInBudgets =
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
                PcSpentOutsideBudgets =
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
                SpentInBudgets =
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
                SpentOutsideBudgets =
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "available_budgets",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AvailableBudgetRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
                PcSpentInBudgets =
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
                PcSpentOutsideBudgets =
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
                SpentInBudgets =
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
                SpentOutsideBudgets =
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "available_budgets",
        };

        AvailableBudgetRead copied = new(model);

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
            Amount = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcSpentInBudgets =
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
            PcSpentOutsideBudgets =
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
            SpentInBudgets =
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
            SpentOutsideBudgets =
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string expectedAmount = "123.45";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        bool expectedObjectHasCurrencySetting = true;
        string expectedPcAmount = "123.45";
        List<ArrayEntryWithCurrencyAndSum> expectedPcSpentInBudgets =
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
        List<ArrayEntryWithCurrencyAndSum> expectedPcSpentOutsideBudgets =
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
        List<ArrayEntryWithCurrencyAndSum> expectedSpentInBudgets =
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
        List<ArrayEntryWithCurrencyAndSum> expectedSpentOutsideBudgets =
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
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.Equal(expectedPcAmount, model.PcAmount);
        Assert.NotNull(model.PcSpentInBudgets);
        Assert.Equal(expectedPcSpentInBudgets.Count, model.PcSpentInBudgets.Count);
        for (int i = 0; i < expectedPcSpentInBudgets.Count; i++)
        {
            Assert.Equal(expectedPcSpentInBudgets[i], model.PcSpentInBudgets[i]);
        }
        Assert.NotNull(model.PcSpentOutsideBudgets);
        Assert.Equal(expectedPcSpentOutsideBudgets.Count, model.PcSpentOutsideBudgets.Count);
        for (int i = 0; i < expectedPcSpentOutsideBudgets.Count; i++)
        {
            Assert.Equal(expectedPcSpentOutsideBudgets[i], model.PcSpentOutsideBudgets[i]);
        }
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, model.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.NotNull(model.SpentInBudgets);
        Assert.Equal(expectedSpentInBudgets.Count, model.SpentInBudgets.Count);
        for (int i = 0; i < expectedSpentInBudgets.Count; i++)
        {
            Assert.Equal(expectedSpentInBudgets[i], model.SpentInBudgets[i]);
        }
        Assert.NotNull(model.SpentOutsideBudgets);
        Assert.Equal(expectedSpentOutsideBudgets.Count, model.SpentOutsideBudgets.Count);
        for (int i = 0; i < expectedSpentOutsideBudgets.Count; i++)
        {
            Assert.Equal(expectedSpentOutsideBudgets[i], model.SpentOutsideBudgets[i]);
        }
        Assert.Equal(expectedStart, model.Start);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcSpentInBudgets =
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
            PcSpentOutsideBudgets =
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
            SpentInBudgets =
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
            SpentOutsideBudgets =
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
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
            Amount = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcSpentInBudgets =
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
            PcSpentOutsideBudgets =
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
            SpentInBudgets =
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
            SpentOutsideBudgets =
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "123.45";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        bool expectedObjectHasCurrencySetting = true;
        string expectedPcAmount = "123.45";
        List<ArrayEntryWithCurrencyAndSum> expectedPcSpentInBudgets =
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
        List<ArrayEntryWithCurrencyAndSum> expectedPcSpentOutsideBudgets =
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
        List<ArrayEntryWithCurrencyAndSum> expectedSpentInBudgets =
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
        List<ArrayEntryWithCurrencyAndSum> expectedSpentOutsideBudgets =
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
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.Equal(expectedPcAmount, deserialized.PcAmount);
        Assert.NotNull(deserialized.PcSpentInBudgets);
        Assert.Equal(expectedPcSpentInBudgets.Count, deserialized.PcSpentInBudgets.Count);
        for (int i = 0; i < expectedPcSpentInBudgets.Count; i++)
        {
            Assert.Equal(expectedPcSpentInBudgets[i], deserialized.PcSpentInBudgets[i]);
        }
        Assert.NotNull(deserialized.PcSpentOutsideBudgets);
        Assert.Equal(expectedPcSpentOutsideBudgets.Count, deserialized.PcSpentOutsideBudgets.Count);
        for (int i = 0; i < expectedPcSpentOutsideBudgets.Count; i++)
        {
            Assert.Equal(expectedPcSpentOutsideBudgets[i], deserialized.PcSpentOutsideBudgets[i]);
        }
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, deserialized.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.NotNull(deserialized.SpentInBudgets);
        Assert.Equal(expectedSpentInBudgets.Count, deserialized.SpentInBudgets.Count);
        for (int i = 0; i < expectedSpentInBudgets.Count; i++)
        {
            Assert.Equal(expectedSpentInBudgets[i], deserialized.SpentInBudgets[i]);
        }
        Assert.NotNull(deserialized.SpentOutsideBudgets);
        Assert.Equal(expectedSpentOutsideBudgets.Count, deserialized.SpentOutsideBudgets.Count);
        for (int i = 0; i < expectedSpentOutsideBudgets.Count; i++)
        {
            Assert.Equal(expectedSpentOutsideBudgets[i], deserialized.SpentOutsideBudgets[i]);
        }
        Assert.Equal(expectedStart, deserialized.Start);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcSpentInBudgets =
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
            PcSpentOutsideBudgets =
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
            SpentInBudgets =
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
            SpentOutsideBudgets =
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencyName);
        Assert.False(model.RawData.ContainsKey("currency_name"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
        Assert.Null(model.PcSpentInBudgets);
        Assert.False(model.RawData.ContainsKey("pc_spent_in_budgets"));
        Assert.Null(model.PcSpentOutsideBudgets);
        Assert.False(model.RawData.ContainsKey("pc_spent_outside_budgets"));
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
        Assert.Null(model.SpentInBudgets);
        Assert.False(model.RawData.ContainsKey("spent_in_budgets"));
        Assert.Null(model.SpentOutsideBudgets);
        Assert.False(model.RawData.ContainsKey("spent_outside_budgets"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            End = null,
            ObjectHasCurrencySetting = null,
            PcAmount = null,
            PcSpentInBudgets = null,
            PcSpentOutsideBudgets = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            SpentInBudgets = null,
            SpentOutsideBudgets = null,
            Start = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencyName);
        Assert.False(model.RawData.ContainsKey("currency_name"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
        Assert.Null(model.PcSpentInBudgets);
        Assert.False(model.RawData.ContainsKey("pc_spent_in_budgets"));
        Assert.Null(model.PcSpentOutsideBudgets);
        Assert.False(model.RawData.ContainsKey("pc_spent_outside_budgets"));
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
        Assert.Null(model.SpentInBudgets);
        Assert.False(model.RawData.ContainsKey("spent_in_budgets"));
        Assert.Null(model.SpentOutsideBudgets);
        Assert.False(model.RawData.ContainsKey("spent_outside_budgets"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            End = null,
            ObjectHasCurrencySetting = null,
            PcAmount = null,
            PcSpentInBudgets = null,
            PcSpentOutsideBudgets = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            SpentInBudgets = null,
            SpentOutsideBudgets = null,
            Start = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcSpentInBudgets =
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
            PcSpentOutsideBudgets =
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
            SpentInBudgets =
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
            SpentOutsideBudgets =
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
