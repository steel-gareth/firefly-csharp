using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class RuleGroupServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var ruleGroupSingle = await this.client.RuleGroups.Create(
            new() { Title = "Default rule group" },
            TestContext.Current.CancellationToken
        );
        ruleGroupSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var ruleGroupSingle = await this.client.RuleGroups.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        ruleGroupSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var ruleGroupSingle = await this.client.RuleGroups.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        ruleGroupSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.RuleGroups.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAll_Works()
    {
        var response = await this.client.RuleGroups.ListAll(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListRules_Works()
    {
        var ruleArray = await this.client.RuleGroups.ListRules(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        ruleArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TestTransactions_Works()
    {
        var transactionArray = await this.client.RuleGroups.TestTransactions(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TriggerRules_Works()
    {
        await this.client.RuleGroups.TriggerRules(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
