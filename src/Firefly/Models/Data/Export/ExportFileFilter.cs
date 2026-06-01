using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Data.Export;

[JsonConverter(typeof(ExportFileFilterConverter))]
public enum ExportFileFilter
{
    Csv,
}

sealed class ExportFileFilterConverter : JsonConverter<ExportFileFilter>
{
    public override ExportFileFilter Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => ExportFileFilter.Csv,
            _ => (ExportFileFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExportFileFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExportFileFilter.Csv => "csv",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
