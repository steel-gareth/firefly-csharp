using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Tests.Models.Accounts;

public class MetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meta
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Pagination expectedPagination = new()
        {
            Count = 20,
            CurrentPage = 1,
            PerPage = 100,
            Total = 3,
            TotalPages = 1,
        };

        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Meta
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meta
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Pagination expectedPagination = new()
        {
            Count = 20,
            CurrentPage = 1,
            PerPage = 100,
            Total = 3,
            TotalPages = 1,
        };

        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Meta
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Meta { };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Meta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Meta
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
        };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Meta
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Meta
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Meta copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Count = 20,
            CurrentPage = 1,
            PerPage = 100,
            Total = 3,
            TotalPages = 1,
        };

        long expectedCount = 20;
        long expectedCurrentPage = 1;
        long expectedPerPage = 100;
        long expectedTotal = 3;
        long expectedTotalPages = 1;

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedCurrentPage, model.CurrentPage);
        Assert.Equal(expectedPerPage, model.PerPage);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Count = 20,
            CurrentPage = 1,
            PerPage = 100,
            Total = 3,
            TotalPages = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Count = 20,
            CurrentPage = 1,
            PerPage = 100,
            Total = 3,
            TotalPages = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCount = 20;
        long expectedCurrentPage = 1;
        long expectedPerPage = 100;
        long expectedTotal = 3;
        long expectedTotalPages = 1;

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedCurrentPage, deserialized.CurrentPage);
        Assert.Equal(expectedPerPage, deserialized.PerPage);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Count = 20,
            CurrentPage = 1,
            PerPage = 100,
            Total = 3,
            TotalPages = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pagination { };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.CurrentPage);
        Assert.False(model.RawData.ContainsKey("current_page"));
        Assert.Null(model.PerPage);
        Assert.False(model.RawData.ContainsKey("per_page"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("total_pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pagination { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pagination
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            CurrentPage = null,
            PerPage = null,
            Total = null,
            TotalPages = null,
        };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.CurrentPage);
        Assert.False(model.RawData.ContainsKey("current_page"));
        Assert.Null(model.PerPage);
        Assert.False(model.RawData.ContainsKey("per_page"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("total_pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pagination
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            CurrentPage = null,
            PerPage = null,
            Total = null,
            TotalPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Count = 20,
            CurrentPage = 1,
            PerPage = 100,
            Total = 3,
            TotalPages = 1,
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
