using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Bills;

namespace EmceesProdTesting5.Tests.Models.Bills;

public class BillRepeatFrequencyTest : TestBase
{
    [Theory]
    [InlineData(BillRepeatFrequency.Weekly)]
    [InlineData(BillRepeatFrequency.Monthly)]
    [InlineData(BillRepeatFrequency.Quarterly)]
    [InlineData(BillRepeatFrequency.HalfYear)]
    [InlineData(BillRepeatFrequency.Yearly)]
    public void Validation_Works(BillRepeatFrequency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillRepeatFrequency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillRepeatFrequency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillRepeatFrequency.Weekly)]
    [InlineData(BillRepeatFrequency.Monthly)]
    [InlineData(BillRepeatFrequency.Quarterly)]
    [InlineData(BillRepeatFrequency.HalfYear)]
    [InlineData(BillRepeatFrequency.Yearly)]
    public void SerializationRoundtrip_Works(BillRepeatFrequency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillRepeatFrequency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillRepeatFrequency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillRepeatFrequency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillRepeatFrequency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
