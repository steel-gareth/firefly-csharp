using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Currencies;

public class PrimaryServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var currencySingle = await this.client.Currencies.Primary.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        currencySingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task MakePrimary_Works()
    {
        var currencySingle = await this.client.Currencies.Primary.MakePrimary(
            "USD",
            new(),
            TestContext.Current.CancellationToken
        );
        currencySingle.Validate();
    }
}
