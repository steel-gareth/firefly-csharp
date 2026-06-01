using System.Text;
using System.Threading.Tasks;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Services;

public class AttachmentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var attachmentSingle = await this.client.Attachments.Create(
            new()
            {
                AttachableID = "134",
                AttachableType = AttachableType.Bill,
                Filename = "file.pdf",
            },
            TestContext.Current.CancellationToken
        );
        attachmentSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var attachmentSingle = await this.client.Attachments.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var attachmentSingle = await this.client.Attachments.Update(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var attachmentArray = await this.client.Attachments.List(
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Attachments.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Download_Works()
    {
        await this.client.Attachments.Download("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upload_Works()
    {
        await this.client.Attachments.Upload(
            "123",
            Encoding.UTF8.GetBytes("Example data"),
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
