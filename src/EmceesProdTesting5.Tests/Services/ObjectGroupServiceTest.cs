using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class ObjectGroupServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var objectGroupSingle = await this.client.ObjectGroups.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        objectGroupSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var objectGroupSingle = await this.client.ObjectGroups.Update(
            "123",
            new() { Title = "My object group" },
            TestContext.Current.CancellationToken
        );
        objectGroupSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var objectGroups = await this.client.ObjectGroups.List(
            new(),
            TestContext.Current.CancellationToken
        );
        objectGroups.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.ObjectGroups.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListBills_Works()
    {
        var billArray = await this.client.ObjectGroups.ListBills(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        billArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListPiggyBanks_Works()
    {
        var piggyBankArray = await this.client.ObjectGroups.ListPiggyBanks(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        piggyBankArray.Validate();
    }
}
