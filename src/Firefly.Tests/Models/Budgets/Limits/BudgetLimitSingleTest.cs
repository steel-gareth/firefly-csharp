using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Budgets.Limits;

namespace Firefly.Tests.Models.Budgets.Limits;

public class BudgetLimitSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BudgetLimitSingle
        {
            Data = new()
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
            },
        };

        BudgetLimitRead expectedData = new()
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BudgetLimitSingle
        {
            Data = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BudgetLimitSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BudgetLimitSingle
        {
            Data = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BudgetLimitSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BudgetLimitRead expectedData = new()
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BudgetLimitSingle
        {
            Data = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BudgetLimitSingle
        {
            Data = new()
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
            },
        };

        BudgetLimitSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
