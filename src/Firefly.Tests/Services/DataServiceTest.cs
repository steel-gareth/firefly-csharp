using System.Threading.Tasks;
using Firefly.Models.Data;

namespace Firefly.Tests.Services;

public class DataServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Destroy_Works()
    {
        await this.client.Data.Destroy(
            new() { Objects = Objects.NotAssetsLiabilities },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Purge_Works()
    {
        await this.client.Data.Purge(new(), TestContext.Current.CancellationToken);
    }
}
