using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class CategoryServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var categorySingle = await this.client.Categories.Create(
            new() { Name = "Lunch" },
            TestContext.Current.CancellationToken
        );
        categorySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var categorySingle = await this.client.Categories.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        categorySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var categorySingle = await this.client.Categories.Update(
            "123",
            new() { Name = "Lunch" },
            TestContext.Current.CancellationToken
        );
        categorySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var categories = await this.client.Categories.List(
            new(),
            TestContext.Current.CancellationToken
        );
        categories.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Categories.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAttachments_Works()
    {
        var attachmentArray = await this.client.Categories.ListAttachments(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.Categories.ListTransactions(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
