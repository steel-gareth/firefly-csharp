using System.Threading.Tasks;
using Firefly.Models.Rules;

namespace Firefly.Tests.Services;

public class RuleServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var ruleSingle = await this.client.Rules.Create(
            new()
            {
                Actions =
                [
                    new()
                    {
                        Type = RuleActionKeyword.SetCategory,
                        Value = "Daily groceries",
                        Active = true,
                        Order = 5,
                        StopProcessing = false,
                    },
                ],
                RuleGroupID = "81",
                Title = "First rule title.",
                Trigger = RuleTriggerType.StoreJournal,
                Triggers =
                [
                    new()
                    {
                        Type = RuleTriggerKeyword.FromAccountStarts,
                        Value = "tag1",
                        Active = true,
                        Order = 5,
                        Prohibited = false,
                        StopProcessing = false,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        ruleSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var ruleSingle = await this.client.Rules.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        ruleSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var ruleSingle = await this.client.Rules.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        ruleSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var ruleArray = await this.client.Rules.List(new(), TestContext.Current.CancellationToken);
        ruleArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Rules.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Test_Works()
    {
        var transactionArray = await this.client.Rules.Test(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Trigger_Works()
    {
        await this.client.Rules.Trigger("123", new(), TestContext.Current.CancellationToken);
    }
}
