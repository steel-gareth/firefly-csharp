using System.Threading.Tasks;
using EmceesProdTesting5.Models.Search;

namespace EmceesProdTesting5.Tests.Services;

public class SearchServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Accounts_Works()
    {
        var accountArray = await this.client.Search.Accounts(
            new() { Field = Field.All, Query = "checking" },
            TestContext.Current.CancellationToken
        );
        accountArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Transactions_Works()
    {
        var transactionArray = await this.client.Search.Transactions(
            new() { Query = "groceries" },
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
