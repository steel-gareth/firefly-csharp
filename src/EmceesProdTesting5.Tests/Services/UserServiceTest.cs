using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var userSingle = await this.client.Users.Create(
            new() { Email = "james@firefly-iii.org" },
            TestContext.Current.CancellationToken
        );
        userSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var userSingle = await this.client.Users.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        userSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var userSingle = await this.client.Users.Update(
            "123",
            new() { Email = "james@firefly-iii.org" },
            TestContext.Current.CancellationToken
        );
        userSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var users = await this.client.Users.List(new(), TestContext.Current.CancellationToken);
        users.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Users.Delete("123", new(), TestContext.Current.CancellationToken);
    }
}
