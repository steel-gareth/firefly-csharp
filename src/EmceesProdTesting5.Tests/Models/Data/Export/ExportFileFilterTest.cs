using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Data.Export;

namespace EmceesProdTesting5.Tests.Models.Data.Export;

public class ExportFileFilterTest : TestBase
{
    [Theory]
    [InlineData(ExportFileFilter.Csv)]
    public void Validation_Works(ExportFileFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExportFileFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExportFileFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExportFileFilter.Csv)]
    public void SerializationRoundtrip_Works(ExportFileFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExportFileFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExportFileFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExportFileFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExportFileFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
