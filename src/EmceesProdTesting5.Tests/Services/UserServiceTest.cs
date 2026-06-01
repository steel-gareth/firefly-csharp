using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var user = await this.client.Users.Create(new(), TestContext.Current.CancellationToken);
        user.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var user = await this.client.Users.Retrieve(
            "username",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Users.Update("username", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Users.Delete("username", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateWithList_Works()
    {
        var user = await this.client.Users.CreateWithList(
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Login_Works()
    {
        await this.client.Users.Login(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Logout_Works()
    {
        await this.client.Users.Logout(new(), TestContext.Current.CancellationToken);
    }
}
