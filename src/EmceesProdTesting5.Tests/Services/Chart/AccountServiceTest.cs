using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Chart;

public class AccountServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveOverview_Works()
    {
        var chartDataSets = await this.client.Chart.Account.RetrieveOverview(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in chartDataSets)
        {
            item.Validate();
        }
    }
}
