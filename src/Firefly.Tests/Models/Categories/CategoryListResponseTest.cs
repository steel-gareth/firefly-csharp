using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Categories;

namespace Firefly.Tests.Models.Categories;

public class CategoryListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CategoryListResponse
        {
            Data =
            [
                new()
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

        List<CategoryRead> expectedData =
        [
            new()
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
        var model = new CategoryListResponse
        {
            Data =
            [
                new()
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
        var deserialized = JsonSerializer.Deserialize<CategoryListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CategoryListResponse
        {
            Data =
            [
                new()
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
        var deserialized = JsonSerializer.Deserialize<CategoryListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CategoryRead> expectedData =
        [
            new()
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
        var model = new CategoryListResponse
        {
            Data =
            [
                new()
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
        var model = new CategoryListResponse
        {
            Data =
            [
                new()
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

        CategoryListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
