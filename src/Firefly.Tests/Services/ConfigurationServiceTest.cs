using System.Threading.Tasks;
using Firefly.Models.Configuration;

namespace Firefly.Tests.Services;

public class ConfigurationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var configurations = await this.client.Configuration.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in configurations)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveValue_Works()
    {
        var configurationSingle = await this.client.Configuration.RetrieveValue(
            ConfigValueFilter.ConfigurationIsDemoSite,
            new(),
            TestContext.Current.CancellationToken
        );
        configurationSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateValue_Works()
    {
        var configurationSingle = await this.client.Configuration.UpdateValue(
            Name.ConfigurationIsDemoSite,
            new() { Value = true },
            TestContext.Current.CancellationToken
        );
        configurationSingle.Validate();
    }
}
