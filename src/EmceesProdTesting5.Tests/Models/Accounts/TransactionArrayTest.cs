using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Recurrences;
using EmceesProdTesting5.Models.TransactionJournals;
using EmceesProdTesting5.Models.Transactions;

namespace EmceesProdTesting5.Tests.Models.Accounts;

public class TransactionArrayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransactionArray
        {
            Data =
            [
                new()
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
                                Type = TransactionTypeProperty.Withdrawal,
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
                                DestinationType = AccountTypeProperty.AssetAccount,
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
                                SourceType = AccountTypeProperty.AssetAccount,
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

        List<TransactionRead> expectedData =
        [
            new()
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
                            Type = TransactionTypeProperty.Withdrawal,
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
                            DestinationType = AccountTypeProperty.AssetAccount,
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
                            SourceType = AccountTypeProperty.AssetAccount,
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
        var model = new TransactionArray
        {
            Data =
            [
                new()
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
                                Type = TransactionTypeProperty.Withdrawal,
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
                                DestinationType = AccountTypeProperty.AssetAccount,
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
                                SourceType = AccountTypeProperty.AssetAccount,
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
        var deserialized = JsonSerializer.Deserialize<TransactionArray>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransactionArray
        {
            Data =
            [
                new()
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
                                Type = TransactionTypeProperty.Withdrawal,
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
                                DestinationType = AccountTypeProperty.AssetAccount,
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
                                SourceType = AccountTypeProperty.AssetAccount,
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
        var deserialized = JsonSerializer.Deserialize<TransactionArray>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TransactionRead> expectedData =
        [
            new()
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
                            Type = TransactionTypeProperty.Withdrawal,
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
                            DestinationType = AccountTypeProperty.AssetAccount,
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
                            SourceType = AccountTypeProperty.AssetAccount,
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
        var model = new TransactionArray
        {
            Data =
            [
                new()
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
                                Type = TransactionTypeProperty.Withdrawal,
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
                                DestinationType = AccountTypeProperty.AssetAccount,
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
                                SourceType = AccountTypeProperty.AssetAccount,
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
        var model = new TransactionArray
        {
            Data =
            [
                new()
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
                                Type = TransactionTypeProperty.Withdrawal,
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
                                DestinationType = AccountTypeProperty.AssetAccount,
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
                                SourceType = AccountTypeProperty.AssetAccount,
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

        TransactionArray copied = new(model);

        Assert.Equal(model, copied);
    }
}
