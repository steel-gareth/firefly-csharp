using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Budgets;

namespace EmceesProdTesting5.Tests.Models.Budgets;

public class BudgetListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BudgetListResponse
        {
            Data =
            [
                new()
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
            ],
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

        List<BudgetRead> expectedData =
        [
            new()
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
        ];
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
        Assert.Equal(expectedMeta, model.Meta);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BudgetListResponse
        {
            Data =
            [
                new()
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
            ],
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
        var deserialized = JsonSerializer.Deserialize<BudgetListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BudgetListResponse
        {
            Data =
            [
                new()
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
            ],
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
        var deserialized = JsonSerializer.Deserialize<BudgetListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BudgetRead> expectedData =
        [
            new()
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
        ];
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
        Assert.Equal(expectedMeta, deserialized.Meta);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BudgetListResponse
        {
            Data =
            [
                new()
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
            ],
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
        var model = new BudgetListResponse
        {
            Data =
            [
                new()
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
            ],
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

        BudgetListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
