using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class BatchServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Finish_Works()
    {
        await this.client.Batch.Finish(new(), TestContext.Current.CancellationToken);
    }
}
