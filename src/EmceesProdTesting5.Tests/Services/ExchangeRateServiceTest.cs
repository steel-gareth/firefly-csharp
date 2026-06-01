using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmceesProdTesting5.Tests.Services;

public class ExchangeRateServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var currencyExchangeRateSingle = await this.client.ExchangeRates.Create(
            new()
            {
                Date = "2026-04-01",
                From = "USD",
                Rates = JsonSerializer.Deserialize<JsonElement>("{}"),
                To = "EUR",
            },
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var currencyExchangeRateSingle = await this.client.ExchangeRates.Retrieve(
            "123",
            new(),
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var currencyExchangeRateSingle = await this.client.ExchangeRates.Update(
            "123",
            new() { Date = "2026-04-01", Rate = "2.3456" },
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateSingle.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var currencyExchangeRateArray = await this.client.ExchangeRates.List(
            new(),
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.ExchangeRates.Delete("123", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateByCurrencies_Works()
    {
        var currencyExchangeRateArray = await this.client.ExchangeRates.CreateByCurrencies(
            "USD",
            new()
            {
                From = "EUR",
                Body = new Dictionary<string, string>()
                {
                    { "2025-08-01", "1.2345" },
                    { "2025-08-02", "6.3456" },
                },
            },
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateByDate_Works()
    {
        var currencyExchangeRateArray = await this.client.ExchangeRates.CreateByDate(
            "2026-04-01",
            new()
            {
                DateValue = JsonSerializer.Deserialize<JsonElement>("{}"),
                From = "EUR",
                Rates = new Dictionary<string, string>()
                {
                    { "USD", "1.2345" },
                    { "GBP", "6.3456" },
                },
            },
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeleteAllByCurrencies_Works()
    {
        await this.client.ExchangeRates.DeleteAllByCurrencies(
            "USD",
            new() { From = "EUR" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeleteByDate_Works()
    {
        await this.client.ExchangeRates.DeleteByDate(
            "2026-04-01",
            new() { From = "EUR", To = "USD" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByCurrencies_Works()
    {
        var currencyExchangeRateArray = await this.client.ExchangeRates.ListByCurrencies(
            "USD",
            new() { From = "EUR" },
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveByDate_Works()
    {
        var currencyExchangeRateArray = await this.client.ExchangeRates.RetrieveByDate(
            "2026-04-01",
            new() { From = "EUR", To = "USD" },
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateArray.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateByDate_Works()
    {
        var currencyExchangeRateSingle = await this.client.ExchangeRates.UpdateByDate(
            "2026-04-01",
            new()
            {
                From = "EUR",
                To = "USD",
                Rate = "2.3456",
            },
            TestContext.Current.CancellationToken
        );
        currencyExchangeRateSingle.Validate();
    }
}
