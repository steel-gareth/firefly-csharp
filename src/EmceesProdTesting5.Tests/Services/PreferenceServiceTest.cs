using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class PreferenceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var preferenceSingle = await this.client.Preferences.Create(
            new() { Data = true, Name = "currencyPreference" },
            TestContext.Current.CancellationToken
        );
        preferenceSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var preferenceSingle = await this.client.Preferences.Retrieve(
            "currencyPreference",
            new(),
            TestContext.Current.CancellationToken
        );
        preferenceSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var preferenceSingle = await this.client.Preferences.Update(
            "currencyPreference",
            new() { Data = true },
            TestContext.Current.CancellationToken
        );
        preferenceSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var preferences = await this.client.Preferences.List(
            new(),
            TestContext.Current.CancellationToken
        );
        preferences.Validate();
    }
}
