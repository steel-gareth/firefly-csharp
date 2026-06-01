using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Chart;

public class BalanceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveBalance_Works()
    {
        var chartDataSets = await this.client.Chart.Balance.RetrieveBalance(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in chartDataSets)
        {
            item.Validate();
        }
    }
}
