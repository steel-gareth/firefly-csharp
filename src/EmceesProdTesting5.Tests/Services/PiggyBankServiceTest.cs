using System.Text.Json;
using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class PiggyBankServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var piggyBankSingle = await this.client.PiggyBanks.Create(
            new()
            {
                AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "New digital camera",
                StartDate = "2026-04-01",
                TargetAmount = "123.45",
            },
            TestContext.Current.CancellationToken
        );
        piggyBankSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var piggyBankSingle = await this.client.PiggyBanks.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        piggyBankSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var piggyBankSingle = await this.client.PiggyBanks.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        piggyBankSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var piggyBankArray = await this.client.PiggyBanks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        piggyBankArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.PiggyBanks.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAttachments_Works()
    {
        var attachmentArray = await this.client.PiggyBanks.ListAttachments(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListEvents_Works()
    {
        var piggyBankEventArray = await this.client.PiggyBanks.ListEvents(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        piggyBankEventArray.Validate();
    }
}
