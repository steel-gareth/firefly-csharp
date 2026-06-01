using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class AvailableBudgetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var availableBudget = await this.client.AvailableBudgets.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        availableBudget.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var availableBudgetArray = await this.client.AvailableBudgets.List(
            new(),
            TestContext.Current.CancellationToken
        );
        availableBudgetArray.Validate();
    }
}
