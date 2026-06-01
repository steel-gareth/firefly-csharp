using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.PiggyBanks;

namespace Firefly.Tests.Models.Accounts;

public class PiggyBankArrayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PiggyBankArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Name = "New digital camera",
                        TargetAmount = "123.45",
                        Accounts =
                        [
                            new()
                            {
                                AccountID = "3",
                                CurrentAmount = "123.45",
                                Name = "Checking account",
                                PcCurrentAmount = "123.45",
                            },
                        ],
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        CurrentAmount = "123.45",
                        LeftToSave = "700.00",
                        Notes = "Some notes",
                        ObjectGroupID = "5",
                        ObjectGroupOrder = 5,
                        ObjectGroupTitle = "Example Group",
                        ObjectHasCurrencySetting = true,
                        Order = 5,
                        PcCurrentAmount = "123.45",
                        PcLeftToSave = "700.00",
                        PcSavePerMonth = "12.45",
                        PcTargetAmount = "123.45",
                        Percentage = 12,
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "5",
                        PrimaryCurrencyName = "Euro",
                        PrimaryCurrencySymbol = "$",
                        SavePerMonth = "12.45",
                        StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "piggy_banks",
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

        List<PiggyBankRead> expectedData =
        [
            new()
            {
                ID = "2",
                Attributes = new()
                {
                    AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "New digital camera",
                    TargetAmount = "123.45",
                    Accounts =
                    [
                        new()
                        {
                            AccountID = "3",
                            CurrentAmount = "123.45",
                            Name = "Checking account",
                            PcCurrentAmount = "123.45",
                        },
                    ],
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    CurrentAmount = "123.45",
                    LeftToSave = "700.00",
                    Notes = "Some notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 5,
                    PcCurrentAmount = "123.45",
                    PcLeftToSave = "700.00",
                    PcSavePerMonth = "12.45",
                    PcTargetAmount = "123.45",
                    Percentage = 12,
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "5",
                    PrimaryCurrencyName = "Euro",
                    PrimaryCurrencySymbol = "$",
                    SavePerMonth = "12.45",
                    StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "piggy_banks",
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
        var model = new PiggyBankArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Name = "New digital camera",
                        TargetAmount = "123.45",
                        Accounts =
                        [
                            new()
                            {
                                AccountID = "3",
                                CurrentAmount = "123.45",
                                Name = "Checking account",
                                PcCurrentAmount = "123.45",
                            },
                        ],
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        CurrentAmount = "123.45",
                        LeftToSave = "700.00",
                        Notes = "Some notes",
                        ObjectGroupID = "5",
                        ObjectGroupOrder = 5,
                        ObjectGroupTitle = "Example Group",
                        ObjectHasCurrencySetting = true,
                        Order = 5,
                        PcCurrentAmount = "123.45",
                        PcLeftToSave = "700.00",
                        PcSavePerMonth = "12.45",
                        PcTargetAmount = "123.45",
                        Percentage = 12,
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "5",
                        PrimaryCurrencyName = "Euro",
                        PrimaryCurrencySymbol = "$",
                        SavePerMonth = "12.45",
                        StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "piggy_banks",
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
        var deserialized = JsonSerializer.Deserialize<PiggyBankArray>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PiggyBankArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Name = "New digital camera",
                        TargetAmount = "123.45",
                        Accounts =
                        [
                            new()
                            {
                                AccountID = "3",
                                CurrentAmount = "123.45",
                                Name = "Checking account",
                                PcCurrentAmount = "123.45",
                            },
                        ],
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        CurrentAmount = "123.45",
                        LeftToSave = "700.00",
                        Notes = "Some notes",
                        ObjectGroupID = "5",
                        ObjectGroupOrder = 5,
                        ObjectGroupTitle = "Example Group",
                        ObjectHasCurrencySetting = true,
                        Order = 5,
                        PcCurrentAmount = "123.45",
                        PcLeftToSave = "700.00",
                        PcSavePerMonth = "12.45",
                        PcTargetAmount = "123.45",
                        Percentage = 12,
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "5",
                        PrimaryCurrencyName = "Euro",
                        PrimaryCurrencySymbol = "$",
                        SavePerMonth = "12.45",
                        StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "piggy_banks",
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
        var deserialized = JsonSerializer.Deserialize<PiggyBankArray>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PiggyBankRead> expectedData =
        [
            new()
            {
                ID = "2",
                Attributes = new()
                {
                    AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Name = "New digital camera",
                    TargetAmount = "123.45",
                    Accounts =
                    [
                        new()
                        {
                            AccountID = "3",
                            CurrentAmount = "123.45",
                            Name = "Checking account",
                            PcCurrentAmount = "123.45",
                        },
                    ],
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    CurrentAmount = "123.45",
                    LeftToSave = "700.00",
                    Notes = "Some notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 5,
                    PcCurrentAmount = "123.45",
                    PcLeftToSave = "700.00",
                    PcSavePerMonth = "12.45",
                    PcTargetAmount = "123.45",
                    Percentage = 12,
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "5",
                    PrimaryCurrencyName = "Euro",
                    PrimaryCurrencySymbol = "$",
                    SavePerMonth = "12.45",
                    StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "piggy_banks",
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
        var model = new PiggyBankArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Name = "New digital camera",
                        TargetAmount = "123.45",
                        Accounts =
                        [
                            new()
                            {
                                AccountID = "3",
                                CurrentAmount = "123.45",
                                Name = "Checking account",
                                PcCurrentAmount = "123.45",
                            },
                        ],
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        CurrentAmount = "123.45",
                        LeftToSave = "700.00",
                        Notes = "Some notes",
                        ObjectGroupID = "5",
                        ObjectGroupOrder = 5,
                        ObjectGroupTitle = "Example Group",
                        ObjectHasCurrencySetting = true,
                        Order = 5,
                        PcCurrentAmount = "123.45",
                        PcLeftToSave = "700.00",
                        PcSavePerMonth = "12.45",
                        PcTargetAmount = "123.45",
                        Percentage = 12,
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "5",
                        PrimaryCurrencyName = "Euro",
                        PrimaryCurrencySymbol = "$",
                        SavePerMonth = "12.45",
                        StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "piggy_banks",
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
        var model = new PiggyBankArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Name = "New digital camera",
                        TargetAmount = "123.45",
                        Accounts =
                        [
                            new()
                            {
                                AccountID = "3",
                                CurrentAmount = "123.45",
                                Name = "Checking account",
                                PcCurrentAmount = "123.45",
                            },
                        ],
                        Active = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        CurrentAmount = "123.45",
                        LeftToSave = "700.00",
                        Notes = "Some notes",
                        ObjectGroupID = "5",
                        ObjectGroupOrder = 5,
                        ObjectGroupTitle = "Example Group",
                        ObjectHasCurrencySetting = true,
                        Order = 5,
                        PcCurrentAmount = "123.45",
                        PcLeftToSave = "700.00",
                        PcSavePerMonth = "12.45",
                        PcTargetAmount = "123.45",
                        Percentage = 12,
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "5",
                        PrimaryCurrencyName = "Euro",
                        PrimaryCurrencySymbol = "$",
                        SavePerMonth = "12.45",
                        StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "piggy_banks",
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

        PiggyBankArray copied = new(model);

        Assert.Equal(model, copied);
    }
}
