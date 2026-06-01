using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Cron;

namespace EmceesProdTesting5.Tests.Models.Cron;

public class CronRunResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CronRunResponse
        {
            AutoBudgets = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            RecurringTransactions = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            Telemetry = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
        };

        CronResultRow expectedAutoBudgets = new()
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };
        CronResultRow expectedRecurringTransactions = new()
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };
        CronResultRow expectedTelemetry = new()
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };

        Assert.Equal(expectedAutoBudgets, model.AutoBudgets);
        Assert.Equal(expectedRecurringTransactions, model.RecurringTransactions);
        Assert.Equal(expectedTelemetry, model.Telemetry);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CronRunResponse
        {
            AutoBudgets = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            RecurringTransactions = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            Telemetry = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CronRunResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CronRunResponse
        {
            AutoBudgets = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            RecurringTransactions = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            Telemetry = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CronRunResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CronResultRow expectedAutoBudgets = new()
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };
        CronResultRow expectedRecurringTransactions = new()
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };
        CronResultRow expectedTelemetry = new()
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };

        Assert.Equal(expectedAutoBudgets, deserialized.AutoBudgets);
        Assert.Equal(expectedRecurringTransactions, deserialized.RecurringTransactions);
        Assert.Equal(expectedTelemetry, deserialized.Telemetry);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CronRunResponse
        {
            AutoBudgets = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            RecurringTransactions = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            Telemetry = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CronRunResponse { };

        Assert.Null(model.AutoBudgets);
        Assert.False(model.RawData.ContainsKey("auto_budgets"));
        Assert.Null(model.RecurringTransactions);
        Assert.False(model.RawData.ContainsKey("recurring_transactions"));
        Assert.Null(model.Telemetry);
        Assert.False(model.RawData.ContainsKey("telemetry"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CronRunResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CronRunResponse
        {
            // Null should be interpreted as omitted for these properties
            AutoBudgets = null,
            RecurringTransactions = null,
            Telemetry = null,
        };

        Assert.Null(model.AutoBudgets);
        Assert.False(model.RawData.ContainsKey("auto_budgets"));
        Assert.Null(model.RecurringTransactions);
        Assert.False(model.RawData.ContainsKey("recurring_transactions"));
        Assert.Null(model.Telemetry);
        Assert.False(model.RawData.ContainsKey("telemetry"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CronRunResponse
        {
            // Null should be interpreted as omitted for these properties
            AutoBudgets = null,
            RecurringTransactions = null,
            Telemetry = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CronRunResponse
        {
            AutoBudgets = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            RecurringTransactions = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
            Telemetry = new()
            {
                JobErrored = false,
                JobFired = true,
                JobSucceeded = true,
                Message = "Cron result message",
            },
        };

        CronRunResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
