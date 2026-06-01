using System.Threading.Tasks;

namespace Firefly.Tests.Services.Webhooks.Messages;

public class AttemptServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var attempt = await this.client.Webhooks.Messages.Attempts.Retrieve(
            1,
            new() { ID = "123", MessageID = 1 },
            TestContext.Current.CancellationToken
        );
        attempt.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var attempts = await this.client.Webhooks.Messages.Attempts.List(
            1,
            new() { ID = "123" },
            TestContext.Current.CancellationToken
        );
        attempts.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.Messages.Attempts.Delete(
            1,
            new() { ID = "123", MessageID = 1 },
            TestContext.Current.CancellationToken
        );
    }
}
