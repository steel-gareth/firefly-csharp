using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Recurrences;

namespace EmceesProdTesting5.Tests.Models.Recurrences;

public class RecurrenceArrayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurrenceArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        Active = true,
                        ApplyRules = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Recurring transaction for the monthly rent",
                        FirstDate = "2026-04-30",
                        LatestDate = "2026-04-01",
                        Notes = "Some notes",
                        NrOfRepetitions = 5,
                        RepeatUntil = "2026-04-30",
                        Repetitions =
                        [
                            new()
                            {
                                Moment = "3",
                                Type = RecurrenceRepetitionType.Weekly,
                                ID = "2",
                                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Description = "Every week on Friday",
                                Occurrences = [DateTimeOffset.Parse("2026-04-30T23:59:59+00:00")],
                                Skip = 0,
                                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Weekend = 1,
                            },
                        ],
                        Title = "Rent",
                        Transactions =
                        [
                            new()
                            {
                                Amount = "123.45",
                                Description = "Rent for the current month",
                                ID =
                                    "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
                                BudgetID = "4",
                                BudgetName = "Groceries",
                                CategoryID = "211",
                                CategoryName = "Bills",
                                CurrencyCode = "EUR",
                                CurrencyDecimalPlaces = 2,
                                CurrencyID = "5",
                                CurrencyName = "Euro",
                                CurrencySymbol = "$",
                                DestinationIban = "NL02ABNA0123456789",
                                DestinationID = "258",
                                DestinationName = "Buy and Large",
                                DestinationType = AccountTypeProperty.AssetAccount,
                                ForeignAmount = "123.45",
                                ForeignCurrencyCode = "GBP",
                                ForeignCurrencyDecimalPlaces = 2,
                                ForeignCurrencyID = "17",
                                ForeignCurrencyName = "British Pound",
                                ForeignCurrencySymbol = "$",
                                ObjectHasCurrencySetting = true,
                                PcAmount = "123.45",
                                PcForeignAmount = "123.45",
                                PiggyBankID = "123",
                                PiggyBankName = "piggy_bank_name",
                                PrimaryCurrencyCode = "EUR",
                                PrimaryCurrencyDecimalPlaces = 2,
                                PrimaryCurrencyID = "5",
                                PrimaryCurrencyName = "Euro",
                                PrimaryCurrencySymbol = "$",
                                SourceIban = "NL02ABNA0123456789",
                                SourceID = "913",
                                SourceName = "Checking account",
                                SourceType = AccountTypeProperty.AssetAccount,
                                SubscriptionID = "123",
                                SubscriptionName = "subscription_name",
                                Tags = ["Barbecue preparation"],
                            },
                        ],
                        Type = RecurrenceTransactionType.Withdrawal,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "recurrences",
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

        List<RecurrenceRead> expectedData =
        [
            new()
            {
                ID = "2",
                Attributes = new()
                {
                    Active = true,
                    ApplyRules = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Recurring transaction for the monthly rent",
                    FirstDate = "2026-04-30",
                    LatestDate = "2026-04-01",
                    Notes = "Some notes",
                    NrOfRepetitions = 5,
                    RepeatUntil = "2026-04-30",
                    Repetitions =
                    [
                        new()
                        {
                            Moment = "3",
                            Type = RecurrenceRepetitionType.Weekly,
                            ID = "2",
                            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            Description = "Every week on Friday",
                            Occurrences = [DateTimeOffset.Parse("2026-04-30T23:59:59+00:00")],
                            Skip = 0,
                            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            Weekend = 1,
                        },
                    ],
                    Title = "Rent",
                    Transactions =
                    [
                        new()
                        {
                            Amount = "123.45",
                            Description = "Rent for the current month",
                            ID =
                                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
                            BudgetID = "4",
                            BudgetName = "Groceries",
                            CategoryID = "211",
                            CategoryName = "Bills",
                            CurrencyCode = "EUR",
                            CurrencyDecimalPlaces = 2,
                            CurrencyID = "5",
                            CurrencyName = "Euro",
                            CurrencySymbol = "$",
                            DestinationIban = "NL02ABNA0123456789",
                            DestinationID = "258",
                            DestinationName = "Buy and Large",
                            DestinationType = AccountTypeProperty.AssetAccount,
                            ForeignAmount = "123.45",
                            ForeignCurrencyCode = "GBP",
                            ForeignCurrencyDecimalPlaces = 2,
                            ForeignCurrencyID = "17",
                            ForeignCurrencyName = "British Pound",
                            ForeignCurrencySymbol = "$",
                            ObjectHasCurrencySetting = true,
                            PcAmount = "123.45",
                            PcForeignAmount = "123.45",
                            PiggyBankID = "123",
                            PiggyBankName = "piggy_bank_name",
                            PrimaryCurrencyCode = "EUR",
                            PrimaryCurrencyDecimalPlaces = 2,
                            PrimaryCurrencyID = "5",
                            PrimaryCurrencyName = "Euro",
                            PrimaryCurrencySymbol = "$",
                            SourceIban = "NL02ABNA0123456789",
                            SourceID = "913",
                            SourceName = "Checking account",
                            SourceType = AccountTypeProperty.AssetAccount,
                            SubscriptionID = "123",
                            SubscriptionName = "subscription_name",
                            Tags = ["Barbecue preparation"],
                        },
                    ],
                    Type = RecurrenceTransactionType.Withdrawal,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "recurrences",
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
        var model = new RecurrenceArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        Active = true,
                        ApplyRules = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Recurring transaction for the monthly rent",
                        FirstDate = "2026-04-30",
                        LatestDate = "2026-04-01",
                        Notes = "Some notes",
                        NrOfRepetitions = 5,
                        RepeatUntil = "2026-04-30",
                        Repetitions =
                        [
                            new()
                            {
                                Moment = "3",
                                Type = RecurrenceRepetitionType.Weekly,
                                ID = "2",
                                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Description = "Every week on Friday",
                                Occurrences = [DateTimeOffset.Parse("2026-04-30T23:59:59+00:00")],
                                Skip = 0,
                                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Weekend = 1,
                            },
                        ],
                        Title = "Rent",
                        Transactions =
                        [
                            new()
                            {
                                Amount = "123.45",
                                Description = "Rent for the current month",
                                ID =
                                    "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
                                BudgetID = "4",
                                BudgetName = "Groceries",
                                CategoryID = "211",
                                CategoryName = "Bills",
                                CurrencyCode = "EUR",
                                CurrencyDecimalPlaces = 2,
                                CurrencyID = "5",
                                CurrencyName = "Euro",
                                CurrencySymbol = "$",
                                DestinationIban = "NL02ABNA0123456789",
                                DestinationID = "258",
                                DestinationName = "Buy and Large",
                                DestinationType = AccountTypeProperty.AssetAccount,
                                ForeignAmount = "123.45",
                                ForeignCurrencyCode = "GBP",
                                ForeignCurrencyDecimalPlaces = 2,
                                ForeignCurrencyID = "17",
                                ForeignCurrencyName = "British Pound",
                                ForeignCurrencySymbol = "$",
                                ObjectHasCurrencySetting = true,
                                PcAmount = "123.45",
                                PcForeignAmount = "123.45",
                                PiggyBankID = "123",
                                PiggyBankName = "piggy_bank_name",
                                PrimaryCurrencyCode = "EUR",
                                PrimaryCurrencyDecimalPlaces = 2,
                                PrimaryCurrencyID = "5",
                                PrimaryCurrencyName = "Euro",
                                PrimaryCurrencySymbol = "$",
                                SourceIban = "NL02ABNA0123456789",
                                SourceID = "913",
                                SourceName = "Checking account",
                                SourceType = AccountTypeProperty.AssetAccount,
                                SubscriptionID = "123",
                                SubscriptionName = "subscription_name",
                                Tags = ["Barbecue preparation"],
                            },
                        ],
                        Type = RecurrenceTransactionType.Withdrawal,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "recurrences",
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
        var deserialized = JsonSerializer.Deserialize<RecurrenceArray>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurrenceArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        Active = true,
                        ApplyRules = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Recurring transaction for the monthly rent",
                        FirstDate = "2026-04-30",
                        LatestDate = "2026-04-01",
                        Notes = "Some notes",
                        NrOfRepetitions = 5,
                        RepeatUntil = "2026-04-30",
                        Repetitions =
                        [
                            new()
                            {
                                Moment = "3",
                                Type = RecurrenceRepetitionType.Weekly,
                                ID = "2",
                                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Description = "Every week on Friday",
                                Occurrences = [DateTimeOffset.Parse("2026-04-30T23:59:59+00:00")],
                                Skip = 0,
                                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Weekend = 1,
                            },
                        ],
                        Title = "Rent",
                        Transactions =
                        [
                            new()
                            {
                                Amount = "123.45",
                                Description = "Rent for the current month",
                                ID =
                                    "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
                                BudgetID = "4",
                                BudgetName = "Groceries",
                                CategoryID = "211",
                                CategoryName = "Bills",
                                CurrencyCode = "EUR",
                                CurrencyDecimalPlaces = 2,
                                CurrencyID = "5",
                                CurrencyName = "Euro",
                                CurrencySymbol = "$",
                                DestinationIban = "NL02ABNA0123456789",
                                DestinationID = "258",
                                DestinationName = "Buy and Large",
                                DestinationType = AccountTypeProperty.AssetAccount,
                                ForeignAmount = "123.45",
                                ForeignCurrencyCode = "GBP",
                                ForeignCurrencyDecimalPlaces = 2,
                                ForeignCurrencyID = "17",
                                ForeignCurrencyName = "British Pound",
                                ForeignCurrencySymbol = "$",
                                ObjectHasCurrencySetting = true,
                                PcAmount = "123.45",
                                PcForeignAmount = "123.45",
                                PiggyBankID = "123",
                                PiggyBankName = "piggy_bank_name",
                                PrimaryCurrencyCode = "EUR",
                                PrimaryCurrencyDecimalPlaces = 2,
                                PrimaryCurrencyID = "5",
                                PrimaryCurrencyName = "Euro",
                                PrimaryCurrencySymbol = "$",
                                SourceIban = "NL02ABNA0123456789",
                                SourceID = "913",
                                SourceName = "Checking account",
                                SourceType = AccountTypeProperty.AssetAccount,
                                SubscriptionID = "123",
                                SubscriptionName = "subscription_name",
                                Tags = ["Barbecue preparation"],
                            },
                        ],
                        Type = RecurrenceTransactionType.Withdrawal,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "recurrences",
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
        var deserialized = JsonSerializer.Deserialize<RecurrenceArray>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<RecurrenceRead> expectedData =
        [
            new()
            {
                ID = "2",
                Attributes = new()
                {
                    Active = true,
                    ApplyRules = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Recurring transaction for the monthly rent",
                    FirstDate = "2026-04-30",
                    LatestDate = "2026-04-01",
                    Notes = "Some notes",
                    NrOfRepetitions = 5,
                    RepeatUntil = "2026-04-30",
                    Repetitions =
                    [
                        new()
                        {
                            Moment = "3",
                            Type = RecurrenceRepetitionType.Weekly,
                            ID = "2",
                            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            Description = "Every week on Friday",
                            Occurrences = [DateTimeOffset.Parse("2026-04-30T23:59:59+00:00")],
                            Skip = 0,
                            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            Weekend = 1,
                        },
                    ],
                    Title = "Rent",
                    Transactions =
                    [
                        new()
                        {
                            Amount = "123.45",
                            Description = "Rent for the current month",
                            ID =
                                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
                            BudgetID = "4",
                            BudgetName = "Groceries",
                            CategoryID = "211",
                            CategoryName = "Bills",
                            CurrencyCode = "EUR",
                            CurrencyDecimalPlaces = 2,
                            CurrencyID = "5",
                            CurrencyName = "Euro",
                            CurrencySymbol = "$",
                            DestinationIban = "NL02ABNA0123456789",
                            DestinationID = "258",
                            DestinationName = "Buy and Large",
                            DestinationType = AccountTypeProperty.AssetAccount,
                            ForeignAmount = "123.45",
                            ForeignCurrencyCode = "GBP",
                            ForeignCurrencyDecimalPlaces = 2,
                            ForeignCurrencyID = "17",
                            ForeignCurrencyName = "British Pound",
                            ForeignCurrencySymbol = "$",
                            ObjectHasCurrencySetting = true,
                            PcAmount = "123.45",
                            PcForeignAmount = "123.45",
                            PiggyBankID = "123",
                            PiggyBankName = "piggy_bank_name",
                            PrimaryCurrencyCode = "EUR",
                            PrimaryCurrencyDecimalPlaces = 2,
                            PrimaryCurrencyID = "5",
                            PrimaryCurrencyName = "Euro",
                            PrimaryCurrencySymbol = "$",
                            SourceIban = "NL02ABNA0123456789",
                            SourceID = "913",
                            SourceName = "Checking account",
                            SourceType = AccountTypeProperty.AssetAccount,
                            SubscriptionID = "123",
                            SubscriptionName = "subscription_name",
                            Tags = ["Barbecue preparation"],
                        },
                    ],
                    Type = RecurrenceTransactionType.Withdrawal,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "recurrences",
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
        var model = new RecurrenceArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        Active = true,
                        ApplyRules = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Recurring transaction for the monthly rent",
                        FirstDate = "2026-04-30",
                        LatestDate = "2026-04-01",
                        Notes = "Some notes",
                        NrOfRepetitions = 5,
                        RepeatUntil = "2026-04-30",
                        Repetitions =
                        [
                            new()
                            {
                                Moment = "3",
                                Type = RecurrenceRepetitionType.Weekly,
                                ID = "2",
                                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Description = "Every week on Friday",
                                Occurrences = [DateTimeOffset.Parse("2026-04-30T23:59:59+00:00")],
                                Skip = 0,
                                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Weekend = 1,
                            },
                        ],
                        Title = "Rent",
                        Transactions =
                        [
                            new()
                            {
                                Amount = "123.45",
                                Description = "Rent for the current month",
                                ID =
                                    "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
                                BudgetID = "4",
                                BudgetName = "Groceries",
                                CategoryID = "211",
                                CategoryName = "Bills",
                                CurrencyCode = "EUR",
                                CurrencyDecimalPlaces = 2,
                                CurrencyID = "5",
                                CurrencyName = "Euro",
                                CurrencySymbol = "$",
                                DestinationIban = "NL02ABNA0123456789",
                                DestinationID = "258",
                                DestinationName = "Buy and Large",
                                DestinationType = AccountTypeProperty.AssetAccount,
                                ForeignAmount = "123.45",
                                ForeignCurrencyCode = "GBP",
                                ForeignCurrencyDecimalPlaces = 2,
                                ForeignCurrencyID = "17",
                                ForeignCurrencyName = "British Pound",
                                ForeignCurrencySymbol = "$",
                                ObjectHasCurrencySetting = true,
                                PcAmount = "123.45",
                                PcForeignAmount = "123.45",
                                PiggyBankID = "123",
                                PiggyBankName = "piggy_bank_name",
                                PrimaryCurrencyCode = "EUR",
                                PrimaryCurrencyDecimalPlaces = 2,
                                PrimaryCurrencyID = "5",
                                PrimaryCurrencyName = "Euro",
                                PrimaryCurrencySymbol = "$",
                                SourceIban = "NL02ABNA0123456789",
                                SourceID = "913",
                                SourceName = "Checking account",
                                SourceType = AccountTypeProperty.AssetAccount,
                                SubscriptionID = "123",
                                SubscriptionName = "subscription_name",
                                Tags = ["Barbecue preparation"],
                            },
                        ],
                        Type = RecurrenceTransactionType.Withdrawal,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "recurrences",
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
        var model = new RecurrenceArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        Active = true,
                        ApplyRules = true,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Recurring transaction for the monthly rent",
                        FirstDate = "2026-04-30",
                        LatestDate = "2026-04-01",
                        Notes = "Some notes",
                        NrOfRepetitions = 5,
                        RepeatUntil = "2026-04-30",
                        Repetitions =
                        [
                            new()
                            {
                                Moment = "3",
                                Type = RecurrenceRepetitionType.Weekly,
                                ID = "2",
                                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Description = "Every week on Friday",
                                Occurrences = [DateTimeOffset.Parse("2026-04-30T23:59:59+00:00")],
                                Skip = 0,
                                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                                Weekend = 1,
                            },
                        ],
                        Title = "Rent",
                        Transactions =
                        [
                            new()
                            {
                                Amount = "123.45",
                                Description = "Rent for the current month",
                                ID =
                                    "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
                                BudgetID = "4",
                                BudgetName = "Groceries",
                                CategoryID = "211",
                                CategoryName = "Bills",
                                CurrencyCode = "EUR",
                                CurrencyDecimalPlaces = 2,
                                CurrencyID = "5",
                                CurrencyName = "Euro",
                                CurrencySymbol = "$",
                                DestinationIban = "NL02ABNA0123456789",
                                DestinationID = "258",
                                DestinationName = "Buy and Large",
                                DestinationType = AccountTypeProperty.AssetAccount,
                                ForeignAmount = "123.45",
                                ForeignCurrencyCode = "GBP",
                                ForeignCurrencyDecimalPlaces = 2,
                                ForeignCurrencyID = "17",
                                ForeignCurrencyName = "British Pound",
                                ForeignCurrencySymbol = "$",
                                ObjectHasCurrencySetting = true,
                                PcAmount = "123.45",
                                PcForeignAmount = "123.45",
                                PiggyBankID = "123",
                                PiggyBankName = "piggy_bank_name",
                                PrimaryCurrencyCode = "EUR",
                                PrimaryCurrencyDecimalPlaces = 2,
                                PrimaryCurrencyID = "5",
                                PrimaryCurrencyName = "Euro",
                                PrimaryCurrencySymbol = "$",
                                SourceIban = "NL02ABNA0123456789",
                                SourceID = "913",
                                SourceName = "Checking account",
                                SourceType = AccountTypeProperty.AssetAccount,
                                SubscriptionID = "123",
                                SubscriptionName = "subscription_name",
                                Tags = ["Barbecue preparation"],
                            },
                        ],
                        Type = RecurrenceTransactionType.Withdrawal,
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "recurrences",
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

        RecurrenceArray copied = new(model);

        Assert.Equal(model, copied);
    }
}
