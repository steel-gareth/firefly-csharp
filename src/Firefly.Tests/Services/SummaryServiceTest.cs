using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class SummaryServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveBasic_Works()
    {
        var response = await this.client.Summary.RetrieveBasic(
            new() { End = "2019-12-27", Start = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in response.Values)
        {
            item.Validate();
        }
    }
}
