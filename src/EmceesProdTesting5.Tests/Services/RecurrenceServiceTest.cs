using System.Threading.Tasks;
using EmceesProdTesting5.Models.Recurrences;

namespace EmceesProdTesting5.Tests.Services;

public class RecurrenceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var recurrenceSingle = await this.client.Recurrences.Create(
            new()
            {
                FirstDate = "2026-04-30",
                RepeatUntil = "2026-04-30",
                Repetitions =
                [
                    new()
                    {
                        Moment = "3",
                        Type = RecurrenceRepetitionType.Weekly,
                        Skip = 0,
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
                        DestinationID = "258",
                        SourceID = "913",
                        BillID = "123",
                        BudgetID = "4",
                        CategoryID = "211",
                        CurrencyCode = "EUR",
                        CurrencyID = "3",
                        ForeignAmount = "123.45",
                        ForeignCurrencyCode = "GBP",
                        ForeignCurrencyID = "17",
                        PiggyBankID = "123",
                        Tags = ["Barbecue preparation"],
                    },
                ],
                Type = RecurrenceTransactionType.Withdrawal,
            },
            TestContext.Current.CancellationToken
        );
        recurrenceSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var recurrenceSingle = await this.client.Recurrences.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        recurrenceSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var recurrenceSingle = await this.client.Recurrences.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        recurrenceSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var recurrenceArray = await this.client.Recurrences.List(
            new(),
            TestContext.Current.CancellationToken
        );
        recurrenceArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Recurrences.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.Recurrences.ListTransactions(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TriggerTransaction_Works()
    {
        var transactionArray = await this.client.Recurrences.TriggerTransaction(
            "123",
            new() { Date = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
