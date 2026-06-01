using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Chart;

public class CategoryServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveOverview_Works()
    {
        var chartDataSets = await this.client.Chart.Category.RetrieveOverview(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in chartDataSets)
        {
            item.Validate();
        }
    }
}
