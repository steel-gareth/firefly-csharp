using System.Threading.Tasks;

namespace Firefly.Tests.Services.Data;

public class BulkServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateTransactions_Works()
    {
        await this.client.Data.Bulk.UpdateTransactions(
            new() { Query = "query" },
            TestContext.Current.CancellationToken
        );
    }
}
