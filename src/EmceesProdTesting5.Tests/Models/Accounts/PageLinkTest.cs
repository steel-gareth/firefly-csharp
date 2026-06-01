using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Tests.Models.Accounts;

public class PageLinkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };

        string expectedFirst = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1";
        string expectedLast = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12";
        string expectedNext = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3";
        string expectedPrev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2";
        string expectedSelf = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4";

        Assert.Equal(expectedFirst, model.First);
        Assert.Equal(expectedLast, model.Last);
        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
        Assert.Equal(expectedSelf, model.Self);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageLink>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageLink>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFirst = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1";
        string expectedLast = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12";
        string expectedNext = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3";
        string expectedPrev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2";
        string expectedSelf = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4";

        Assert.Equal(expectedFirst, deserialized.First);
        Assert.Equal(expectedLast, deserialized.Last);
        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
        Assert.Equal(expectedSelf, deserialized.Self);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PageLink
        {
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
        };

        Assert.Null(model.First);
        Assert.False(model.RawData.ContainsKey("first"));
        Assert.Null(model.Last);
        Assert.False(model.RawData.ContainsKey("last"));
        Assert.Null(model.Self);
        Assert.False(model.RawData.ContainsKey("self"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PageLink
        {
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PageLink
        {
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",

            // Null should be interpreted as omitted for these properties
            First = null,
            Last = null,
            Self = null,
        };

        Assert.Null(model.First);
        Assert.False(model.RawData.ContainsKey("first"));
        Assert.Null(model.Last);
        Assert.False(model.RawData.ContainsKey("last"));
        Assert.Null(model.Self);
        Assert.False(model.RawData.ContainsKey("self"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PageLink
        {
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",

            // Null should be interpreted as omitted for these properties
            First = null,
            Last = null,
            Self = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };

        Assert.Null(model.Next);
        Assert.False(model.RawData.ContainsKey("next"));
        Assert.Null(model.Prev);
        Assert.False(model.RawData.ContainsKey("prev"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",

            Next = null,
            Prev = null,
        };

        Assert.Null(model.Next);
        Assert.True(model.RawData.ContainsKey("next"));
        Assert.Null(model.Prev);
        Assert.True(model.RawData.ContainsKey("prev"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",

            Next = null,
            Prev = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PageLink
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };

        PageLink copied = new(model);

        Assert.Equal(model, copied);
    }
}
