using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class TransactionJournalServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var transactionSingle = await this.client.TransactionJournals.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.TransactionJournals.Delete(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListLinks_Works()
    {
        var transactionLinkArray = await this.client.TransactionJournals.ListLinks(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionLinkArray.Validate();
    }
}
