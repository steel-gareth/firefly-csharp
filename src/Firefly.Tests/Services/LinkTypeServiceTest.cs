using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class LinkTypeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var linkTypeSingle = await this.client.LinkTypes.Create(
            new()
            {
                Inward = "is (partially) paid for by",
                Name = "Paid",
                Outward = "(partially) pays for",
            },
            TestContext.Current.CancellationToken
        );
        linkTypeSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var linkTypeSingle = await this.client.LinkTypes.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        linkTypeSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var linkTypeSingle = await this.client.LinkTypes.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        linkTypeSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var linkTypes = await this.client.LinkTypes.List(
            new(),
            TestContext.Current.CancellationToken
        );
        linkTypes.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.LinkTypes.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.LinkTypes.ListTransactions(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
