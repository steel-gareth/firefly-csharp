using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.TransactionJournals;
using Attachments = Firefly.Models.Attachments;
using Recurrences = Firefly.Models.Recurrences;
using Transactions = Firefly.Models.Transactions;

namespace Firefly.Tests.Models.TransactionJournals;

public class TransactionReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransactionRead
        {
            ID = "2",
            Attributes = new()
            {
                Transactions =
                [
                    new()
                    {
                        Amount = "123.45",
                        Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Vegetables",
                        DestinationID = "2",
                        SourceID = "2",
                        Type = Transactions::TransactionTypeProperty.Withdrawal,
                        BillID = "111",
                        BillName = "Monthly rent",
                        BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        BudgetID = "4",
                        BudgetName = "Groceries",
                        CategoryID = "43",
                        CategoryName = "Groceries",
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "12",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        DestinationBalanceAfter = "123.45",
                        DestinationIban = "NL02ABNA0123456789",
                        DestinationName = "Buy and Large",
                        DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalID = "external_id",
                        ExternalUrl = "external_url",
                        ForeignAmount = "123.45",
                        ForeignCurrencyCode = "USD",
                        ForeignCurrencyDecimalPlaces = 2,
                        ForeignCurrencyID = "17",
                        ForeignCurrencySymbol = "$",
                        HasAttachments = false,
                        ImportHashV2 = "import_hash_v2",
                        InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InternalReference = "internal_reference",
                        InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Latitude = 51.983333,
                        Longitude = 5.916667,
                        Notes = "Some example notes",
                        ObjectHasCurrencySetting = true,
                        Order = 0,
                        OriginalSource = "original_source",
                        PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PcAmount = "123.45",
                        PcDestinationBalanceAfter = "123.45",
                        PcForeignAmount = "123.45",
                        PcSourceBalanceAfter = "123.45",
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "12",
                        PrimaryCurrencySymbol = "$",
                        ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Reconciled = false,
                        RecurrenceCount = 12,
                        RecurrenceID = "recurrence_id",
                        RecurrenceTotal = 0,
                        SepaBatchID = "sepa_batch_id",
                        SepaCc = "sepa_cc",
                        SepaCi = "sepa_ci",
                        SepaCountry = "sepa_country",
                        SepaCtID = "sepa_ct_id",
                        SepaCtOp = "sepa_ct_op",
                        SepaDB = "sepa_db",
                        SepaEp = "sepa_ep",
                        SourceBalanceAfter = "123.45",
                        SourceIban = "NL02ABNA0123456789",
                        SourceName = "Checking account",
                        SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                        SubscriptionID = "111",
                        SubscriptionName = "Monthly rent",
                        Tags = ["Barbecue preparation"],
                        TransactionJournalID = "10421",
                        User = "3",
                        ZoomLevel = 6,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                GroupTitle = "Split transaction title.",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                User = "3",
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactions",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            GroupTitle = "Split transaction title.",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "transactions";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransactionRead
        {
            ID = "2",
            Attributes = new()
            {
                Transactions =
                [
                    new()
                    {
                        Amount = "123.45",
                        Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Vegetables",
                        DestinationID = "2",
                        SourceID = "2",
                        Type = Transactions::TransactionTypeProperty.Withdrawal,
                        BillID = "111",
                        BillName = "Monthly rent",
                        BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        BudgetID = "4",
                        BudgetName = "Groceries",
                        CategoryID = "43",
                        CategoryName = "Groceries",
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "12",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        DestinationBalanceAfter = "123.45",
                        DestinationIban = "NL02ABNA0123456789",
                        DestinationName = "Buy and Large",
                        DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalID = "external_id",
                        ExternalUrl = "external_url",
                        ForeignAmount = "123.45",
                        ForeignCurrencyCode = "USD",
                        ForeignCurrencyDecimalPlaces = 2,
                        ForeignCurrencyID = "17",
                        ForeignCurrencySymbol = "$",
                        HasAttachments = false,
                        ImportHashV2 = "import_hash_v2",
                        InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InternalReference = "internal_reference",
                        InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Latitude = 51.983333,
                        Longitude = 5.916667,
                        Notes = "Some example notes",
                        ObjectHasCurrencySetting = true,
                        Order = 0,
                        OriginalSource = "original_source",
                        PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PcAmount = "123.45",
                        PcDestinationBalanceAfter = "123.45",
                        PcForeignAmount = "123.45",
                        PcSourceBalanceAfter = "123.45",
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "12",
                        PrimaryCurrencySymbol = "$",
                        ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Reconciled = false,
                        RecurrenceCount = 12,
                        RecurrenceID = "recurrence_id",
                        RecurrenceTotal = 0,
                        SepaBatchID = "sepa_batch_id",
                        SepaCc = "sepa_cc",
                        SepaCi = "sepa_ci",
                        SepaCountry = "sepa_country",
                        SepaCtID = "sepa_ct_id",
                        SepaCtOp = "sepa_ct_op",
                        SepaDB = "sepa_db",
                        SepaEp = "sepa_ep",
                        SourceBalanceAfter = "123.45",
                        SourceIban = "NL02ABNA0123456789",
                        SourceName = "Checking account",
                        SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                        SubscriptionID = "111",
                        SubscriptionName = "Monthly rent",
                        Tags = ["Barbecue preparation"],
                        TransactionJournalID = "10421",
                        User = "3",
                        ZoomLevel = 6,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                GroupTitle = "Split transaction title.",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                User = "3",
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransactionRead
        {
            ID = "2",
            Attributes = new()
            {
                Transactions =
                [
                    new()
                    {
                        Amount = "123.45",
                        Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Vegetables",
                        DestinationID = "2",
                        SourceID = "2",
                        Type = Transactions::TransactionTypeProperty.Withdrawal,
                        BillID = "111",
                        BillName = "Monthly rent",
                        BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        BudgetID = "4",
                        BudgetName = "Groceries",
                        CategoryID = "43",
                        CategoryName = "Groceries",
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "12",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        DestinationBalanceAfter = "123.45",
                        DestinationIban = "NL02ABNA0123456789",
                        DestinationName = "Buy and Large",
                        DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalID = "external_id",
                        ExternalUrl = "external_url",
                        ForeignAmount = "123.45",
                        ForeignCurrencyCode = "USD",
                        ForeignCurrencyDecimalPlaces = 2,
                        ForeignCurrencyID = "17",
                        ForeignCurrencySymbol = "$",
                        HasAttachments = false,
                        ImportHashV2 = "import_hash_v2",
                        InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InternalReference = "internal_reference",
                        InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Latitude = 51.983333,
                        Longitude = 5.916667,
                        Notes = "Some example notes",
                        ObjectHasCurrencySetting = true,
                        Order = 0,
                        OriginalSource = "original_source",
                        PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PcAmount = "123.45",
                        PcDestinationBalanceAfter = "123.45",
                        PcForeignAmount = "123.45",
                        PcSourceBalanceAfter = "123.45",
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "12",
                        PrimaryCurrencySymbol = "$",
                        ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Reconciled = false,
                        RecurrenceCount = 12,
                        RecurrenceID = "recurrence_id",
                        RecurrenceTotal = 0,
                        SepaBatchID = "sepa_batch_id",
                        SepaCc = "sepa_cc",
                        SepaCi = "sepa_ci",
                        SepaCountry = "sepa_country",
                        SepaCtID = "sepa_ct_id",
                        SepaCtOp = "sepa_ct_op",
                        SepaDB = "sepa_db",
                        SepaEp = "sepa_ep",
                        SourceBalanceAfter = "123.45",
                        SourceIban = "NL02ABNA0123456789",
                        SourceName = "Checking account",
                        SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                        SubscriptionID = "111",
                        SubscriptionName = "Monthly rent",
                        Tags = ["Barbecue preparation"],
                        TransactionJournalID = "10421",
                        User = "3",
                        ZoomLevel = 6,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                GroupTitle = "Split transaction title.",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                User = "3",
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            GroupTitle = "Split transaction title.",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "transactions";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransactionRead
        {
            ID = "2",
            Attributes = new()
            {
                Transactions =
                [
                    new()
                    {
                        Amount = "123.45",
                        Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Vegetables",
                        DestinationID = "2",
                        SourceID = "2",
                        Type = Transactions::TransactionTypeProperty.Withdrawal,
                        BillID = "111",
                        BillName = "Monthly rent",
                        BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        BudgetID = "4",
                        BudgetName = "Groceries",
                        CategoryID = "43",
                        CategoryName = "Groceries",
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "12",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        DestinationBalanceAfter = "123.45",
                        DestinationIban = "NL02ABNA0123456789",
                        DestinationName = "Buy and Large",
                        DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalID = "external_id",
                        ExternalUrl = "external_url",
                        ForeignAmount = "123.45",
                        ForeignCurrencyCode = "USD",
                        ForeignCurrencyDecimalPlaces = 2,
                        ForeignCurrencyID = "17",
                        ForeignCurrencySymbol = "$",
                        HasAttachments = false,
                        ImportHashV2 = "import_hash_v2",
                        InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InternalReference = "internal_reference",
                        InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Latitude = 51.983333,
                        Longitude = 5.916667,
                        Notes = "Some example notes",
                        ObjectHasCurrencySetting = true,
                        Order = 0,
                        OriginalSource = "original_source",
                        PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PcAmount = "123.45",
                        PcDestinationBalanceAfter = "123.45",
                        PcForeignAmount = "123.45",
                        PcSourceBalanceAfter = "123.45",
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "12",
                        PrimaryCurrencySymbol = "$",
                        ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Reconciled = false,
                        RecurrenceCount = 12,
                        RecurrenceID = "recurrence_id",
                        RecurrenceTotal = 0,
                        SepaBatchID = "sepa_batch_id",
                        SepaCc = "sepa_cc",
                        SepaCi = "sepa_ci",
                        SepaCountry = "sepa_country",
                        SepaCtID = "sepa_ct_id",
                        SepaCtOp = "sepa_ct_op",
                        SepaDB = "sepa_db",
                        SepaEp = "sepa_ep",
                        SourceBalanceAfter = "123.45",
                        SourceIban = "NL02ABNA0123456789",
                        SourceName = "Checking account",
                        SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                        SubscriptionID = "111",
                        SubscriptionName = "Monthly rent",
                        Tags = ["Barbecue preparation"],
                        TransactionJournalID = "10421",
                        User = "3",
                        ZoomLevel = 6,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                GroupTitle = "Split transaction title.",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                User = "3",
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactions",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransactionRead
        {
            ID = "2",
            Attributes = new()
            {
                Transactions =
                [
                    new()
                    {
                        Amount = "123.45",
                        Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        Description = "Vegetables",
                        DestinationID = "2",
                        SourceID = "2",
                        Type = Transactions::TransactionTypeProperty.Withdrawal,
                        BillID = "111",
                        BillName = "Monthly rent",
                        BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        BudgetID = "4",
                        BudgetName = "Groceries",
                        CategoryID = "43",
                        CategoryName = "Groceries",
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "12",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        DestinationBalanceAfter = "123.45",
                        DestinationIban = "NL02ABNA0123456789",
                        DestinationName = "Buy and Large",
                        DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalID = "external_id",
                        ExternalUrl = "external_url",
                        ForeignAmount = "123.45",
                        ForeignCurrencyCode = "USD",
                        ForeignCurrencyDecimalPlaces = 2,
                        ForeignCurrencyID = "17",
                        ForeignCurrencySymbol = "$",
                        HasAttachments = false,
                        ImportHashV2 = "import_hash_v2",
                        InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InternalReference = "internal_reference",
                        InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Latitude = 51.983333,
                        Longitude = 5.916667,
                        Notes = "Some example notes",
                        ObjectHasCurrencySetting = true,
                        Order = 0,
                        OriginalSource = "original_source",
                        PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PcAmount = "123.45",
                        PcDestinationBalanceAfter = "123.45",
                        PcForeignAmount = "123.45",
                        PcSourceBalanceAfter = "123.45",
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "12",
                        PrimaryCurrencySymbol = "$",
                        ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Reconciled = false,
                        RecurrenceCount = 12,
                        RecurrenceID = "recurrence_id",
                        RecurrenceTotal = 0,
                        SepaBatchID = "sepa_batch_id",
                        SepaCc = "sepa_cc",
                        SepaCi = "sepa_ci",
                        SepaCountry = "sepa_country",
                        SepaCtID = "sepa_ct_id",
                        SepaCtOp = "sepa_ct_op",
                        SepaDB = "sepa_db",
                        SepaEp = "sepa_ep",
                        SourceBalanceAfter = "123.45",
                        SourceIban = "NL02ABNA0123456789",
                        SourceName = "Checking account",
                        SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                        SubscriptionID = "111",
                        SubscriptionName = "Monthly rent",
                        Tags = ["Barbecue preparation"],
                        TransactionJournalID = "10421",
                        User = "3",
                        ZoomLevel = 6,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                GroupTitle = "Split transaction title.",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                User = "3",
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactions",
        };

        TransactionRead copied = new(model);

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
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            GroupTitle = "Split transaction title.",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
        };

        List<Transaction> expectedTransactions =
        [
            new()
            {
                Amount = "123.45",
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "Vegetables",
                DestinationID = "2",
                SourceID = "2",
                Type = Transactions::TransactionTypeProperty.Withdrawal,
                BillID = "111",
                BillName = "Monthly rent",
                BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BudgetID = "4",
                BudgetName = "Groceries",
                CategoryID = "43",
                CategoryName = "Groceries",
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "12",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                DestinationBalanceAfter = "123.45",
                DestinationIban = "NL02ABNA0123456789",
                DestinationName = "Buy and Large",
                DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalID = "external_id",
                ExternalUrl = "external_url",
                ForeignAmount = "123.45",
                ForeignCurrencyCode = "USD",
                ForeignCurrencyDecimalPlaces = 2,
                ForeignCurrencyID = "17",
                ForeignCurrencySymbol = "$",
                HasAttachments = false,
                ImportHashV2 = "import_hash_v2",
                InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InternalReference = "internal_reference",
                InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Latitude = 51.983333,
                Longitude = 5.916667,
                Notes = "Some example notes",
                ObjectHasCurrencySetting = true,
                Order = 0,
                OriginalSource = "original_source",
                PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PcAmount = "123.45",
                PcDestinationBalanceAfter = "123.45",
                PcForeignAmount = "123.45",
                PcSourceBalanceAfter = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "12",
                PrimaryCurrencySymbol = "$",
                ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Reconciled = false,
                RecurrenceCount = 12,
                RecurrenceID = "recurrence_id",
                RecurrenceTotal = 0,
                SepaBatchID = "sepa_batch_id",
                SepaCc = "sepa_cc",
                SepaCi = "sepa_ci",
                SepaCountry = "sepa_country",
                SepaCtID = "sepa_ct_id",
                SepaCtOp = "sepa_ct_op",
                SepaDB = "sepa_db",
                SepaEp = "sepa_ep",
                SourceBalanceAfter = "123.45",
                SourceIban = "NL02ABNA0123456789",
                SourceName = "Checking account",
                SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                SubscriptionID = "111",
                SubscriptionName = "Monthly rent",
                Tags = ["Barbecue preparation"],
                TransactionJournalID = "10421",
                User = "3",
                ZoomLevel = 6,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedGroupTitle = "Split transaction title.";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedUser = "3";

        Assert.Equal(expectedTransactions.Count, model.Transactions.Count);
        for (int i = 0; i < expectedTransactions.Count; i++)
        {
            Assert.Equal(expectedTransactions[i], model.Transactions[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedGroupTitle, model.GroupTitle);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            GroupTitle = "Split transaction title.",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
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
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            GroupTitle = "Split transaction title.",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Transaction> expectedTransactions =
        [
            new()
            {
                Amount = "123.45",
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "Vegetables",
                DestinationID = "2",
                SourceID = "2",
                Type = Transactions::TransactionTypeProperty.Withdrawal,
                BillID = "111",
                BillName = "Monthly rent",
                BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BudgetID = "4",
                BudgetName = "Groceries",
                CategoryID = "43",
                CategoryName = "Groceries",
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "12",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                DestinationBalanceAfter = "123.45",
                DestinationIban = "NL02ABNA0123456789",
                DestinationName = "Buy and Large",
                DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalID = "external_id",
                ExternalUrl = "external_url",
                ForeignAmount = "123.45",
                ForeignCurrencyCode = "USD",
                ForeignCurrencyDecimalPlaces = 2,
                ForeignCurrencyID = "17",
                ForeignCurrencySymbol = "$",
                HasAttachments = false,
                ImportHashV2 = "import_hash_v2",
                InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InternalReference = "internal_reference",
                InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Latitude = 51.983333,
                Longitude = 5.916667,
                Notes = "Some example notes",
                ObjectHasCurrencySetting = true,
                Order = 0,
                OriginalSource = "original_source",
                PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PcAmount = "123.45",
                PcDestinationBalanceAfter = "123.45",
                PcForeignAmount = "123.45",
                PcSourceBalanceAfter = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "12",
                PrimaryCurrencySymbol = "$",
                ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Reconciled = false,
                RecurrenceCount = 12,
                RecurrenceID = "recurrence_id",
                RecurrenceTotal = 0,
                SepaBatchID = "sepa_batch_id",
                SepaCc = "sepa_cc",
                SepaCi = "sepa_ci",
                SepaCountry = "sepa_country",
                SepaCtID = "sepa_ct_id",
                SepaCtOp = "sepa_ct_op",
                SepaDB = "sepa_db",
                SepaEp = "sepa_ep",
                SourceBalanceAfter = "123.45",
                SourceIban = "NL02ABNA0123456789",
                SourceName = "Checking account",
                SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                SubscriptionID = "111",
                SubscriptionName = "Monthly rent",
                Tags = ["Barbecue preparation"],
                TransactionJournalID = "10421",
                User = "3",
                ZoomLevel = 6,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedGroupTitle = "Split transaction title.";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedUser = "3";

        Assert.Equal(expectedTransactions.Count, deserialized.Transactions.Count);
        for (int i = 0; i < expectedTransactions.Count; i++)
        {
            Assert.Equal(expectedTransactions[i], deserialized.Transactions[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedGroupTitle, deserialized.GroupTitle);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            GroupTitle = "Split transaction title.",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            GroupTitle = "Split transaction title.",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            GroupTitle = "Split transaction title.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            GroupTitle = "Split transaction title.",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
            User = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            GroupTitle = "Split transaction title.",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
        };

        Assert.Null(model.GroupTitle);
        Assert.False(model.RawData.ContainsKey("group_title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",

            GroupTitle = null,
        };

        Assert.Null(model.GroupTitle);
        Assert.True(model.RawData.ContainsKey("group_title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",

            GroupTitle = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    DestinationID = "2",
                    SourceID = "2",
                    Type = Transactions::TransactionTypeProperty.Withdrawal,
                    BillID = "111",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "12",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    DestinationBalanceAfter = "123.45",
                    DestinationIban = "NL02ABNA0123456789",
                    DestinationName = "Buy and Large",
                    DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyDecimalPlaces = 2,
                    ForeignCurrencyID = "17",
                    ForeignCurrencySymbol = "$",
                    HasAttachments = false,
                    ImportHashV2 = "import_hash_v2",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    Notes = "Some example notes",
                    ObjectHasCurrencySetting = true,
                    Order = 0,
                    OriginalSource = "original_source",
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PcAmount = "123.45",
                    PcDestinationBalanceAfter = "123.45",
                    PcForeignAmount = "123.45",
                    PcSourceBalanceAfter = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    RecurrenceCount = 12,
                    RecurrenceID = "recurrence_id",
                    RecurrenceTotal = 0,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceBalanceAfter = "123.45",
                    SourceIban = "NL02ABNA0123456789",
                    SourceName = "Checking account",
                    SourceType = Recurrences::AccountTypeProperty.AssetAccount,
                    SubscriptionID = "111",
                    SubscriptionName = "Monthly rent",
                    Tags = ["Barbecue preparation"],
                    TransactionJournalID = "10421",
                    User = "3",
                    ZoomLevel = 6,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            GroupTitle = "Split transaction title.",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            User = "3",
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            HasAttachments = false,
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcAmount = "123.45",
            PcDestinationBalanceAfter = "123.45",
            PcForeignAmount = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            TransactionJournalID = "10421",
            User = "3",
            ZoomLevel = 6,
        };

        string expectedAmount = "123.45";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "Vegetables";
        string expectedDestinationID = "2";
        string expectedSourceID = "2";
        ApiEnum<string, Transactions::TransactionTypeProperty> expectedType =
            Transactions::TransactionTypeProperty.Withdrawal;
        string expectedBillID = "111";
        string expectedBillName = "Monthly rent";
        DateTimeOffset expectedBookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBudgetID = "4";
        string expectedBudgetName = "Groceries";
        string expectedCategoryID = "43";
        string expectedCategoryName = "Groceries";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "12";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedDestinationBalanceAfter = "123.45";
        string expectedDestinationIban = "NL02ABNA0123456789";
        string expectedDestinationName = "Buy and Large";
        ApiEnum<string, Recurrences::AccountTypeProperty> expectedDestinationType =
            Recurrences::AccountTypeProperty.AssetAccount;
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalID = "external_id";
        string expectedExternalUrl = "external_url";
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyCode = "USD";
        int expectedForeignCurrencyDecimalPlaces = 2;
        string expectedForeignCurrencyID = "17";
        string expectedForeignCurrencySymbol = "$";
        bool expectedHasAttachments = false;
        string expectedImportHashV2 = "import_hash_v2";
        DateTimeOffset expectedInterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInternalReference = "internal_reference";
        DateTimeOffset expectedInvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedLatitude = 51.983333;
        double expectedLongitude = 5.916667;
        string expectedNotes = "Some example notes";
        bool expectedObjectHasCurrencySetting = true;
        int expectedOrder = 0;
        string expectedOriginalSource = "original_source";
        DateTimeOffset expectedPaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPcAmount = "123.45";
        string expectedPcDestinationBalanceAfter = "123.45";
        string expectedPcForeignAmount = "123.45";
        string expectedPcSourceBalanceAfter = "123.45";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "12";
        string expectedPrimaryCurrencySymbol = "$";
        DateTimeOffset expectedProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedReconciled = false;
        int expectedRecurrenceCount = 12;
        string expectedRecurrenceID = "recurrence_id";
        int expectedRecurrenceTotal = 0;
        string expectedSepaBatchID = "sepa_batch_id";
        string expectedSepaCc = "sepa_cc";
        string expectedSepaCi = "sepa_ci";
        string expectedSepaCountry = "sepa_country";
        string expectedSepaCtID = "sepa_ct_id";
        string expectedSepaCtOp = "sepa_ct_op";
        string expectedSepaDB = "sepa_db";
        string expectedSepaEp = "sepa_ep";
        string expectedSourceBalanceAfter = "123.45";
        string expectedSourceIban = "NL02ABNA0123456789";
        string expectedSourceName = "Checking account";
        ApiEnum<string, Recurrences::AccountTypeProperty> expectedSourceType =
            Recurrences::AccountTypeProperty.AssetAccount;
        string expectedSubscriptionID = "111";
        string expectedSubscriptionName = "Monthly rent";
        List<string> expectedTags = ["Barbecue preparation"];
        string expectedTransactionJournalID = "10421";
        string expectedUser = "3";
        int expectedZoomLevel = 6;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDestinationID, model.DestinationID);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedBillID, model.BillID);
        Assert.Equal(expectedBillName, model.BillName);
        Assert.Equal(expectedBookDate, model.BookDate);
        Assert.Equal(expectedBudgetID, model.BudgetID);
        Assert.Equal(expectedBudgetName, model.BudgetName);
        Assert.Equal(expectedCategoryID, model.CategoryID);
        Assert.Equal(expectedCategoryName, model.CategoryName);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedDestinationBalanceAfter, model.DestinationBalanceAfter);
        Assert.Equal(expectedDestinationIban, model.DestinationIban);
        Assert.Equal(expectedDestinationName, model.DestinationName);
        Assert.Equal(expectedDestinationType, model.DestinationType);
        Assert.Equal(expectedDueDate, model.DueDate);
        Assert.Equal(expectedExternalID, model.ExternalID);
        Assert.Equal(expectedExternalUrl, model.ExternalUrl);
        Assert.Equal(expectedForeignAmount, model.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyCode, model.ForeignCurrencyCode);
        Assert.Equal(expectedForeignCurrencyDecimalPlaces, model.ForeignCurrencyDecimalPlaces);
        Assert.Equal(expectedForeignCurrencyID, model.ForeignCurrencyID);
        Assert.Equal(expectedForeignCurrencySymbol, model.ForeignCurrencySymbol);
        Assert.Equal(expectedHasAttachments, model.HasAttachments);
        Assert.Equal(expectedImportHashV2, model.ImportHashV2);
        Assert.Equal(expectedInterestDate, model.InterestDate);
        Assert.Equal(expectedInternalReference, model.InternalReference);
        Assert.Equal(expectedInvoiceDate, model.InvoiceDate);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedOriginalSource, model.OriginalSource);
        Assert.Equal(expectedPaymentDate, model.PaymentDate);
        Assert.Equal(expectedPcAmount, model.PcAmount);
        Assert.Equal(expectedPcDestinationBalanceAfter, model.PcDestinationBalanceAfter);
        Assert.Equal(expectedPcForeignAmount, model.PcForeignAmount);
        Assert.Equal(expectedPcSourceBalanceAfter, model.PcSourceBalanceAfter);
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.Equal(expectedProcessDate, model.ProcessDate);
        Assert.Equal(expectedReconciled, model.Reconciled);
        Assert.Equal(expectedRecurrenceCount, model.RecurrenceCount);
        Assert.Equal(expectedRecurrenceID, model.RecurrenceID);
        Assert.Equal(expectedRecurrenceTotal, model.RecurrenceTotal);
        Assert.Equal(expectedSepaBatchID, model.SepaBatchID);
        Assert.Equal(expectedSepaCc, model.SepaCc);
        Assert.Equal(expectedSepaCi, model.SepaCi);
        Assert.Equal(expectedSepaCountry, model.SepaCountry);
        Assert.Equal(expectedSepaCtID, model.SepaCtID);
        Assert.Equal(expectedSepaCtOp, model.SepaCtOp);
        Assert.Equal(expectedSepaDB, model.SepaDB);
        Assert.Equal(expectedSepaEp, model.SepaEp);
        Assert.Equal(expectedSourceBalanceAfter, model.SourceBalanceAfter);
        Assert.Equal(expectedSourceIban, model.SourceIban);
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
        Assert.Equal(expectedTransactionJournalID, model.TransactionJournalID);
        Assert.Equal(expectedUser, model.User);
        Assert.Equal(expectedZoomLevel, model.ZoomLevel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            HasAttachments = false,
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcAmount = "123.45",
            PcDestinationBalanceAfter = "123.45",
            PcForeignAmount = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            TransactionJournalID = "10421",
            User = "3",
            ZoomLevel = 6,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            HasAttachments = false,
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcAmount = "123.45",
            PcDestinationBalanceAfter = "123.45",
            PcForeignAmount = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            TransactionJournalID = "10421",
            User = "3",
            ZoomLevel = 6,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "123.45";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "Vegetables";
        string expectedDestinationID = "2";
        string expectedSourceID = "2";
        ApiEnum<string, Transactions::TransactionTypeProperty> expectedType =
            Transactions::TransactionTypeProperty.Withdrawal;
        string expectedBillID = "111";
        string expectedBillName = "Monthly rent";
        DateTimeOffset expectedBookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBudgetID = "4";
        string expectedBudgetName = "Groceries";
        string expectedCategoryID = "43";
        string expectedCategoryName = "Groceries";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "12";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedDestinationBalanceAfter = "123.45";
        string expectedDestinationIban = "NL02ABNA0123456789";
        string expectedDestinationName = "Buy and Large";
        ApiEnum<string, Recurrences::AccountTypeProperty> expectedDestinationType =
            Recurrences::AccountTypeProperty.AssetAccount;
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalID = "external_id";
        string expectedExternalUrl = "external_url";
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyCode = "USD";
        int expectedForeignCurrencyDecimalPlaces = 2;
        string expectedForeignCurrencyID = "17";
        string expectedForeignCurrencySymbol = "$";
        bool expectedHasAttachments = false;
        string expectedImportHashV2 = "import_hash_v2";
        DateTimeOffset expectedInterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInternalReference = "internal_reference";
        DateTimeOffset expectedInvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedLatitude = 51.983333;
        double expectedLongitude = 5.916667;
        string expectedNotes = "Some example notes";
        bool expectedObjectHasCurrencySetting = true;
        int expectedOrder = 0;
        string expectedOriginalSource = "original_source";
        DateTimeOffset expectedPaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPcAmount = "123.45";
        string expectedPcDestinationBalanceAfter = "123.45";
        string expectedPcForeignAmount = "123.45";
        string expectedPcSourceBalanceAfter = "123.45";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "12";
        string expectedPrimaryCurrencySymbol = "$";
        DateTimeOffset expectedProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedReconciled = false;
        int expectedRecurrenceCount = 12;
        string expectedRecurrenceID = "recurrence_id";
        int expectedRecurrenceTotal = 0;
        string expectedSepaBatchID = "sepa_batch_id";
        string expectedSepaCc = "sepa_cc";
        string expectedSepaCi = "sepa_ci";
        string expectedSepaCountry = "sepa_country";
        string expectedSepaCtID = "sepa_ct_id";
        string expectedSepaCtOp = "sepa_ct_op";
        string expectedSepaDB = "sepa_db";
        string expectedSepaEp = "sepa_ep";
        string expectedSourceBalanceAfter = "123.45";
        string expectedSourceIban = "NL02ABNA0123456789";
        string expectedSourceName = "Checking account";
        ApiEnum<string, Recurrences::AccountTypeProperty> expectedSourceType =
            Recurrences::AccountTypeProperty.AssetAccount;
        string expectedSubscriptionID = "111";
        string expectedSubscriptionName = "Monthly rent";
        List<string> expectedTags = ["Barbecue preparation"];
        string expectedTransactionJournalID = "10421";
        string expectedUser = "3";
        int expectedZoomLevel = 6;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDestinationID, deserialized.DestinationID);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedBillID, deserialized.BillID);
        Assert.Equal(expectedBillName, deserialized.BillName);
        Assert.Equal(expectedBookDate, deserialized.BookDate);
        Assert.Equal(expectedBudgetID, deserialized.BudgetID);
        Assert.Equal(expectedBudgetName, deserialized.BudgetName);
        Assert.Equal(expectedCategoryID, deserialized.CategoryID);
        Assert.Equal(expectedCategoryName, deserialized.CategoryName);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedDestinationBalanceAfter, deserialized.DestinationBalanceAfter);
        Assert.Equal(expectedDestinationIban, deserialized.DestinationIban);
        Assert.Equal(expectedDestinationName, deserialized.DestinationName);
        Assert.Equal(expectedDestinationType, deserialized.DestinationType);
        Assert.Equal(expectedDueDate, deserialized.DueDate);
        Assert.Equal(expectedExternalID, deserialized.ExternalID);
        Assert.Equal(expectedExternalUrl, deserialized.ExternalUrl);
        Assert.Equal(expectedForeignAmount, deserialized.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyCode, deserialized.ForeignCurrencyCode);
        Assert.Equal(
            expectedForeignCurrencyDecimalPlaces,
            deserialized.ForeignCurrencyDecimalPlaces
        );
        Assert.Equal(expectedForeignCurrencyID, deserialized.ForeignCurrencyID);
        Assert.Equal(expectedForeignCurrencySymbol, deserialized.ForeignCurrencySymbol);
        Assert.Equal(expectedHasAttachments, deserialized.HasAttachments);
        Assert.Equal(expectedImportHashV2, deserialized.ImportHashV2);
        Assert.Equal(expectedInterestDate, deserialized.InterestDate);
        Assert.Equal(expectedInternalReference, deserialized.InternalReference);
        Assert.Equal(expectedInvoiceDate, deserialized.InvoiceDate);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedOriginalSource, deserialized.OriginalSource);
        Assert.Equal(expectedPaymentDate, deserialized.PaymentDate);
        Assert.Equal(expectedPcAmount, deserialized.PcAmount);
        Assert.Equal(expectedPcDestinationBalanceAfter, deserialized.PcDestinationBalanceAfter);
        Assert.Equal(expectedPcForeignAmount, deserialized.PcForeignAmount);
        Assert.Equal(expectedPcSourceBalanceAfter, deserialized.PcSourceBalanceAfter);
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.Equal(expectedProcessDate, deserialized.ProcessDate);
        Assert.Equal(expectedReconciled, deserialized.Reconciled);
        Assert.Equal(expectedRecurrenceCount, deserialized.RecurrenceCount);
        Assert.Equal(expectedRecurrenceID, deserialized.RecurrenceID);
        Assert.Equal(expectedRecurrenceTotal, deserialized.RecurrenceTotal);
        Assert.Equal(expectedSepaBatchID, deserialized.SepaBatchID);
        Assert.Equal(expectedSepaCc, deserialized.SepaCc);
        Assert.Equal(expectedSepaCi, deserialized.SepaCi);
        Assert.Equal(expectedSepaCountry, deserialized.SepaCountry);
        Assert.Equal(expectedSepaCtID, deserialized.SepaCtID);
        Assert.Equal(expectedSepaCtOp, deserialized.SepaCtOp);
        Assert.Equal(expectedSepaDB, deserialized.SepaDB);
        Assert.Equal(expectedSepaEp, deserialized.SepaEp);
        Assert.Equal(expectedSourceBalanceAfter, deserialized.SourceBalanceAfter);
        Assert.Equal(expectedSourceIban, deserialized.SourceIban);
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
        Assert.Equal(expectedTransactionJournalID, deserialized.TransactionJournalID);
        Assert.Equal(expectedUser, deserialized.User);
        Assert.Equal(expectedZoomLevel, deserialized.ZoomLevel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            HasAttachments = false,
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcAmount = "123.45",
            PcDestinationBalanceAfter = "123.45",
            PcForeignAmount = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            TransactionJournalID = "10421",
            User = "3",
            ZoomLevel = 6,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcDestinationBalanceAfter = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            ZoomLevel = 6,
        };

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
        Assert.Null(model.DestinationType);
        Assert.False(model.RawData.ContainsKey("destination_type"));
        Assert.Null(model.HasAttachments);
        Assert.False(model.RawData.ContainsKey("has_attachments"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
        Assert.Null(model.PcForeignAmount);
        Assert.False(model.RawData.ContainsKey("pc_foreign_amount"));
        Assert.Null(model.Reconciled);
        Assert.False(model.RawData.ContainsKey("reconciled"));
        Assert.Null(model.SourceType);
        Assert.False(model.RawData.ContainsKey("source_type"));
        Assert.Null(model.TransactionJournalID);
        Assert.False(model.RawData.ContainsKey("transaction_journal_id"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcDestinationBalanceAfter = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            ZoomLevel = 6,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcDestinationBalanceAfter = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            ZoomLevel = 6,

            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            DestinationType = null,
            HasAttachments = null,
            ObjectHasCurrencySetting = null,
            PcAmount = null,
            PcForeignAmount = null,
            Reconciled = null,
            SourceType = null,
            TransactionJournalID = null,
            User = null,
        };

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
        Assert.Null(model.DestinationType);
        Assert.False(model.RawData.ContainsKey("destination_type"));
        Assert.Null(model.HasAttachments);
        Assert.False(model.RawData.ContainsKey("has_attachments"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
        Assert.Null(model.PcForeignAmount);
        Assert.False(model.RawData.ContainsKey("pc_foreign_amount"));
        Assert.Null(model.Reconciled);
        Assert.False(model.RawData.ContainsKey("reconciled"));
        Assert.Null(model.SourceType);
        Assert.False(model.RawData.ContainsKey("source_type"));
        Assert.Null(model.TransactionJournalID);
        Assert.False(model.RawData.ContainsKey("transaction_journal_id"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcDestinationBalanceAfter = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            ZoomLevel = 6,

            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            DestinationType = null,
            HasAttachments = null,
            ObjectHasCurrencySetting = null,
            PcAmount = null,
            PcForeignAmount = null,
            Reconciled = null,
            SourceType = null,
            TransactionJournalID = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            HasAttachments = false,
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcForeignAmount = "123.45",
            Reconciled = false,
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            TransactionJournalID = "10421",
            User = "3",
        };

        Assert.Null(model.BillID);
        Assert.False(model.RawData.ContainsKey("bill_id"));
        Assert.Null(model.BillName);
        Assert.False(model.RawData.ContainsKey("bill_name"));
        Assert.Null(model.BookDate);
        Assert.False(model.RawData.ContainsKey("book_date"));
        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
        Assert.Null(model.BudgetName);
        Assert.False(model.RawData.ContainsKey("budget_name"));
        Assert.Null(model.CategoryID);
        Assert.False(model.RawData.ContainsKey("category_id"));
        Assert.Null(model.CategoryName);
        Assert.False(model.RawData.ContainsKey("category_name"));
        Assert.Null(model.DestinationBalanceAfter);
        Assert.False(model.RawData.ContainsKey("destination_balance_after"));
        Assert.Null(model.DestinationIban);
        Assert.False(model.RawData.ContainsKey("destination_iban"));
        Assert.Null(model.DestinationName);
        Assert.False(model.RawData.ContainsKey("destination_name"));
        Assert.Null(model.DueDate);
        Assert.False(model.RawData.ContainsKey("due_date"));
        Assert.Null(model.ExternalID);
        Assert.False(model.RawData.ContainsKey("external_id"));
        Assert.Null(model.ExternalUrl);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.ForeignAmount);
        Assert.False(model.RawData.ContainsKey("foreign_amount"));
        Assert.Null(model.ForeignCurrencyCode);
        Assert.False(model.RawData.ContainsKey("foreign_currency_code"));
        Assert.Null(model.ForeignCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("foreign_currency_decimal_places"));
        Assert.Null(model.ForeignCurrencyID);
        Assert.False(model.RawData.ContainsKey("foreign_currency_id"));
        Assert.Null(model.ForeignCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("foreign_currency_symbol"));
        Assert.Null(model.ImportHashV2);
        Assert.False(model.RawData.ContainsKey("import_hash_v2"));
        Assert.Null(model.InterestDate);
        Assert.False(model.RawData.ContainsKey("interest_date"));
        Assert.Null(model.InternalReference);
        Assert.False(model.RawData.ContainsKey("internal_reference"));
        Assert.Null(model.InvoiceDate);
        Assert.False(model.RawData.ContainsKey("invoice_date"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.OriginalSource);
        Assert.False(model.RawData.ContainsKey("original_source"));
        Assert.Null(model.PaymentDate);
        Assert.False(model.RawData.ContainsKey("payment_date"));
        Assert.Null(model.PcDestinationBalanceAfter);
        Assert.False(model.RawData.ContainsKey("pc_destination_balance_after"));
        Assert.Null(model.PcSourceBalanceAfter);
        Assert.False(model.RawData.ContainsKey("pc_source_balance_after"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.ProcessDate);
        Assert.False(model.RawData.ContainsKey("process_date"));
        Assert.Null(model.RecurrenceCount);
        Assert.False(model.RawData.ContainsKey("recurrence_count"));
        Assert.Null(model.RecurrenceID);
        Assert.False(model.RawData.ContainsKey("recurrence_id"));
        Assert.Null(model.RecurrenceTotal);
        Assert.False(model.RawData.ContainsKey("recurrence_total"));
        Assert.Null(model.SepaBatchID);
        Assert.False(model.RawData.ContainsKey("sepa_batch_id"));
        Assert.Null(model.SepaCc);
        Assert.False(model.RawData.ContainsKey("sepa_cc"));
        Assert.Null(model.SepaCi);
        Assert.False(model.RawData.ContainsKey("sepa_ci"));
        Assert.Null(model.SepaCountry);
        Assert.False(model.RawData.ContainsKey("sepa_country"));
        Assert.Null(model.SepaCtID);
        Assert.False(model.RawData.ContainsKey("sepa_ct_id"));
        Assert.Null(model.SepaCtOp);
        Assert.False(model.RawData.ContainsKey("sepa_ct_op"));
        Assert.Null(model.SepaDB);
        Assert.False(model.RawData.ContainsKey("sepa_db"));
        Assert.Null(model.SepaEp);
        Assert.False(model.RawData.ContainsKey("sepa_ep"));
        Assert.Null(model.SourceBalanceAfter);
        Assert.False(model.RawData.ContainsKey("source_balance_after"));
        Assert.Null(model.SourceIban);
        Assert.False(model.RawData.ContainsKey("source_iban"));
        Assert.Null(model.SourceName);
        Assert.False(model.RawData.ContainsKey("source_name"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.SubscriptionName);
        Assert.False(model.RawData.ContainsKey("subscription_name"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.ZoomLevel);
        Assert.False(model.RawData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            HasAttachments = false,
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcForeignAmount = "123.45",
            Reconciled = false,
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            TransactionJournalID = "10421",
            User = "3",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            HasAttachments = false,
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcForeignAmount = "123.45",
            Reconciled = false,
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            TransactionJournalID = "10421",
            User = "3",

            BillID = null,
            BillName = null,
            BookDate = null,
            BudgetID = null,
            BudgetName = null,
            CategoryID = null,
            CategoryName = null,
            DestinationBalanceAfter = null,
            DestinationIban = null,
            DestinationName = null,
            DueDate = null,
            ExternalID = null,
            ExternalUrl = null,
            ForeignAmount = null,
            ForeignCurrencyCode = null,
            ForeignCurrencyDecimalPlaces = null,
            ForeignCurrencyID = null,
            ForeignCurrencySymbol = null,
            ImportHashV2 = null,
            InterestDate = null,
            InternalReference = null,
            InvoiceDate = null,
            Latitude = null,
            Longitude = null,
            Notes = null,
            Order = null,
            OriginalSource = null,
            PaymentDate = null,
            PcDestinationBalanceAfter = null,
            PcSourceBalanceAfter = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencySymbol = null,
            ProcessDate = null,
            RecurrenceCount = null,
            RecurrenceID = null,
            RecurrenceTotal = null,
            SepaBatchID = null,
            SepaCc = null,
            SepaCi = null,
            SepaCountry = null,
            SepaCtID = null,
            SepaCtOp = null,
            SepaDB = null,
            SepaEp = null,
            SourceBalanceAfter = null,
            SourceIban = null,
            SourceName = null,
            SubscriptionID = null,
            SubscriptionName = null,
            Tags = null,
            ZoomLevel = null,
        };

        Assert.Null(model.BillID);
        Assert.True(model.RawData.ContainsKey("bill_id"));
        Assert.Null(model.BillName);
        Assert.True(model.RawData.ContainsKey("bill_name"));
        Assert.Null(model.BookDate);
        Assert.True(model.RawData.ContainsKey("book_date"));
        Assert.Null(model.BudgetID);
        Assert.True(model.RawData.ContainsKey("budget_id"));
        Assert.Null(model.BudgetName);
        Assert.True(model.RawData.ContainsKey("budget_name"));
        Assert.Null(model.CategoryID);
        Assert.True(model.RawData.ContainsKey("category_id"));
        Assert.Null(model.CategoryName);
        Assert.True(model.RawData.ContainsKey("category_name"));
        Assert.Null(model.DestinationBalanceAfter);
        Assert.True(model.RawData.ContainsKey("destination_balance_after"));
        Assert.Null(model.DestinationIban);
        Assert.True(model.RawData.ContainsKey("destination_iban"));
        Assert.Null(model.DestinationName);
        Assert.True(model.RawData.ContainsKey("destination_name"));
        Assert.Null(model.DueDate);
        Assert.True(model.RawData.ContainsKey("due_date"));
        Assert.Null(model.ExternalID);
        Assert.True(model.RawData.ContainsKey("external_id"));
        Assert.Null(model.ExternalUrl);
        Assert.True(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.ForeignAmount);
        Assert.True(model.RawData.ContainsKey("foreign_amount"));
        Assert.Null(model.ForeignCurrencyCode);
        Assert.True(model.RawData.ContainsKey("foreign_currency_code"));
        Assert.Null(model.ForeignCurrencyDecimalPlaces);
        Assert.True(model.RawData.ContainsKey("foreign_currency_decimal_places"));
        Assert.Null(model.ForeignCurrencyID);
        Assert.True(model.RawData.ContainsKey("foreign_currency_id"));
        Assert.Null(model.ForeignCurrencySymbol);
        Assert.True(model.RawData.ContainsKey("foreign_currency_symbol"));
        Assert.Null(model.ImportHashV2);
        Assert.True(model.RawData.ContainsKey("import_hash_v2"));
        Assert.Null(model.InterestDate);
        Assert.True(model.RawData.ContainsKey("interest_date"));
        Assert.Null(model.InternalReference);
        Assert.True(model.RawData.ContainsKey("internal_reference"));
        Assert.Null(model.InvoiceDate);
        Assert.True(model.RawData.ContainsKey("invoice_date"));
        Assert.Null(model.Latitude);
        Assert.True(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Longitude);
        Assert.True(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Order);
        Assert.True(model.RawData.ContainsKey("order"));
        Assert.Null(model.OriginalSource);
        Assert.True(model.RawData.ContainsKey("original_source"));
        Assert.Null(model.PaymentDate);
        Assert.True(model.RawData.ContainsKey("payment_date"));
        Assert.Null(model.PcDestinationBalanceAfter);
        Assert.True(model.RawData.ContainsKey("pc_destination_balance_after"));
        Assert.Null(model.PcSourceBalanceAfter);
        Assert.True(model.RawData.ContainsKey("pc_source_balance_after"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.True(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.True(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.True(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.True(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.ProcessDate);
        Assert.True(model.RawData.ContainsKey("process_date"));
        Assert.Null(model.RecurrenceCount);
        Assert.True(model.RawData.ContainsKey("recurrence_count"));
        Assert.Null(model.RecurrenceID);
        Assert.True(model.RawData.ContainsKey("recurrence_id"));
        Assert.Null(model.RecurrenceTotal);
        Assert.True(model.RawData.ContainsKey("recurrence_total"));
        Assert.Null(model.SepaBatchID);
        Assert.True(model.RawData.ContainsKey("sepa_batch_id"));
        Assert.Null(model.SepaCc);
        Assert.True(model.RawData.ContainsKey("sepa_cc"));
        Assert.Null(model.SepaCi);
        Assert.True(model.RawData.ContainsKey("sepa_ci"));
        Assert.Null(model.SepaCountry);
        Assert.True(model.RawData.ContainsKey("sepa_country"));
        Assert.Null(model.SepaCtID);
        Assert.True(model.RawData.ContainsKey("sepa_ct_id"));
        Assert.Null(model.SepaCtOp);
        Assert.True(model.RawData.ContainsKey("sepa_ct_op"));
        Assert.Null(model.SepaDB);
        Assert.True(model.RawData.ContainsKey("sepa_db"));
        Assert.Null(model.SepaEp);
        Assert.True(model.RawData.ContainsKey("sepa_ep"));
        Assert.Null(model.SourceBalanceAfter);
        Assert.True(model.RawData.ContainsKey("source_balance_after"));
        Assert.Null(model.SourceIban);
        Assert.True(model.RawData.ContainsKey("source_iban"));
        Assert.Null(model.SourceName);
        Assert.True(model.RawData.ContainsKey("source_name"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.SubscriptionName);
        Assert.True(model.RawData.ContainsKey("subscription_name"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
        Assert.Null(model.ZoomLevel);
        Assert.True(model.RawData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            HasAttachments = false,
            ObjectHasCurrencySetting = true,
            PcAmount = "123.45",
            PcForeignAmount = "123.45",
            Reconciled = false,
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            TransactionJournalID = "10421",
            User = "3",

            BillID = null,
            BillName = null,
            BookDate = null,
            BudgetID = null,
            BudgetName = null,
            CategoryID = null,
            CategoryName = null,
            DestinationBalanceAfter = null,
            DestinationIban = null,
            DestinationName = null,
            DueDate = null,
            ExternalID = null,
            ExternalUrl = null,
            ForeignAmount = null,
            ForeignCurrencyCode = null,
            ForeignCurrencyDecimalPlaces = null,
            ForeignCurrencyID = null,
            ForeignCurrencySymbol = null,
            ImportHashV2 = null,
            InterestDate = null,
            InternalReference = null,
            InvoiceDate = null,
            Latitude = null,
            Longitude = null,
            Notes = null,
            Order = null,
            OriginalSource = null,
            PaymentDate = null,
            PcDestinationBalanceAfter = null,
            PcSourceBalanceAfter = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencySymbol = null,
            ProcessDate = null,
            RecurrenceCount = null,
            RecurrenceID = null,
            RecurrenceTotal = null,
            SepaBatchID = null,
            SepaCc = null,
            SepaCi = null,
            SepaCountry = null,
            SepaCtID = null,
            SepaCtOp = null,
            SepaDB = null,
            SepaEp = null,
            SourceBalanceAfter = null,
            SourceIban = null,
            SourceName = null,
            SubscriptionID = null,
            SubscriptionName = null,
            Tags = null,
            ZoomLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            DestinationID = "2",
            SourceID = "2",
            Type = Transactions::TransactionTypeProperty.Withdrawal,
            BillID = "111",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            DestinationBalanceAfter = "123.45",
            DestinationIban = "NL02ABNA0123456789",
            DestinationName = "Buy and Large",
            DestinationType = Recurrences::AccountTypeProperty.AssetAccount,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyDecimalPlaces = 2,
            ForeignCurrencyID = "17",
            ForeignCurrencySymbol = "$",
            HasAttachments = false,
            ImportHashV2 = "import_hash_v2",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Latitude = 51.983333,
            Longitude = 5.916667,
            Notes = "Some example notes",
            ObjectHasCurrencySetting = true,
            Order = 0,
            OriginalSource = "original_source",
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PcAmount = "123.45",
            PcDestinationBalanceAfter = "123.45",
            PcForeignAmount = "123.45",
            PcSourceBalanceAfter = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "12",
            PrimaryCurrencySymbol = "$",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            RecurrenceCount = 12,
            RecurrenceID = "recurrence_id",
            RecurrenceTotal = 0,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceBalanceAfter = "123.45",
            SourceIban = "NL02ABNA0123456789",
            SourceName = "Checking account",
            SourceType = Recurrences::AccountTypeProperty.AssetAccount,
            SubscriptionID = "111",
            SubscriptionName = "Monthly rent",
            Tags = ["Barbecue preparation"],
            TransactionJournalID = "10421",
            User = "3",
            ZoomLevel = 6,
        };

        Transaction copied = new(model);

        Assert.Equal(model, copied);
    }
}
