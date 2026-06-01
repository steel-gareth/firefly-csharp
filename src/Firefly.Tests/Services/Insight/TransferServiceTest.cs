using System.Threading.Tasks;

namespace Firefly.Tests.Services.Insight;

public class TransferServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetTotal_Works()
    {
        var insightTotalEntries = await this.client.Insight.Transfer.GetTotal(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightTotalEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByAssetAccount_Works()
    {
        var response = await this.client.Insight.Transfer.ListByAssetAccount(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByCategory_Works()
    {
        var insightGroupEntries = await this.client.Insight.Transfer.ListByCategory(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightGroupEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByTag_Works()
    {
        var insightGroupEntries = await this.client.Insight.Transfer.ListByTag(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightGroupEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListWithoutCategory_Works()
    {
        var insightTotalEntries = await this.client.Insight.Transfer.ListWithoutCategory(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightTotalEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListWithoutTag_Works()
    {
        var insightTotalEntries = await this.client.Insight.Transfer.ListWithoutTag(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightTotalEntries)
        {
            item.Validate();
        }
    }
}
