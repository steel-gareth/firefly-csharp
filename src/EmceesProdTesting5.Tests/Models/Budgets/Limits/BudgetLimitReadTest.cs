using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Budgets.Limits;
using AvailableBudgets = EmceesProdTesting5.Models.AvailableBudgets;

namespace EmceesProdTesting5.Tests.Models.Budgets.Limits;

public class BudgetLimitReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BudgetLimitRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                BudgetID = "23",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                Notes = "Some example notes",
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
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
                Period = "monthly",
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "budget_limits",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
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
            Period = "monthly",
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "budget_limits";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BudgetLimitRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                BudgetID = "23",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                Notes = "Some example notes",
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
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
                Period = "monthly",
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "budget_limits",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BudgetLimitRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BudgetLimitRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                BudgetID = "23",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                Notes = "Some example notes",
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
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
                Period = "monthly",
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "budget_limits",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BudgetLimitRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
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
            Period = "monthly",
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "budget_limits";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BudgetLimitRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                BudgetID = "23",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                Notes = "Some example notes",
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
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
                Period = "monthly",
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "budget_limits",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BudgetLimitRead
        {
            ID = "2",
            Attributes = new()
            {
                Amount = "123.45",
                BudgetID = "23",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                Notes = "Some example notes",
                ObjectHasCurrencySetting = true,
                PcAmount = "123.45",
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
                Period = "monthly",
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
                Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "budget_limits",
        };

        BudgetLimitRead copied = new(model);

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
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
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
            Period = "monthly",
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string expectedAmount = "123.45";
        string expectedBudgetID = "23";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        string expectedNotes = "Some example notes";
        bool expectedObjectHasCurrencySetting = true;
        string expectedPcAmount = "123.45";
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
        string expectedPeriod = "monthly";
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
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBudgetID, model.BudgetID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.Equal(expectedPcAmount, model.PcAmount);
        Assert.NotNull(model.PcSpent);
        Assert.Equal(expectedPcSpent.Count, model.PcSpent.Count);
        for (int i = 0; i < expectedPcSpent.Count; i++)
        {
            Assert.Equal(expectedPcSpent[i], model.PcSpent[i]);
        }
        Assert.Equal(expectedPeriod, model.Period);
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
        Assert.Equal(expectedStart, model.Start);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
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
            Period = "monthly",
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
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
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
            Period = "monthly",
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
        string expectedBudgetID = "23";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        string expectedNotes = "Some example notes";
        bool expectedObjectHasCurrencySetting = true;
        string expectedPcAmount = "123.45";
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
        string expectedPeriod = "monthly";
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
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBudgetID, deserialized.BudgetID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.Equal(expectedPcAmount, deserialized.PcAmount);
        Assert.NotNull(deserialized.PcSpent);
        Assert.Equal(expectedPcSpent.Count, deserialized.PcSpent.Count);
        for (int i = 0; i < expectedPcSpent.Count; i++)
        {
            Assert.Equal(expectedPcSpent[i], deserialized.PcSpent[i]);
        }
        Assert.Equal(expectedPeriod, deserialized.Period);
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
        Assert.Equal(expectedStart, deserialized.Start);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
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
            Period = "monthly",
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Notes = "Some example notes",
            PcAmount = "123.45",
            Period = "monthly",
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
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
        Assert.Null(model.PcSpent);
        Assert.False(model.RawData.ContainsKey("pc_spent"));
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
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Notes = "Some example notes",
            PcAmount = "123.45",
            Period = "monthly",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Notes = "Some example notes",
            PcAmount = "123.45",
            Period = "monthly",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            BudgetID = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            End = null,
            ObjectHasCurrencySetting = null,
            PcSpent = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            Spent = null,
            Start = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
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
        Assert.Null(model.PcSpent);
        Assert.False(model.RawData.ContainsKey("pc_spent"));
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
            Notes = "Some example notes",
            PcAmount = "123.45",
            Period = "monthly",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            BudgetID = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            End = null,
            ObjectHasCurrencySetting = null,
            PcSpent = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            Spent = null,
            Start = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
        Assert.Null(model.Period);
        Assert.False(model.RawData.ContainsKey("period"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            Notes = null,
            PcAmount = null,
            Period = null,
        };

        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PcAmount);
        Assert.True(model.RawData.ContainsKey("pc_amount"));
        Assert.Null(model.Period);
        Assert.True(model.RawData.ContainsKey("period"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ObjectHasCurrencySetting = true,
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            Notes = null,
            PcAmount = null,
            Period = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            Amount = "123.45",
            BudgetID = "23",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            End = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
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
            Period = "monthly",
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
            Start = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
