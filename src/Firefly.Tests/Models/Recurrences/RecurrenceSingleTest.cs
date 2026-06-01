using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Recurrences;

namespace Firefly.Tests.Models.Recurrences;

public class RecurrenceSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurrenceSingle
        {
            Data = new()
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
        };

        RecurrenceRead expectedData = new()
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
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurrenceSingle
        {
            Data = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurrenceSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurrenceSingle
        {
            Data = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurrenceSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RecurrenceRead expectedData = new()
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
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurrenceSingle
        {
            Data = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurrenceSingle
        {
            Data = new()
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
        };

        RecurrenceSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
