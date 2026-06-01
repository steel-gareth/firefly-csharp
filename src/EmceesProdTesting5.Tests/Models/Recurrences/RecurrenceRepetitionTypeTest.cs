using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Recurrences;

namespace EmceesProdTesting5.Tests.Models.Recurrences;

public class RecurrenceRepetitionTypeTest : TestBase
{
    [Theory]
    [InlineData(RecurrenceRepetitionType.Daily)]
    [InlineData(RecurrenceRepetitionType.Weekly)]
    [InlineData(RecurrenceRepetitionType.Ndom)]
    [InlineData(RecurrenceRepetitionType.Monthly)]
    [InlineData(RecurrenceRepetitionType.Yearly)]
    public void Validation_Works(RecurrenceRepetitionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecurrenceRepetitionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecurrenceRepetitionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RecurrenceRepetitionType.Daily)]
    [InlineData(RecurrenceRepetitionType.Weekly)]
    [InlineData(RecurrenceRepetitionType.Ndom)]
    [InlineData(RecurrenceRepetitionType.Monthly)]
    [InlineData(RecurrenceRepetitionType.Yearly)]
    public void SerializationRoundtrip_Works(RecurrenceRepetitionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecurrenceRepetitionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecurrenceRepetitionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecurrenceRepetitionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecurrenceRepetitionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
