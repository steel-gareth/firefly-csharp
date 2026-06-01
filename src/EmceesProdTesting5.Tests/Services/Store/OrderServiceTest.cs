using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Store;

public class OrderServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var order = await this.client.Store.Orders.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        order.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var order = await this.client.Store.Orders.Retrieve(
            0,
            new(),
            TestContext.Current.CancellationToken
        );
        order.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Store.Orders.Delete(0, new(), TestContext.Current.CancellationToken);
    }
}
