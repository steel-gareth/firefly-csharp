using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class StoreServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListInventory_Works()
    {
        await this.client.Store.ListInventory(new(), TestContext.Current.CancellationToken);
    }
}
