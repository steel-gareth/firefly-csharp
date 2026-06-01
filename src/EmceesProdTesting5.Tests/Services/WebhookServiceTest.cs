using System.Text.Json;
using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class WebhookServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var webhookSingle = await this.client.Webhooks.Create(
            new()
            {
                Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
                Response = JsonSerializer.Deserialize<JsonElement>("{}"),
                Title = "Update magic mirror on new transaction",
                Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
                UrlValue = "https://example.com",
            },
            TestContext.Current.CancellationToken
        );
        webhookSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var webhookSingle = await this.client.Webhooks.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        webhookSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var webhookSingle = await this.client.Webhooks.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        webhookSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var webhooks = await this.client.Webhooks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        webhooks.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Submit_Works()
    {
        await this.client.Webhooks.Submit("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TriggerTransaction_Works()
    {
        await this.client.Webhooks.TriggerTransaction(
            "123",
            new() { ID = "123" },
            TestContext.Current.CancellationToken
        );
    }
}
