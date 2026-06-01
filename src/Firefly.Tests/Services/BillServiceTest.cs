using System;
using System.Threading.Tasks;
using Firefly.Models.Bills;

namespace Firefly.Tests.Services;

public class BillServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var billSingle = await this.client.Bills.Create(
            new()
            {
                AmountMax = "123.45",
                AmountMin = "123.45",
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Name = "Rent",
                RepeatFreq = BillRepeatFrequency.Monthly,
            },
            TestContext.Current.CancellationToken
        );
        billSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var billSingle = await this.client.Bills.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        billSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var billSingle = await this.client.Bills.Update(
            "123",
            new() { Name = "Rent" },
            TestContext.Current.CancellationToken
        );
        billSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var billArray = await this.client.Bills.List(new(), TestContext.Current.CancellationToken);
        billArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Bills.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAttachments_Works()
    {
        var attachmentArray = await this.client.Bills.ListAttachments(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        attachmentArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListRules_Works()
    {
        var ruleArray = await this.client.Bills.ListRules(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        ruleArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTransactions_Works()
    {
        var transactionArray = await this.client.Bills.ListTransactions(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        transactionArray.Validate();
    }
}
