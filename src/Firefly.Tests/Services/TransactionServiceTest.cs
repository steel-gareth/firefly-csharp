using System;
using System.Threading.Tasks;
using Firefly.Models.Transactions;

namespace Firefly.Tests.Services;

public class TransactionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var transactionSingle = await this.client.Transactions.Create(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        transactionSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var transactionSingle = await this.client.Transactions.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var transactionSingle = await this.client.Transactions.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var transactionArray = await this.client.Transactions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Transactions.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAttachments_Works()
    {
        var attachmentArray = await this.client.Transactions.ListAttachments(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListPiggyBankEvents_Works()
    {
        var piggyBankEventArray = await this.client.Transactions.ListPiggyBankEvents(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        piggyBankEventArray.Validate();
    }
}
