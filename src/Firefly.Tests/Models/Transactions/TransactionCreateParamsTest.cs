using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Transactions;

namespace Firefly.Tests.Models.Transactions;

public class TransactionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransactionCreateParams
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    Type = TransactionTypeProperty.Withdrawal,
                    BillID = "112",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyID = "12",
                    DestinationID = "2",
                    DestinationName = "Buy and Large",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyID = "17",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Notes = "Some example notes",
                    Order = 0,
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PiggyBankID = 0,
                    PiggyBankName = "piggy_bank_name",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceID = "2",
                    SourceName = "Checking account",
                    Tags = ["Barbecue preparation"],
                },
            ],
            ApplyRules = false,
            ErrorIfDuplicateHash = false,
            FireWebhooks = true,
            GroupTitle = "Split transaction title.",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        List<Transaction> expectedTransactions =
        [
            new()
            {
                Amount = "123.45",
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Description = "Vegetables",
                Type = TransactionTypeProperty.Withdrawal,
                BillID = "112",
                BillName = "Monthly rent",
                BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BudgetID = "4",
                BudgetName = "Groceries",
                CategoryID = "43",
                CategoryName = "Groceries",
                CurrencyCode = "EUR",
                CurrencyID = "12",
                DestinationID = "2",
                DestinationName = "Buy and Large",
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalID = "external_id",
                ExternalUrl = "external_url",
                ForeignAmount = "123.45",
                ForeignCurrencyCode = "USD",
                ForeignCurrencyID = "17",
                InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InternalReference = "internal_reference",
                InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Notes = "Some example notes",
                Order = 0,
                PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PiggyBankID = 0,
                PiggyBankName = "piggy_bank_name",
                ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Reconciled = false,
                SepaBatchID = "sepa_batch_id",
                SepaCc = "sepa_cc",
                SepaCi = "sepa_ci",
                SepaCountry = "sepa_country",
                SepaCtID = "sepa_ct_id",
                SepaCtOp = "sepa_ct_op",
                SepaDB = "sepa_db",
                SepaEp = "sepa_ep",
                SourceID = "2",
                SourceName = "Checking account",
                Tags = ["Barbecue preparation"],
            },
        ];
        bool expectedApplyRules = false;
        bool expectedErrorIfDuplicateHash = false;
        bool expectedFireWebhooks = true;
        string expectedGroupTitle = "Split transaction title.";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedTransactions.Count, parameters.Transactions.Count);
        for (int i = 0; i < expectedTransactions.Count; i++)
        {
            Assert.Equal(expectedTransactions[i], parameters.Transactions[i]);
        }
        Assert.Equal(expectedApplyRules, parameters.ApplyRules);
        Assert.Equal(expectedErrorIfDuplicateHash, parameters.ErrorIfDuplicateHash);
        Assert.Equal(expectedFireWebhooks, parameters.FireWebhooks);
        Assert.Equal(expectedGroupTitle, parameters.GroupTitle);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransactionCreateParams
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    Type = TransactionTypeProperty.Withdrawal,
                    BillID = "112",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyID = "12",
                    DestinationID = "2",
                    DestinationName = "Buy and Large",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyID = "17",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Notes = "Some example notes",
                    Order = 0,
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PiggyBankID = 0,
                    PiggyBankName = "piggy_bank_name",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceID = "2",
                    SourceName = "Checking account",
                    Tags = ["Barbecue preparation"],
                },
            ],
            GroupTitle = "Split transaction title.",
        };

        Assert.Null(parameters.ApplyRules);
        Assert.False(parameters.RawBodyData.ContainsKey("apply_rules"));
        Assert.Null(parameters.ErrorIfDuplicateHash);
        Assert.False(parameters.RawBodyData.ContainsKey("error_if_duplicate_hash"));
        Assert.Null(parameters.FireWebhooks);
        Assert.False(parameters.RawBodyData.ContainsKey("fire_webhooks"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TransactionCreateParams
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    Type = TransactionTypeProperty.Withdrawal,
                    BillID = "112",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyID = "12",
                    DestinationID = "2",
                    DestinationName = "Buy and Large",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyID = "17",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Notes = "Some example notes",
                    Order = 0,
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PiggyBankID = 0,
                    PiggyBankName = "piggy_bank_name",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceID = "2",
                    SourceName = "Checking account",
                    Tags = ["Barbecue preparation"],
                },
            ],
            GroupTitle = "Split transaction title.",

            // Null should be interpreted as omitted for these properties
            ApplyRules = null,
            ErrorIfDuplicateHash = null,
            FireWebhooks = null,
            XTraceID = null,
        };

        Assert.Null(parameters.ApplyRules);
        Assert.False(parameters.RawBodyData.ContainsKey("apply_rules"));
        Assert.Null(parameters.ErrorIfDuplicateHash);
        Assert.False(parameters.RawBodyData.ContainsKey("error_if_duplicate_hash"));
        Assert.Null(parameters.FireWebhooks);
        Assert.False(parameters.RawBodyData.ContainsKey("fire_webhooks"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TransactionCreateParams
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    Type = TransactionTypeProperty.Withdrawal,
                    BillID = "112",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyID = "12",
                    DestinationID = "2",
                    DestinationName = "Buy and Large",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyID = "17",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Notes = "Some example notes",
                    Order = 0,
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PiggyBankID = 0,
                    PiggyBankName = "piggy_bank_name",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceID = "2",
                    SourceName = "Checking account",
                    Tags = ["Barbecue preparation"],
                },
            ],
            ApplyRules = false,
            ErrorIfDuplicateHash = false,
            FireWebhooks = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.GroupTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("group_title"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TransactionCreateParams
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    Type = TransactionTypeProperty.Withdrawal,
                    BillID = "112",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyID = "12",
                    DestinationID = "2",
                    DestinationName = "Buy and Large",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyID = "17",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Notes = "Some example notes",
                    Order = 0,
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PiggyBankID = 0,
                    PiggyBankName = "piggy_bank_name",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceID = "2",
                    SourceName = "Checking account",
                    Tags = ["Barbecue preparation"],
                },
            ],
            ApplyRules = false,
            ErrorIfDuplicateHash = false,
            FireWebhooks = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            GroupTitle = null,
        };

        Assert.Null(parameters.GroupTitle);
        Assert.True(parameters.RawBodyData.ContainsKey("group_title"));
    }

    [Fact]
    public void Url_Works()
    {
        TransactionCreateParams parameters = new()
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    Type = TransactionTypeProperty.Withdrawal,
                    BillID = "112",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyID = "12",
                    DestinationID = "2",
                    DestinationName = "Buy and Large",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyID = "17",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Notes = "Some example notes",
                    Order = 0,
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PiggyBankID = 0,
                    PiggyBankName = "piggy_bank_name",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceID = "2",
                    SourceName = "Checking account",
                    Tags = ["Barbecue preparation"],
                },
            ],
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/transactions"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TransactionCreateParams parameters = new()
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    Type = TransactionTypeProperty.Withdrawal,
                    BillID = "112",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyID = "12",
                    DestinationID = "2",
                    DestinationName = "Buy and Large",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyID = "17",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Notes = "Some example notes",
                    Order = 0,
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PiggyBankID = 0,
                    PiggyBankName = "piggy_bank_name",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceID = "2",
                    SourceName = "Checking account",
                    Tags = ["Barbecue preparation"],
                },
            ],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { });

        Assert.Equal(
            ["40c71bbb-c676-4f24-83cf-cc725d7d7a00"],
            requestMessage.Headers.GetValues("X-Trace-Id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TransactionCreateParams
        {
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Description = "Vegetables",
                    Type = TransactionTypeProperty.Withdrawal,
                    BillID = "112",
                    BillName = "Monthly rent",
                    BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BudgetID = "4",
                    BudgetName = "Groceries",
                    CategoryID = "43",
                    CategoryName = "Groceries",
                    CurrencyCode = "EUR",
                    CurrencyID = "12",
                    DestinationID = "2",
                    DestinationName = "Buy and Large",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalID = "external_id",
                    ExternalUrl = "external_url",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "USD",
                    ForeignCurrencyID = "17",
                    InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InternalReference = "internal_reference",
                    InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Notes = "Some example notes",
                    Order = 0,
                    PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PiggyBankID = 0,
                    PiggyBankName = "piggy_bank_name",
                    ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Reconciled = false,
                    SepaBatchID = "sepa_batch_id",
                    SepaCc = "sepa_cc",
                    SepaCi = "sepa_ci",
                    SepaCountry = "sepa_country",
                    SepaCtID = "sepa_ct_id",
                    SepaCtOp = "sepa_ct_op",
                    SepaDB = "sepa_db",
                    SepaEp = "sepa_ep",
                    SourceID = "2",
                    SourceName = "Checking account",
                    Tags = ["Barbecue preparation"],
                },
            ],
            ApplyRules = false,
            ErrorIfDuplicateHash = false,
            FireWebhooks = true,
            GroupTitle = "Split transaction title.",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        TransactionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],
        };

        string expectedAmount = "123.45";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDescription = "Vegetables";
        ApiEnum<string, TransactionTypeProperty> expectedType = TransactionTypeProperty.Withdrawal;
        string expectedBillID = "112";
        string expectedBillName = "Monthly rent";
        DateTimeOffset expectedBookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBudgetID = "4";
        string expectedBudgetName = "Groceries";
        string expectedCategoryID = "43";
        string expectedCategoryName = "Groceries";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "12";
        string expectedDestinationID = "2";
        string expectedDestinationName = "Buy and Large";
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalID = "external_id";
        string expectedExternalUrl = "external_url";
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyCode = "USD";
        string expectedForeignCurrencyID = "17";
        DateTimeOffset expectedInterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInternalReference = "internal_reference";
        DateTimeOffset expectedInvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedNotes = "Some example notes";
        int expectedOrder = 0;
        DateTimeOffset expectedPaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedPiggyBankID = 0;
        string expectedPiggyBankName = "piggy_bank_name";
        DateTimeOffset expectedProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedReconciled = false;
        string expectedSepaBatchID = "sepa_batch_id";
        string expectedSepaCc = "sepa_cc";
        string expectedSepaCi = "sepa_ci";
        string expectedSepaCountry = "sepa_country";
        string expectedSepaCtID = "sepa_ct_id";
        string expectedSepaCtOp = "sepa_ct_op";
        string expectedSepaDB = "sepa_db";
        string expectedSepaEp = "sepa_ep";
        string expectedSourceID = "2";
        string expectedSourceName = "Checking account";
        List<string> expectedTags = ["Barbecue preparation"];

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedBillID, model.BillID);
        Assert.Equal(expectedBillName, model.BillName);
        Assert.Equal(expectedBookDate, model.BookDate);
        Assert.Equal(expectedBudgetID, model.BudgetID);
        Assert.Equal(expectedBudgetName, model.BudgetName);
        Assert.Equal(expectedCategoryID, model.CategoryID);
        Assert.Equal(expectedCategoryName, model.CategoryName);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDestinationID, model.DestinationID);
        Assert.Equal(expectedDestinationName, model.DestinationName);
        Assert.Equal(expectedDueDate, model.DueDate);
        Assert.Equal(expectedExternalID, model.ExternalID);
        Assert.Equal(expectedExternalUrl, model.ExternalUrl);
        Assert.Equal(expectedForeignAmount, model.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyCode, model.ForeignCurrencyCode);
        Assert.Equal(expectedForeignCurrencyID, model.ForeignCurrencyID);
        Assert.Equal(expectedInterestDate, model.InterestDate);
        Assert.Equal(expectedInternalReference, model.InternalReference);
        Assert.Equal(expectedInvoiceDate, model.InvoiceDate);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedPaymentDate, model.PaymentDate);
        Assert.Equal(expectedPiggyBankID, model.PiggyBankID);
        Assert.Equal(expectedPiggyBankName, model.PiggyBankName);
        Assert.Equal(expectedProcessDate, model.ProcessDate);
        Assert.Equal(expectedReconciled, model.Reconciled);
        Assert.Equal(expectedSepaBatchID, model.SepaBatchID);
        Assert.Equal(expectedSepaCc, model.SepaCc);
        Assert.Equal(expectedSepaCi, model.SepaCi);
        Assert.Equal(expectedSepaCountry, model.SepaCountry);
        Assert.Equal(expectedSepaCtID, model.SepaCtID);
        Assert.Equal(expectedSepaCtOp, model.SepaCtOp);
        Assert.Equal(expectedSepaDB, model.SepaDB);
        Assert.Equal(expectedSepaEp, model.SepaEp);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedSourceName, model.SourceName);
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
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],
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
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],
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
        ApiEnum<string, TransactionTypeProperty> expectedType = TransactionTypeProperty.Withdrawal;
        string expectedBillID = "112";
        string expectedBillName = "Monthly rent";
        DateTimeOffset expectedBookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBudgetID = "4";
        string expectedBudgetName = "Groceries";
        string expectedCategoryID = "43";
        string expectedCategoryName = "Groceries";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "12";
        string expectedDestinationID = "2";
        string expectedDestinationName = "Buy and Large";
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalID = "external_id";
        string expectedExternalUrl = "external_url";
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyCode = "USD";
        string expectedForeignCurrencyID = "17";
        DateTimeOffset expectedInterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInternalReference = "internal_reference";
        DateTimeOffset expectedInvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedNotes = "Some example notes";
        int expectedOrder = 0;
        DateTimeOffset expectedPaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedPiggyBankID = 0;
        string expectedPiggyBankName = "piggy_bank_name";
        DateTimeOffset expectedProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedReconciled = false;
        string expectedSepaBatchID = "sepa_batch_id";
        string expectedSepaCc = "sepa_cc";
        string expectedSepaCi = "sepa_ci";
        string expectedSepaCountry = "sepa_country";
        string expectedSepaCtID = "sepa_ct_id";
        string expectedSepaCtOp = "sepa_ct_op";
        string expectedSepaDB = "sepa_db";
        string expectedSepaEp = "sepa_ep";
        string expectedSourceID = "2";
        string expectedSourceName = "Checking account";
        List<string> expectedTags = ["Barbecue preparation"];

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedBillID, deserialized.BillID);
        Assert.Equal(expectedBillName, deserialized.BillName);
        Assert.Equal(expectedBookDate, deserialized.BookDate);
        Assert.Equal(expectedBudgetID, deserialized.BudgetID);
        Assert.Equal(expectedBudgetName, deserialized.BudgetName);
        Assert.Equal(expectedCategoryID, deserialized.CategoryID);
        Assert.Equal(expectedCategoryName, deserialized.CategoryName);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDestinationID, deserialized.DestinationID);
        Assert.Equal(expectedDestinationName, deserialized.DestinationName);
        Assert.Equal(expectedDueDate, deserialized.DueDate);
        Assert.Equal(expectedExternalID, deserialized.ExternalID);
        Assert.Equal(expectedExternalUrl, deserialized.ExternalUrl);
        Assert.Equal(expectedForeignAmount, deserialized.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyCode, deserialized.ForeignCurrencyCode);
        Assert.Equal(expectedForeignCurrencyID, deserialized.ForeignCurrencyID);
        Assert.Equal(expectedInterestDate, deserialized.InterestDate);
        Assert.Equal(expectedInternalReference, deserialized.InternalReference);
        Assert.Equal(expectedInvoiceDate, deserialized.InvoiceDate);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedPaymentDate, deserialized.PaymentDate);
        Assert.Equal(expectedPiggyBankID, deserialized.PiggyBankID);
        Assert.Equal(expectedPiggyBankName, deserialized.PiggyBankName);
        Assert.Equal(expectedProcessDate, deserialized.ProcessDate);
        Assert.Equal(expectedReconciled, deserialized.Reconciled);
        Assert.Equal(expectedSepaBatchID, deserialized.SepaBatchID);
        Assert.Equal(expectedSepaCc, deserialized.SepaCc);
        Assert.Equal(expectedSepaCi, deserialized.SepaCi);
        Assert.Equal(expectedSepaCountry, deserialized.SepaCountry);
        Assert.Equal(expectedSepaCtID, deserialized.SepaCtID);
        Assert.Equal(expectedSepaCtOp, deserialized.SepaCtOp);
        Assert.Equal(expectedSepaDB, deserialized.SepaDB);
        Assert.Equal(expectedSepaEp, deserialized.SepaEp);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedSourceName, deserialized.SourceName);
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
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],
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
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],
        };

        Assert.Null(model.Reconciled);
        Assert.False(model.RawData.ContainsKey("reconciled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],
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
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],

            // Null should be interpreted as omitted for these properties
            Reconciled = null,
        };

        Assert.Null(model.Reconciled);
        Assert.False(model.RawData.ContainsKey("reconciled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],

            // Null should be interpreted as omitted for these properties
            Reconciled = null,
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
            Type = TransactionTypeProperty.Withdrawal,
            Reconciled = false,
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
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.DestinationID);
        Assert.False(model.RawData.ContainsKey("destination_id"));
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
        Assert.Null(model.ForeignCurrencyID);
        Assert.False(model.RawData.ContainsKey("foreign_currency_id"));
        Assert.Null(model.InterestDate);
        Assert.False(model.RawData.ContainsKey("interest_date"));
        Assert.Null(model.InternalReference);
        Assert.False(model.RawData.ContainsKey("internal_reference"));
        Assert.Null(model.InvoiceDate);
        Assert.False(model.RawData.ContainsKey("invoice_date"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.PaymentDate);
        Assert.False(model.RawData.ContainsKey("payment_date"));
        Assert.Null(model.PiggyBankID);
        Assert.False(model.RawData.ContainsKey("piggy_bank_id"));
        Assert.Null(model.PiggyBankName);
        Assert.False(model.RawData.ContainsKey("piggy_bank_name"));
        Assert.Null(model.ProcessDate);
        Assert.False(model.RawData.ContainsKey("process_date"));
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
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
        Assert.Null(model.SourceName);
        Assert.False(model.RawData.ContainsKey("source_name"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            Type = TransactionTypeProperty.Withdrawal,
            Reconciled = false,
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
            Type = TransactionTypeProperty.Withdrawal,
            Reconciled = false,

            BillID = null,
            BillName = null,
            BookDate = null,
            BudgetID = null,
            BudgetName = null,
            CategoryID = null,
            CategoryName = null,
            CurrencyCode = null,
            CurrencyID = null,
            DestinationID = null,
            DestinationName = null,
            DueDate = null,
            ExternalID = null,
            ExternalUrl = null,
            ForeignAmount = null,
            ForeignCurrencyCode = null,
            ForeignCurrencyID = null,
            InterestDate = null,
            InternalReference = null,
            InvoiceDate = null,
            Notes = null,
            Order = null,
            PaymentDate = null,
            PiggyBankID = null,
            PiggyBankName = null,
            ProcessDate = null,
            SepaBatchID = null,
            SepaCc = null,
            SepaCi = null,
            SepaCountry = null,
            SepaCtID = null,
            SepaCtOp = null,
            SepaDB = null,
            SepaEp = null,
            SourceID = null,
            SourceName = null,
            Tags = null,
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
        Assert.Null(model.CurrencyCode);
        Assert.True(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.True(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.DestinationID);
        Assert.True(model.RawData.ContainsKey("destination_id"));
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
        Assert.Null(model.ForeignCurrencyID);
        Assert.True(model.RawData.ContainsKey("foreign_currency_id"));
        Assert.Null(model.InterestDate);
        Assert.True(model.RawData.ContainsKey("interest_date"));
        Assert.Null(model.InternalReference);
        Assert.True(model.RawData.ContainsKey("internal_reference"));
        Assert.Null(model.InvoiceDate);
        Assert.True(model.RawData.ContainsKey("invoice_date"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Order);
        Assert.True(model.RawData.ContainsKey("order"));
        Assert.Null(model.PaymentDate);
        Assert.True(model.RawData.ContainsKey("payment_date"));
        Assert.Null(model.PiggyBankID);
        Assert.True(model.RawData.ContainsKey("piggy_bank_id"));
        Assert.Null(model.PiggyBankName);
        Assert.True(model.RawData.ContainsKey("piggy_bank_name"));
        Assert.Null(model.ProcessDate);
        Assert.True(model.RawData.ContainsKey("process_date"));
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
        Assert.Null(model.SourceID);
        Assert.True(model.RawData.ContainsKey("source_id"));
        Assert.Null(model.SourceName);
        Assert.True(model.RawData.ContainsKey("source_name"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Description = "Vegetables",
            Type = TransactionTypeProperty.Withdrawal,
            Reconciled = false,

            BillID = null,
            BillName = null,
            BookDate = null,
            BudgetID = null,
            BudgetName = null,
            CategoryID = null,
            CategoryName = null,
            CurrencyCode = null,
            CurrencyID = null,
            DestinationID = null,
            DestinationName = null,
            DueDate = null,
            ExternalID = null,
            ExternalUrl = null,
            ForeignAmount = null,
            ForeignCurrencyCode = null,
            ForeignCurrencyID = null,
            InterestDate = null,
            InternalReference = null,
            InvoiceDate = null,
            Notes = null,
            Order = null,
            PaymentDate = null,
            PiggyBankID = null,
            PiggyBankName = null,
            ProcessDate = null,
            SepaBatchID = null,
            SepaCc = null,
            SepaCi = null,
            SepaCountry = null,
            SepaCtID = null,
            SepaCtOp = null,
            SepaDB = null,
            SepaEp = null,
            SourceID = null,
            SourceName = null,
            Tags = null,
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
            Type = TransactionTypeProperty.Withdrawal,
            BillID = "112",
            BillName = "Monthly rent",
            BookDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BudgetID = "4",
            BudgetName = "Groceries",
            CategoryID = "43",
            CategoryName = "Groceries",
            CurrencyCode = "EUR",
            CurrencyID = "12",
            DestinationID = "2",
            DestinationName = "Buy and Large",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalID = "external_id",
            ExternalUrl = "external_url",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "USD",
            ForeignCurrencyID = "17",
            InterestDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InternalReference = "internal_reference",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Notes = "Some example notes",
            Order = 0,
            PaymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PiggyBankID = 0,
            PiggyBankName = "piggy_bank_name",
            ProcessDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reconciled = false,
            SepaBatchID = "sepa_batch_id",
            SepaCc = "sepa_cc",
            SepaCi = "sepa_ci",
            SepaCountry = "sepa_country",
            SepaCtID = "sepa_ct_id",
            SepaCtOp = "sepa_ct_op",
            SepaDB = "sepa_db",
            SepaEp = "sepa_ep",
            SourceID = "2",
            SourceName = "Checking account",
            Tags = ["Barbecue preparation"],
        };

        Transaction copied = new(model);

        Assert.Equal(model, copied);
    }
}
