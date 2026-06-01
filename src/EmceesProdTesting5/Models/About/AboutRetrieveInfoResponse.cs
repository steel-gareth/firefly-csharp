using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.About;

[JsonConverter(
    typeof(JsonModelConverter<AboutRetrieveInfoResponse, AboutRetrieveInfoResponseFromRaw>)
)]
public sealed record class AboutRetrieveInfoResponse : JsonModel
{
    public AboutRetrieveInfoResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AboutRetrieveInfoResponseData>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
    }

    public AboutRetrieveInfoResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AboutRetrieveInfoResponse(AboutRetrieveInfoResponse aboutRetrieveInfoResponse)
        : base(aboutRetrieveInfoResponse) { }
#pragma warning restore CS8618

    public AboutRetrieveInfoResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AboutRetrieveInfoResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AboutRetrieveInfoResponseFromRaw.FromRawUnchecked"/>
    public static AboutRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AboutRetrieveInfoResponseFromRaw : IFromRawJson<AboutRetrieveInfoResponse>
{
    /// <inheritdoc/>
    public AboutRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AboutRetrieveInfoResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<AboutRetrieveInfoResponseData, AboutRetrieveInfoResponseDataFromRaw>)
)]
public sealed record class AboutRetrieveInfoResponseData : JsonModel
{
    /// <summary>
    /// Same value as the version field.
    /// </summary>
    public string? ApiVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("api_version", value);
        }
    }

    public string? Driver
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("driver");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("driver", value);
        }
    }

    public string? Os
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("os");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("os", value);
        }
    }

    public string? PhpVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("php_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("php_version", value);
        }
    }

    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiVersion;
        _ = this.Driver;
        _ = this.Os;
        _ = this.PhpVersion;
        _ = this.Version;
    }

    public AboutRetrieveInfoResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AboutRetrieveInfoResponseData(
        AboutRetrieveInfoResponseData aboutRetrieveInfoResponseData
    )
        : base(aboutRetrieveInfoResponseData) { }
#pragma warning restore CS8618

    public AboutRetrieveInfoResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AboutRetrieveInfoResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AboutRetrieveInfoResponseDataFromRaw.FromRawUnchecked"/>
    public static AboutRetrieveInfoResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AboutRetrieveInfoResponseDataFromRaw : IFromRawJson<AboutRetrieveInfoResponseData>
{
    /// <inheritdoc/>
    public AboutRetrieveInfoResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AboutRetrieveInfoResponseData.FromRawUnchecked(rawData);
}
