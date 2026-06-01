using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class CronServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Cron.Run(
            "d5ea6b5fb774618dd6ad6ba6e0a7f55c",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
