using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.AvailableBudgets;

namespace Firefly.Tests.Models.AvailableBudgets;

public class AvailableBudgetArrayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AvailableBudgetArray
        {
            Data =
            [
                new()
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

        List<AvailableBudgetRead> expectedData =
        [
            new()
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
        var model = new AvailableBudgetArray
        {
            Data =
            [
                new()
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
        var deserialized = JsonSerializer.Deserialize<AvailableBudgetArray>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AvailableBudgetArray
        {
            Data =
            [
                new()
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
        var deserialized = JsonSerializer.Deserialize<AvailableBudgetArray>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AvailableBudgetRead> expectedData =
        [
            new()
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
        var model = new AvailableBudgetArray
        {
            Data =
            [
                new()
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
        var model = new AvailableBudgetArray
        {
            Data =
            [
                new()
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

        AvailableBudgetArray copied = new(model);

        Assert.Equal(model, copied);
    }
}
