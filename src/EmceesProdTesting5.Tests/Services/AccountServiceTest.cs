using System.Text.Json;
using System.Threading.Tasks;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Tests.Services;

public class AccountServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var accountSingle = await this.client.Accounts.Create(
            new() { Name = "My checking account", Type = ShortAccountTypeProperty.Asset },
            TestContext.Current.CancellationToken
        );
        accountSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var accountSingle = await this.client.Accounts.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        accountSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var accountSingle = await this.client.Accounts.Update(
            "123",
            new()
            {
                Name = "My checking account",
                Type = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            TestContext.Current.CancellationToken
        );
        accountSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var accountArray = await this.client.Accounts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        accountArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Accounts.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAttachments_Works()
    {
        var attachmentArray = await this.client.Accounts.ListAttachments(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListPiggyBanks_Works()
    {
        var piggyBankArray = await this.client.Accounts.ListPiggyBanks(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        piggyBankArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.Accounts.ListTransactions(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
