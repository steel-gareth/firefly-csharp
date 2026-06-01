using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class TransactionLinkServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var transactionLinkSingle = await this.client.TransactionLinks.Create(
            new()
            {
                InwardID = "131",
                LinkTypeID = "5",
                OutwardID = "131",
            },
            TestContext.Current.CancellationToken
        );
        transactionLinkSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var transactionLinkSingle = await this.client.TransactionLinks.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionLinkSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var transactionLinkSingle = await this.client.TransactionLinks.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionLinkSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var transactionLinkArray = await this.client.TransactionLinks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        transactionLinkArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.TransactionLinks.Delete(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
