using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Recurrences;
using Attachments = EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Models.Recurrences;

public class RecurrenceReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurrenceRead
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

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "recurrences";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurrenceRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurrenceRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurrenceRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurrenceRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "recurrences";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurrenceRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurrenceRead
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

        RecurrenceRead copied = new(model);

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
        };

        bool expectedActive = true;
        bool expectedApplyRules = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "Recurring transaction for the monthly rent";
        string expectedFirstDate = "2026-04-30";
        string expectedLatestDate = "2026-04-01";
        string expectedNotes = "Some notes";
        int expectedNrOfRepetitions = 5;
        string expectedRepeatUntil = "2026-04-30";
        List<AttributesRepetition> expectedRepetitions =
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
        ];
        string expectedTitle = "Rent";
        List<AttributesTransaction> expectedTransactions =
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
        ];
        ApiEnum<string, RecurrenceTransactionType> expectedType =
            RecurrenceTransactionType.Withdrawal;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedApplyRules, model.ApplyRules);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFirstDate, model.FirstDate);
        Assert.Equal(expectedLatestDate, model.LatestDate);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedNrOfRepetitions, model.NrOfRepetitions);
        Assert.Equal(expectedRepeatUntil, model.RepeatUntil);
        Assert.NotNull(model.Repetitions);
        Assert.Equal(expectedRepetitions.Count, model.Repetitions.Count);
        for (int i = 0; i < expectedRepetitions.Count; i++)
        {
            Assert.Equal(expectedRepetitions[i], model.Repetitions[i]);
        }
        Assert.Equal(expectedTitle, model.Title);
        Assert.NotNull(model.Transactions);
        Assert.Equal(expectedTransactions.Count, model.Transactions.Count);
        for (int i = 0; i < expectedTransactions.Count; i++)
        {
            Assert.Equal(expectedTransactions[i], model.Transactions[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActive = true;
        bool expectedApplyRules = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "Recurring transaction for the monthly rent";
        string expectedFirstDate = "2026-04-30";
        string expectedLatestDate = "2026-04-01";
        string expectedNotes = "Some notes";
        int expectedNrOfRepetitions = 5;
        string expectedRepeatUntil = "2026-04-30";
        List<AttributesRepetition> expectedRepetitions =
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
        ];
        string expectedTitle = "Rent";
        List<AttributesTransaction> expectedTransactions =
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
        ];
        ApiEnum<string, RecurrenceTransactionType> expectedType =
            RecurrenceTransactionType.Withdrawal;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedApplyRules, deserialized.ApplyRules);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFirstDate, deserialized.FirstDate);
        Assert.Equal(expectedLatestDate, deserialized.LatestDate);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedNrOfRepetitions, deserialized.NrOfRepetitions);
        Assert.Equal(expectedRepeatUntil, deserialized.RepeatUntil);
        Assert.NotNull(deserialized.Repetitions);
        Assert.Equal(expectedRepetitions.Count, deserialized.Repetitions.Count);
        for (int i = 0; i < expectedRepetitions.Count; i++)
        {
            Assert.Equal(expectedRepetitions[i], deserialized.Repetitions[i]);
        }
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.NotNull(deserialized.Transactions);
        Assert.Equal(expectedTransactions.Count, deserialized.Transactions.Count);
        for (int i = 0; i < expectedTransactions.Count; i++)
        {
            Assert.Equal(expectedTransactions[i], deserialized.Transactions[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            LatestDate = "2026-04-01",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            RepeatUntil = "2026-04-30",
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.ApplyRules);
        Assert.False(model.RawData.ContainsKey("apply_rules"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FirstDate);
        Assert.False(model.RawData.ContainsKey("first_date"));
        Assert.Null(model.Repetitions);
        Assert.False(model.RawData.ContainsKey("repetitions"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Transactions);
        Assert.False(model.RawData.ContainsKey("transactions"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            LatestDate = "2026-04-01",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            RepeatUntil = "2026-04-30",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            LatestDate = "2026-04-01",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            RepeatUntil = "2026-04-30",

            // Null should be interpreted as omitted for these properties
            Active = null,
            ApplyRules = null,
            CreatedAt = null,
            Description = null,
            FirstDate = null,
            Repetitions = null,
            Title = null,
            Transactions = null,
            Type = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.ApplyRules);
        Assert.False(model.RawData.ContainsKey("apply_rules"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FirstDate);
        Assert.False(model.RawData.ContainsKey("first_date"));
        Assert.Null(model.Repetitions);
        Assert.False(model.RawData.ContainsKey("repetitions"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Transactions);
        Assert.False(model.RawData.ContainsKey("transactions"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            LatestDate = "2026-04-01",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            RepeatUntil = "2026-04-30",

            // Null should be interpreted as omitted for these properties
            Active = null,
            ApplyRules = null,
            CreatedAt = null,
            Description = null,
            FirstDate = null,
            Repetitions = null,
            Title = null,
            Transactions = null,
            Type = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Active = true,
            ApplyRules = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Recurring transaction for the monthly rent",
            FirstDate = "2026-04-30",
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
        };

        Assert.Null(model.LatestDate);
        Assert.False(model.RawData.ContainsKey("latest_date"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.NrOfRepetitions);
        Assert.False(model.RawData.ContainsKey("nr_of_repetitions"));
        Assert.Null(model.RepeatUntil);
        Assert.False(model.RawData.ContainsKey("repeat_until"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Active = true,
            ApplyRules = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Recurring transaction for the monthly rent",
            FirstDate = "2026-04-30",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            Active = true,
            ApplyRules = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Recurring transaction for the monthly rent",
            FirstDate = "2026-04-30",
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

            LatestDate = null,
            Notes = null,
            NrOfRepetitions = null,
            RepeatUntil = null,
        };

        Assert.Null(model.LatestDate);
        Assert.True(model.RawData.ContainsKey("latest_date"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.NrOfRepetitions);
        Assert.True(model.RawData.ContainsKey("nr_of_repetitions"));
        Assert.Null(model.RepeatUntil);
        Assert.True(model.RawData.ContainsKey("repeat_until"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Active = true,
            ApplyRules = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Recurring transaction for the monthly rent",
            FirstDate = "2026-04-30",
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

            LatestDate = null,
            Notes = null,
            NrOfRepetitions = null,
            RepeatUntil = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
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
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttributesRepetitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttributesRepetition
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
        };

        string expectedMoment = "3";
        ApiEnum<string, RecurrenceRepetitionType> expectedType = RecurrenceRepetitionType.Weekly;
        string expectedID = "2";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "Every week on Friday";
        List<DateTimeOffset> expectedOccurrences =
        [
            DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
        ];
        int expectedSkip = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedWeekend = 1;

        Assert.Equal(expectedMoment, model.Moment);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Occurrences);
        Assert.Equal(expectedOccurrences.Count, model.Occurrences.Count);
        for (int i = 0; i < expectedOccurrences.Count; i++)
        {
            Assert.Equal(expectedOccurrences[i], model.Occurrences[i]);
        }
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWeekend, model.Weekend);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttributesRepetition
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttributesRepetition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttributesRepetition
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttributesRepetition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMoment = "3";
        ApiEnum<string, RecurrenceRepetitionType> expectedType = RecurrenceRepetitionType.Weekly;
        string expectedID = "2";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "Every week on Friday";
        List<DateTimeOffset> expectedOccurrences =
        [
            DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
        ];
        int expectedSkip = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedWeekend = 1;

        Assert.Equal(expectedMoment, deserialized.Moment);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Occurrences);
        Assert.Equal(expectedOccurrences.Count, deserialized.Occurrences.Count);
        for (int i = 0; i < expectedOccurrences.Count; i++)
        {
            Assert.Equal(expectedOccurrences[i], deserialized.Occurrences[i]);
        }
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWeekend, deserialized.Weekend);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttributesRepetition
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AttributesRepetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Occurrences);
        Assert.False(model.RawData.ContainsKey("occurrences"));
        Assert.Null(model.Skip);
        Assert.False(model.RawData.ContainsKey("skip"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Weekend);
        Assert.False(model.RawData.ContainsKey("weekend"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AttributesRepetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AttributesRepetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            Occurrences = null,
            Skip = null,
            UpdatedAt = null,
            Weekend = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Occurrences);
        Assert.False(model.RawData.ContainsKey("occurrences"));
        Assert.Null(model.Skip);
        Assert.False(model.RawData.ContainsKey("skip"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Weekend);
        Assert.False(model.RawData.ContainsKey("weekend"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AttributesRepetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            Occurrences = null,
            Skip = null,
            UpdatedAt = null,
            Weekend = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttributesRepetition
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
        };

        AttributesRepetition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttributesTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttributesTransaction
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
        };

        string expectedAmount = "123.45";
        string expectedDescription = "Rent for the current month";
        string expectedID =
            "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.";
        string expectedBudgetID = "4";
        string expectedBudgetName = "Groceries";
        string expectedCategoryID = "211";
        string expectedCategoryName = "Bills";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedDestinationIban = "NL02ABNA0123456789";
        string expectedDestinationID = "258";
        string expectedDestinationName = "Buy and Large";
        ApiEnum<string, AccountTypeProperty> expectedDestinationType =
            AccountTypeProperty.AssetAccount;
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyCode = "GBP";
        int expectedForeignCurrencyDecimalPlaces = 2;
        string expectedForeignCurrencyID = "17";
        string expectedForeignCurrencyName = "British Pound";
        string expectedForeignCurrencySymbol = "$";
        bool expectedObjectHasCurrencySetting = true;
        string expectedPcAmount = "123.45";
        string expectedPcForeignAmount = "123.45";
        string expectedPiggyBankID = "123";
        string expectedPiggyBankName = "piggy_bank_name";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        string expectedSourceIban = "NL02ABNA0123456789";
        string expectedSourceID = "913";
        string expectedSourceName = "Checking account";
        ApiEnum<string, AccountTypeProperty> expectedSourceType = AccountTypeProperty.AssetAccount;
        string expectedSubscriptionID = "123";
        string expectedSubscriptionName = "subscription_name";
        List<string> expectedTags = ["Barbecue preparation"];

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBudgetID, model.BudgetID);
        Assert.Equal(expectedBudgetName, model.BudgetName);
        Assert.Equal(expectedCategoryID, model.CategoryID);
        Assert.Equal(expectedCategoryName, model.CategoryName);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedDestinationIban, model.DestinationIban);
        Assert.Equal(expectedDestinationID, model.DestinationID);
        Assert.Equal(expectedDestinationName, model.DestinationName);
        Assert.Equal(expectedDestinationType, model.DestinationType);
        Assert.Equal(expectedForeignAmount, model.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyCode, model.ForeignCurrencyCode);
        Assert.Equal(expectedForeignCurrencyDecimalPlaces, model.ForeignCurrencyDecimalPlaces);
        Assert.Equal(expectedForeignCurrencyID, model.ForeignCurrencyID);
        Assert.Equal(expectedForeignCurrencyName, model.ForeignCurrencyName);
        Assert.Equal(expectedForeignCurrencySymbol, model.ForeignCurrencySymbol);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.Equal(expectedPcAmount, model.PcAmount);
        Assert.Equal(expectedPcForeignAmount, model.PcForeignAmount);
        Assert.Equal(expectedPiggyBankID, model.PiggyBankID);
        Assert.Equal(expectedPiggyBankName, model.PiggyBankName);
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, model.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.Equal(expectedSourceIban, model.SourceIban);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedSourceName, model.SourceName);
        Assert.Equal(expectedSourceType, model.SourceType);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedSubscriptionName, model.SubscriptionName);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttributesTransaction
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttributesTransaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttributesTransaction
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttributesTransaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "123.45";
        string expectedDescription = "Rent for the current month";
        string expectedID =
            "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.";
        string expectedBudgetID = "4";
        string expectedBudgetName = "Groceries";
        string expectedCategoryID = "211";
        string expectedCategoryName = "Bills";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedDestinationIban = "NL02ABNA0123456789";
        string expectedDestinationID = "258";
        string expectedDestinationName = "Buy and Large";
        ApiEnum<string, AccountTypeProperty> expectedDestinationType =
            AccountTypeProperty.AssetAccount;
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyCode = "GBP";
        int expectedForeignCurrencyDecimalPlaces = 2;
        string expectedForeignCurrencyID = "17";
        string expectedForeignCurrencyName = "British Pound";
        string expectedForeignCurrencySymbol = "$";
        bool expectedObjectHasCurrencySetting = true;
        string expectedPcAmount = "123.45";
        string expectedPcForeignAmount = "123.45";
        string expectedPiggyBankID = "123";
        string expectedPiggyBankName = "piggy_bank_name";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        string expectedSourceIban = "NL02ABNA0123456789";
        string expectedSourceID = "913";
        string expectedSourceName = "Checking account";
        ApiEnum<string, AccountTypeProperty> expectedSourceType = AccountTypeProperty.AssetAccount;
        string expectedSubscriptionID = "123";
        string expectedSubscriptionName = "subscription_name";
        List<string> expectedTags = ["Barbecue preparation"];

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBudgetID, deserialized.BudgetID);
        Assert.Equal(expectedBudgetName, deserialized.BudgetName);
        Assert.Equal(expectedCategoryID, deserialized.CategoryID);
        Assert.Equal(expectedCategoryName, deserialized.CategoryName);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedDestinationIban, deserialized.DestinationIban);
        Assert.Equal(expectedDestinationID, deserialized.DestinationID);
        Assert.Equal(expectedDestinationName, deserialized.DestinationName);
        Assert.Equal(expectedDestinationType, deserialized.DestinationType);
        Assert.Equal(expectedForeignAmount, deserialized.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyCode, deserialized.ForeignCurrencyCode);
        Assert.Equal(
            expectedForeignCurrencyDecimalPlaces,
            deserialized.ForeignCurrencyDecimalPlaces
        );
        Assert.Equal(expectedForeignCurrencyID, deserialized.ForeignCurrencyID);
        Assert.Equal(expectedForeignCurrencyName, deserialized.ForeignCurrencyName);
        Assert.Equal(expectedForeignCurrencySymbol, deserialized.ForeignCurrencySymbol);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.Equal(expectedPcAmount, deserialized.PcAmount);
        Assert.Equal(expectedPcForeignAmount, deserialized.PcForeignAmount);
        Assert.Equal(expectedPiggyBankID, deserialized.PiggyBankID);
        Assert.Equal(expectedPiggyBankName, deserialized.PiggyBankName);
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, deserialized.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.Equal(expectedSourceIban, deserialized.SourceIban);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedSourceName, deserialized.SourceName);
        Assert.Equal(expectedSourceType, deserialized.SourceType);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedSubscriptionName, deserialized.SubscriptionName);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttributesTransaction
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AttributesTransaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            BudgetName = "Groceries",
            DestinationIban = "NL02ABNA0123456789",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencyName = "British Pound",
            ForeignCurrencySymbol = "$",
            PcForeignAmount = "123.45",
            PiggyBankID = "123",
            PiggyBankName = "piggy_bank_name",
            SourceIban = "NL02ABNA0123456789",
            SubscriptionID = "123",
            SubscriptionName = "subscription_name",
            Tags = ["Barbecue preparation"],
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
        Assert.Null(model.CategoryID);
        Assert.False(model.RawData.ContainsKey("category_id"));
        Assert.Null(model.CategoryName);
        Assert.False(model.RawData.ContainsKey("category_name"));
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
        Assert.Null(model.DestinationID);
        Assert.False(model.RawData.ContainsKey("destination_id"));
        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destination_name"));
        Assert.Null(model.DestinationType);
        Assert.False(model.RawData.ContainsKey("destination_type"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
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
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
        Assert.Null(model.SourceName);
        Assert.False(model.RawData.ContainsKey("source_name"));
        Assert.Null(model.SourceType);
        Assert.False(model.RawData.ContainsKey("source_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AttributesTransaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            BudgetName = "Groceries",
            DestinationIban = "NL02ABNA0123456789",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencyName = "British Pound",
            ForeignCurrencySymbol = "$",
            PcForeignAmount = "123.45",
            PiggyBankID = "123",
            PiggyBankName = "piggy_bank_name",
            SourceIban = "NL02ABNA0123456789",
            SubscriptionID = "123",
            SubscriptionName = "subscription_name",
            Tags = ["Barbecue preparation"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AttributesTransaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            BudgetName = "Groceries",
            DestinationIban = "NL02ABNA0123456789",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencyName = "British Pound",
            ForeignCurrencySymbol = "$",
            PcForeignAmount = "123.45",
            PiggyBankID = "123",
            PiggyBankName = "piggy_bank_name",
            SourceIban = "NL02ABNA0123456789",
            SubscriptionID = "123",
            SubscriptionName = "subscription_name",
            Tags = ["Barbecue preparation"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            BudgetID = null,
            CategoryID = null,
            CategoryName = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            DestinationID = null,
            DestinationName = null,
            DestinationType = null,
            ObjectHasCurrencySetting = null,
            PcAmount = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            SourceID = null,
            SourceName = null,
            SourceType = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
        Assert.Null(model.CategoryID);
        Assert.False(model.RawData.ContainsKey("category_id"));
        Assert.Null(model.CategoryName);
        Assert.False(model.RawData.ContainsKey("category_name"));
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
        Assert.Null(model.DestinationID);
        Assert.False(model.RawData.ContainsKey("destination_id"));
        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destination_name"));
        Assert.Null(model.DestinationType);
        Assert.False(model.RawData.ContainsKey("destination_type"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
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
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
        Assert.Null(model.SourceName);
        Assert.False(model.RawData.ContainsKey("source_name"));
        Assert.Null(model.SourceType);
        Assert.False(model.RawData.ContainsKey("source_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AttributesTransaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            BudgetName = "Groceries",
            DestinationIban = "NL02ABNA0123456789",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencyName = "British Pound",
            ForeignCurrencySymbol = "$",
            PcForeignAmount = "123.45",
            PiggyBankID = "123",
            PiggyBankName = "piggy_bank_name",
            SourceIban = "NL02ABNA0123456789",
            SubscriptionID = "123",
            SubscriptionName = "subscription_name",
            Tags = ["Barbecue preparation"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            BudgetID = null,
            CategoryID = null,
            CategoryName = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            DestinationID = null,
            DestinationName = null,
            DestinationType = null,
            ObjectHasCurrencySetting = null,
            PcAmount = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            SourceID = null,
            SourceName = null,
            SourceType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AttributesTransaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
            BudgetID = "4",
            CategoryID = "211",
            CategoryName = "Bills",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationID = "258",
            DestinationName = "Buy and Large",
            DestinationType = AccountTypeProperty.AssetAccount,
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SourceID = "913",
            SourceName = "Checking account",
            SourceType = AccountTypeProperty.AssetAccount,
        };

        Assert.Null(model.BudgetName);
        Assert.False(model.RawData.ContainsKey("budget_name"));
        Assert.Null(model.DestinationIban);
        Assert.False(model.RawData.ContainsKey("destination_iban"));
        Assert.Null(model.ForeignAmount);
        Assert.False(model.RawData.ContainsKey("foreign_amount"));
        Assert.Null(model.ForeignCurrencyCode);
        Assert.False(model.RawData.ContainsKey("foreign_currency_code"));
        Assert.Null(model.ForeignCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("foreign_currency_decimal_places"));
        Assert.Null(model.ForeignCurrencyID);
        Assert.False(model.RawData.ContainsKey("foreign_currency_id"));
        Assert.Null(model.ForeignCurrencyName);
        Assert.False(model.RawData.ContainsKey("foreign_currency_name"));
        Assert.Null(model.ForeignCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("foreign_currency_symbol"));
        Assert.Null(model.PcForeignAmount);
        Assert.False(model.RawData.ContainsKey("pc_foreign_amount"));
        Assert.Null(model.PiggyBankID);
        Assert.False(model.RawData.ContainsKey("piggy_bank_id"));
        Assert.Null(model.PiggyBankName);
        Assert.False(model.RawData.ContainsKey("piggy_bank_name"));
        Assert.Null(model.SourceIban);
        Assert.False(model.RawData.ContainsKey("source_iban"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.SubscriptionName);
        Assert.False(model.RawData.ContainsKey("subscription_name"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AttributesTransaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
            BudgetID = "4",
            CategoryID = "211",
            CategoryName = "Bills",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationID = "258",
            DestinationName = "Buy and Large",
            DestinationType = AccountTypeProperty.AssetAccount,
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SourceID = "913",
            SourceName = "Checking account",
            SourceType = AccountTypeProperty.AssetAccount,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AttributesTransaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
            BudgetID = "4",
            CategoryID = "211",
            CategoryName = "Bills",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationID = "258",
            DestinationName = "Buy and Large",
            DestinationType = AccountTypeProperty.AssetAccount,
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SourceID = "913",
            SourceName = "Checking account",
            SourceType = AccountTypeProperty.AssetAccount,

            BudgetName = null,
            DestinationIban = null,
            ForeignAmount = null,
            ForeignCurrencyCode = null,
            ForeignCurrencyDecimalPlaces = null,
            ForeignCurrencyID = null,
            ForeignCurrencyName = null,
            ForeignCurrencySymbol = null,
            PcForeignAmount = null,
            PiggyBankID = null,
            PiggyBankName = null,
            SourceIban = null,
            SubscriptionID = null,
            SubscriptionName = null,
            Tags = null,
        };

        Assert.Null(model.BudgetName);
        Assert.True(model.RawData.ContainsKey("budget_name"));
        Assert.Null(model.DestinationIban);
        Assert.True(model.RawData.ContainsKey("destination_iban"));
        Assert.Null(model.ForeignAmount);
        Assert.True(model.RawData.ContainsKey("foreign_amount"));
        Assert.Null(model.ForeignCurrencyCode);
        Assert.True(model.RawData.ContainsKey("foreign_currency_code"));
        Assert.Null(model.ForeignCurrencyDecimalPlaces);
        Assert.True(model.RawData.ContainsKey("foreign_currency_decimal_places"));
        Assert.Null(model.ForeignCurrencyID);
        Assert.True(model.RawData.ContainsKey("foreign_currency_id"));
        Assert.Null(model.ForeignCurrencyName);
        Assert.True(model.RawData.ContainsKey("foreign_currency_name"));
        Assert.Null(model.ForeignCurrencySymbol);
        Assert.True(model.RawData.ContainsKey("foreign_currency_symbol"));
        Assert.Null(model.PcForeignAmount);
        Assert.True(model.RawData.ContainsKey("pc_foreign_amount"));
        Assert.Null(model.PiggyBankID);
        Assert.True(model.RawData.ContainsKey("piggy_bank_id"));
        Assert.Null(model.PiggyBankName);
        Assert.True(model.RawData.ContainsKey("piggy_bank_name"));
        Assert.Null(model.SourceIban);
        Assert.True(model.RawData.ContainsKey("source_iban"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.SubscriptionName);
        Assert.True(model.RawData.ContainsKey("subscription_name"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AttributesTransaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself.",
            BudgetID = "4",
            CategoryID = "211",
            CategoryName = "Bills",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationID = "258",
            DestinationName = "Buy and Large",
            DestinationType = AccountTypeProperty.AssetAccount,
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SourceID = "913",
            SourceName = "Checking account",
            SourceType = AccountTypeProperty.AssetAccount,

            BudgetName = null,
            DestinationIban = null,
            ForeignAmount = null,
            ForeignCurrencyCode = null,
            ForeignCurrencyDecimalPlaces = null,
            ForeignCurrencyID = null,
            ForeignCurrencyName = null,
            ForeignCurrencySymbol = null,
            PcForeignAmount = null,
            PiggyBankID = null,
            PiggyBankName = null,
            SourceIban = null,
            SubscriptionID = null,
            SubscriptionName = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttributesTransaction
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
        };

        AttributesTransaction copied = new(model);

        Assert.Equal(model, copied);
    }
}
