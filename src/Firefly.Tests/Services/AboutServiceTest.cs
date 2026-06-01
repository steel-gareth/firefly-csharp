using System.Threading.Tasks;

namespace Firefly.Tests.Services;

public class AboutServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveInfo_Works()
    {
        var response = await this.client.About.RetrieveInfo(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveUser_Works()
    {
        var userSingle = await this.client.About.RetrieveUser(
            new(),
            TestContext.Current.CancellationToken
        );
        userSingle.Validate();
    }
}
