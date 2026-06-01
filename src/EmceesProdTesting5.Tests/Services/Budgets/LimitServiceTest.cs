using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Budgets;

public class LimitServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var budgetLimitSingle = await this.client.Budgets.Limits.Create(
            "123",
            new()
            {
                Amount = "123.45",
                End = "2026-04-30",
                Start = "2026-04-01",
            },
            TestContext.Current.CancellationToken
        );
        budgetLimitSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var budgetLimitSingle = await this.client.Budgets.Limits.Retrieve(
            1,
            new() { ID = "123" },
            TestContext.Current.CancellationToken
        );
        budgetLimitSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var budgetLimitSingle = await this.client.Budgets.Limits.Update(
            "123",
            new() { ID = "123" },
            TestContext.Current.CancellationToken
        );
        budgetLimitSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Budgets.Limits.Delete(
            "123",
            new() { ID = "123" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List0_Works()
    {
        var budgetLimitArray = await this.client.Budgets.Limits.List0(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        budgetLimitArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List1_Works()
    {
        var budgetLimitArray = await this.client.Budgets.Limits.List1(
            new() { End = "2026-04-30", Start = "2026-04-01" },
            TestContext.Current.CancellationToken
        );
        budgetLimitArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.Budgets.Limits.ListTransactions(
            "123",
            new() { ID = "123" },
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
