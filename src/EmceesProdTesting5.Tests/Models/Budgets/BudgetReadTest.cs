using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Budgets;
using AvailableBudgets = EmceesProdTesting5.Models.AvailableBudgets;

namespace EmceesProdTesting5.Tests.Models.Budgets;

public class BudgetReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BudgetRead
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

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        string expectedType = "budgets";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BudgetRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BudgetRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BudgetRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BudgetRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        string expectedType = "budgets";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BudgetRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BudgetRead
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

        BudgetRead copied = new(model);

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
        };

        string expectedName = "Bills";
        bool expectedActive = false;
        string expectedAutoBudgetAmount = "-1012.12";
        ApiEnum<string, AutoBudgetPeriod> expectedAutoBudgetPeriod = AutoBudgetPeriod.Monthly;
        ApiEnum<string, AutoBudgetType> expectedAutoBudgetType = AutoBudgetType.Reset;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedNotes = "Some notes";
        string expectedObjectGroupID = "5";
        int expectedObjectGroupOrder = 5;
        string expectedObjectGroupTitle = "Example Group";
        bool expectedObjectHasCurrencySetting = true;
        int expectedOrder = 5;
        string expectedPcAutoBudgetAmount = "-1012.12";
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedAutoBudgetAmount, model.AutoBudgetAmount);
        Assert.Equal(expectedAutoBudgetPeriod, model.AutoBudgetPeriod);
        Assert.Equal(expectedAutoBudgetType, model.AutoBudgetType);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedObjectGroupID, model.ObjectGroupID);
        Assert.Equal(expectedObjectGroupOrder, model.ObjectGroupOrder);
        Assert.Equal(expectedObjectGroupTitle, model.ObjectGroupTitle);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedPcAutoBudgetAmount, model.PcAutoBudgetAmount);
        Assert.NotNull(model.PcSpent);
        Assert.Equal(expectedPcSpent.Count, model.PcSpent.Count);
        for (int i = 0; i < expectedPcSpent.Count; i++)
        {
            Assert.Equal(expectedPcSpent[i], model.PcSpent[i]);
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
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "Bills";
        bool expectedActive = false;
        string expectedAutoBudgetAmount = "-1012.12";
        ApiEnum<string, AutoBudgetPeriod> expectedAutoBudgetPeriod = AutoBudgetPeriod.Monthly;
        ApiEnum<string, AutoBudgetType> expectedAutoBudgetType = AutoBudgetType.Reset;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedNotes = "Some notes";
        string expectedObjectGroupID = "5";
        int expectedObjectGroupOrder = 5;
        string expectedObjectGroupTitle = "Example Group";
        bool expectedObjectHasCurrencySetting = true;
        int expectedOrder = 5;
        string expectedPcAutoBudgetAmount = "-1012.12";
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedAutoBudgetAmount, deserialized.AutoBudgetAmount);
        Assert.Equal(expectedAutoBudgetPeriod, deserialized.AutoBudgetPeriod);
        Assert.Equal(expectedAutoBudgetType, deserialized.AutoBudgetType);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedObjectGroupID, deserialized.ObjectGroupID);
        Assert.Equal(expectedObjectGroupOrder, deserialized.ObjectGroupOrder);
        Assert.Equal(expectedObjectGroupTitle, deserialized.ObjectGroupTitle);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedPcAutoBudgetAmount, deserialized.PcAutoBudgetAmount);
        Assert.NotNull(deserialized.PcSpent);
        Assert.Equal(expectedPcSpent.Count, deserialized.PcSpent.Count);
        for (int i = 0; i < expectedPcSpent.Count; i++)
        {
            Assert.Equal(expectedPcSpent[i], deserialized.PcSpent[i]);
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
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Name = "Bills",
            AutoBudgetAmount = "-1012.12",
            AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
            AutoBudgetType = AutoBudgetType.Reset,
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            PcAutoBudgetAmount = "-1012.12",
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
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
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
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
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Name = "Bills",
            AutoBudgetAmount = "-1012.12",
            AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
            AutoBudgetType = AutoBudgetType.Reset,
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            PcAutoBudgetAmount = "-1012.12",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Name = "Bills",
            AutoBudgetAmount = "-1012.12",
            AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
            AutoBudgetType = AutoBudgetType.Reset,
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            PcAutoBudgetAmount = "-1012.12",

            // Null should be interpreted as omitted for these properties
            Active = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            ObjectHasCurrencySetting = null,
            Order = null,
            PcSpent = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            Spent = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
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
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
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
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Name = "Bills",
            AutoBudgetAmount = "-1012.12",
            AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
            AutoBudgetType = AutoBudgetType.Reset,
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            PcAutoBudgetAmount = "-1012.12",

            // Null should be interpreted as omitted for these properties
            Active = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            ObjectHasCurrencySetting = null,
            Order = null,
            PcSpent = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            Spent = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Name = "Bills",
            Active = false,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            ObjectHasCurrencySetting = true,
            Order = 5,
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
        };

        Assert.Null(model.AutoBudgetAmount);
        Assert.False(model.RawData.ContainsKey("auto_budget_amount"));
        Assert.Null(model.AutoBudgetPeriod);
        Assert.False(model.RawData.ContainsKey("auto_budget_period"));
        Assert.Null(model.AutoBudgetType);
        Assert.False(model.RawData.ContainsKey("auto_budget_type"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.ObjectGroupID);
        Assert.False(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupOrder);
        Assert.False(model.RawData.ContainsKey("object_group_order"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.False(model.RawData.ContainsKey("object_group_title"));
        Assert.Null(model.PcAutoBudgetAmount);
        Assert.False(model.RawData.ContainsKey("pc_auto_budget_amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Name = "Bills",
            Active = false,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            ObjectHasCurrencySetting = true,
            Order = 5,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            Name = "Bills",
            Active = false,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            ObjectHasCurrencySetting = true,
            Order = 5,
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

            AutoBudgetAmount = null,
            AutoBudgetPeriod = null,
            AutoBudgetType = null,
            Notes = null,
            ObjectGroupID = null,
            ObjectGroupOrder = null,
            ObjectGroupTitle = null,
            PcAutoBudgetAmount = null,
        };

        Assert.Null(model.AutoBudgetAmount);
        Assert.True(model.RawData.ContainsKey("auto_budget_amount"));
        Assert.Null(model.AutoBudgetPeriod);
        Assert.True(model.RawData.ContainsKey("auto_budget_period"));
        Assert.Null(model.AutoBudgetType);
        Assert.True(model.RawData.ContainsKey("auto_budget_type"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.ObjectGroupID);
        Assert.True(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupOrder);
        Assert.True(model.RawData.ContainsKey("object_group_order"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.True(model.RawData.ContainsKey("object_group_title"));
        Assert.Null(model.PcAutoBudgetAmount);
        Assert.True(model.RawData.ContainsKey("pc_auto_budget_amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Name = "Bills",
            Active = false,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            ObjectHasCurrencySetting = true,
            Order = 5,
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

            AutoBudgetAmount = null,
            AutoBudgetPeriod = null,
            AutoBudgetType = null,
            Notes = null,
            ObjectGroupID = null,
            ObjectGroupOrder = null,
            ObjectGroupTitle = null,
            PcAutoBudgetAmount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
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
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
