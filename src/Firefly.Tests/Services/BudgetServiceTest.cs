using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class BudgetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var budgetSingle = await this.client.Budgets.Create(
            new() { Name = "Bills" },
            TestContext.Current.CancellationToken
        );
        budgetSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var budgetSingle = await this.client.Budgets.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        budgetSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var budgetSingle = await this.client.Budgets.Update(
            "123",
            new() { Name = "Bills" },
            TestContext.Current.CancellationToken
        );
        budgetSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var budgets = await this.client.Budgets.List(new(), TestContext.Current.CancellationToken);
        budgets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Budgets.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAttachments_Works()
    {
        var attachmentArray = await this.client.Budgets.ListAttachments(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.Budgets.ListTransactions(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactionsWithoutBudget_Works()
    {
        var transactionArray = await this.client.Budgets.ListTransactionsWithoutBudget(
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
