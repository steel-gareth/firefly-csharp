using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class AutocompleteServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAccounts_Works()
    {
        var response = await this.client.Autocomplete.ListAccounts(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListBills_Works()
    {
        var autocompleteBills = await this.client.Autocomplete.ListBills(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in autocompleteBills)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListBudgets_Works()
    {
        var response = await this.client.Autocomplete.ListBudgets(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListCategories_Works()
    {
        var response = await this.client.Autocomplete.ListCategories(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListCurrencies_Works()
    {
        var response = await this.client.Autocomplete.ListCurrencies(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListCurrenciesWithCode_Works()
    {
        var response = await this.client.Autocomplete.ListCurrenciesWithCode(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListObjectGroups_Works()
    {
        var response = await this.client.Autocomplete.ListObjectGroups(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListPiggyBanks_Works()
    {
        var response = await this.client.Autocomplete.ListPiggyBanks(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListPiggyBanksWithBalance_Works()
    {
        var response = await this.client.Autocomplete.ListPiggyBanksWithBalance(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListRecurringTransactions_Works()
    {
        var response = await this.client.Autocomplete.ListRecurringTransactions(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListRuleGroups_Works()
    {
        var response = await this.client.Autocomplete.ListRuleGroups(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListRules_Works()
    {
        var response = await this.client.Autocomplete.ListRules(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListSubscriptions_Works()
    {
        var autocompleteBills = await this.client.Autocomplete.ListSubscriptions(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in autocompleteBills)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTags_Works()
    {
        var response = await this.client.Autocomplete.ListTags(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactionTypes_Works()
    {
        var response = await this.client.Autocomplete.ListTransactionTypes(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var response = await this.client.Autocomplete.ListTransactions(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactionsWithID_Works()
    {
        var response = await this.client.Autocomplete.ListTransactionsWithID(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }
}
