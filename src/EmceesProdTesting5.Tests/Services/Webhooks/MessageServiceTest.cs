using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services.Webhooks;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var message = await this.client.Webhooks.Messages.Retrieve(
            1,
            new() { ID = "123" },
            TestContext.Current.CancellationToken
        );
        message.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var messages = await this.client.Webhooks.Messages.List(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        messages.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.Messages.Delete(
            1,
            new() { ID = "123" },
            TestContext.Current.CancellationToken
        );
    }
}
