using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class UserGroupServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var userGroupSingle = await this.client.UserGroups.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        userGroupSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var userGroupSingle = await this.client.UserGroups.Update(
            "1",
            new() { Title = "New user group title" },
            TestContext.Current.CancellationToken
        );
        userGroupSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var userGroups = await this.client.UserGroups.List(
            new(),
            TestContext.Current.CancellationToken
        );
        userGroups.Validate();
    }
}
