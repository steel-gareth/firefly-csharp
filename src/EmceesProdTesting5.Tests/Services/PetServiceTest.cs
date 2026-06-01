using System.Text;
using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class PetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var pet = await this.client.Pets.Create(
            new() { Name = "doggie", PhotoUrls = ["string"] },
            TestContext.Current.CancellationToken
        );
        pet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var pet = await this.client.Pets.Retrieve(0, new(), TestContext.Current.CancellationToken);
        pet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var pet = await this.client.Pets.Update(
            new() { Name = "doggie", PhotoUrls = ["string"] },
            TestContext.Current.CancellationToken
        );
        pet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Pets.Delete(0, new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task FindByStatus_Works()
    {
        var pets = await this.client.Pets.FindByStatus(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task FindByTags_Works()
    {
        var pets = await this.client.Pets.FindByTags(new(), TestContext.Current.CancellationToken);
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateByID_Works()
    {
        await this.client.Pets.UpdateByID(0, new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UploadImage_Works()
    {
        var response = await this.client.Pets.UploadImage(
            0,
            Encoding.UTF8.GetBytes("Example data"),
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
