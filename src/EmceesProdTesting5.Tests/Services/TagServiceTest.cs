using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class TagServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var tagSingle = await this.client.Tags.Create(
            new() { Tag = "expensive" },
            TestContext.Current.CancellationToken
        );
        tagSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var tagSingle = await this.client.Tags.Retrieve(
            "groceries",
            new(),
            TestContext.Current.CancellationToken
        );
        tagSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var tagSingle = await this.client.Tags.Update(
            "groceries",
            new(),
            TestContext.Current.CancellationToken
        );
        tagSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var tags = await this.client.Tags.List(new(), TestContext.Current.CancellationToken);
        tags.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Tags.Delete("groceries", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAttachments_Works()
    {
        var attachmentArray = await this.client.Tags.ListAttachments(
            "groceries",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.Tags.ListTransactions(
            "groceries",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
