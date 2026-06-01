using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Insight;

public class ExpenseServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetTotal_Works()
    {
        var insightTotalEntries = await this.client.Insight.Expense.GetTotal(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightTotalEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByAssetAccount_Works()
    {
        var insightGroupEntries = await this.client.Insight.Expense.ListByAssetAccount(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightGroupEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByBill_Works()
    {
        var insightGroupEntries = await this.client.Insight.Expense.ListByBill(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightGroupEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByBudget_Works()
    {
        var insightGroupEntries = await this.client.Insight.Expense.ListByBudget(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightGroupEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByCategory_Works()
    {
        var insightGroupEntries = await this.client.Insight.Expense.ListByCategory(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightGroupEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByExpenseAccount_Works()
    {
        var insightGroupEntries = await this.client.Insight.Expense.ListByExpenseAccount(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightGroupEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByTag_Works()
    {
        var insightGroupEntries = await this.client.Insight.Expense.ListByTag(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightGroupEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListWithoutBill_Works()
    {
        var insightTotalEntries = await this.client.Insight.Expense.ListWithoutBill(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightTotalEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListWithoutBudget_Works()
    {
        var insightTotalEntries = await this.client.Insight.Expense.ListWithoutBudget(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightTotalEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListWithoutCategory_Works()
    {
        var insightTotalEntries = await this.client.Insight.Expense.ListWithoutCategory(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightTotalEntries)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListWithoutTag_Works()
    {
        var insightTotalEntries = await this.client.Insight.Expense.ListWithoutTag(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in insightTotalEntries)
        {
            item.Validate();
        }
    }
}
