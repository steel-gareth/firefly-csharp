using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Budgets;

namespace Firefly.Tests.Models.Budgets;

public class BudgetSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BudgetSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Name = "Bills",
                    Active = false,
                    AutoBudgetAmount = "-1012.12",
                    AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
                    AutoBudgetType = AutoBudgetType.Reset,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Notes = "Some notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 5,
                    PcAutoBudgetAmount = "-1012.12",
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
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "budgets",
            },
        };

        BudgetRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Name = "Bills",
                Active = false,
                AutoBudgetAmount = "-1012.12",
                AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
                AutoBudgetType = AutoBudgetType.Reset,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                Notes = "Some notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 5,
                PcAutoBudgetAmount = "-1012.12",
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
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "budgets",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BudgetSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Name = "Bills",
                    Active = false,
                    AutoBudgetAmount = "-1012.12",
                    AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
                    AutoBudgetType = AutoBudgetType.Reset,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Notes = "Some notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 5,
                    PcAutoBudgetAmount = "-1012.12",
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
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "budgets",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BudgetSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BudgetSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Name = "Bills",
                    Active = false,
                    AutoBudgetAmount = "-1012.12",
                    AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
                    AutoBudgetType = AutoBudgetType.Reset,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Notes = "Some notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 5,
                    PcAutoBudgetAmount = "-1012.12",
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
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "budgets",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BudgetSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BudgetRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Name = "Bills",
                Active = false,
                AutoBudgetAmount = "-1012.12",
                AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
                AutoBudgetType = AutoBudgetType.Reset,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                Notes = "Some notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 5,
                PcAutoBudgetAmount = "-1012.12",
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
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "budgets",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BudgetSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Name = "Bills",
                    Active = false,
                    AutoBudgetAmount = "-1012.12",
                    AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
                    AutoBudgetType = AutoBudgetType.Reset,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Notes = "Some notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 5,
                    PcAutoBudgetAmount = "-1012.12",
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
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "budgets",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BudgetSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Name = "Bills",
                    Active = false,
                    AutoBudgetAmount = "-1012.12",
                    AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
                    AutoBudgetType = AutoBudgetType.Reset,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Notes = "Some notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 5,
                    PcAutoBudgetAmount = "-1012.12",
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
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "budgets",
            },
        };

        BudgetSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
