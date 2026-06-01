using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Data;

public class ExportServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportAccounts_Works()
    {
        await this.client.Data.Export.ExportAccounts(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportBills_Works()
    {
        await this.client.Data.Export.ExportBills(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportBudgets_Works()
    {
        await this.client.Data.Export.ExportBudgets(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportCategories_Works()
    {
        await this.client.Data.Export.ExportCategories(
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportPiggyBanks_Works()
    {
        await this.client.Data.Export.ExportPiggyBanks(
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportRecurring_Works()
    {
        await this.client.Data.Export.ExportRecurring(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportRules_Works()
    {
        await this.client.Data.Export.ExportRules(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportTags_Works()
    {
        await this.client.Data.Export.ExportTags(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportTransactions_Works()
    {
        await this.client.Data.Export.ExportTransactions(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
    }
}
