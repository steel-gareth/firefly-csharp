using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class CurrencyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var currencySingle = await this.client.Currencies.Create(
            new()
            {
                Code = "AMS",
                Name = "Ankh-Morpork dollar",
                Symbol = "AM$",
            },
            TestContext.Current.CancellationToken
        );
        currencySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var currencySingle = await this.client.Currencies.Retrieve(
            "USD",
            new(),
            TestContext.Current.CancellationToken
        );
        currencySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var currencySingle = await this.client.Currencies.Update(
            "EUR",
            new(),
            TestContext.Current.CancellationToken
        );
        currencySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var currencies = await this.client.Currencies.List(
            new(),
            TestContext.Current.CancellationToken
        );
        currencies.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Currencies.Delete("GBP", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Disable_Works()
    {
        var currencySingle = await this.client.Currencies.Disable(
            "GBP",
            new(),
            TestContext.Current.CancellationToken
        );
        currencySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Enable_Works()
    {
        var currencySingle = await this.client.Currencies.Enable(
            "USD",
            new(),
            TestContext.Current.CancellationToken
        );
        currencySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAccounts_Works()
    {
        var accountArray = await this.client.Currencies.ListAccounts(
            "USD",
            new(),
            TestContext.Current.CancellationToken
        );
        accountArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAvailableBudgets_Works()
    {
        var availableBudgetArray = await this.client.Currencies.ListAvailableBudgets(
            "EUR",
            new(),
            TestContext.Current.CancellationToken
        );
        availableBudgetArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListBills_Works()
    {
        var billArray = await this.client.Currencies.ListBills(
            "USD",
            new(),
            TestContext.Current.CancellationToken
        );
        billArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListBudgetLimits_Works()
    {
        var budgetLimitArray = await this.client.Currencies.ListBudgetLimits(
            "USD",
            new(),
            TestContext.Current.CancellationToken
        );
        budgetLimitArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListRecurrences_Works()
    {
        var recurrenceArray = await this.client.Currencies.ListRecurrences(
            "EUR",
            new(),
            TestContext.Current.CancellationToken
        );
        recurrenceArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListRules_Works()
    {
        var ruleArray = await this.client.Currencies.ListRules(
            "USD",
            new(),
            TestContext.Current.CancellationToken
        );
        ruleArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.Currencies.ListTransactions(
            "USD",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
