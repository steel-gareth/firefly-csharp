using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Cron;

namespace EmceesProdTesting5.Tests.Models.Cron;

public class CronResultRowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CronResultRow
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };

        bool expectedJobErrored = false;
        bool expectedJobFired = true;
        bool expectedJobSucceeded = true;
        string expectedMessage = "Cron result message";

        Assert.Equal(expectedJobErrored, model.JobErrored);
        Assert.Equal(expectedJobFired, model.JobFired);
        Assert.Equal(expectedJobSucceeded, model.JobSucceeded);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CronResultRow
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CronResultRow>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CronResultRow
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CronResultRow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedJobErrored = false;
        bool expectedJobFired = true;
        bool expectedJobSucceeded = true;
        string expectedMessage = "Cron result message";

        Assert.Equal(expectedJobErrored, deserialized.JobErrored);
        Assert.Equal(expectedJobFired, deserialized.JobFired);
        Assert.Equal(expectedJobSucceeded, deserialized.JobSucceeded);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CronResultRow
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CronResultRow { };

        Assert.Null(model.JobErrored);
        Assert.False(model.RawData.ContainsKey("job_errored"));
        Assert.Null(model.JobFired);
        Assert.False(model.RawData.ContainsKey("job_fired"));
        Assert.Null(model.JobSucceeded);
        Assert.False(model.RawData.ContainsKey("job_succeeded"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CronResultRow { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CronResultRow
        {
            JobErrored = null,
            JobFired = null,
            JobSucceeded = null,
            Message = null,
        };

        Assert.Null(model.JobErrored);
        Assert.True(model.RawData.ContainsKey("job_errored"));
        Assert.Null(model.JobFired);
        Assert.True(model.RawData.ContainsKey("job_fired"));
        Assert.Null(model.JobSucceeded);
        Assert.True(model.RawData.ContainsKey("job_succeeded"));
        Assert.Null(model.Message);
        Assert.True(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CronResultRow
        {
            JobErrored = null,
            JobFired = null,
            JobSucceeded = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CronResultRow
        {
            JobErrored = false,
            JobFired = true,
            JobSucceeded = true,
            Message = "Cron result message",
        };

        CronResultRow copied = new(model);

        Assert.Equal(model, copied);
    }
}
