using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Cron;

[JsonConverter(typeof(JsonModelConverter<CronResultRow, CronResultRowFromRaw>))]
public sealed record class CronResultRow : JsonModel
{
    /// <summary>
    /// If the cron job ran into some kind of an error, this value will be true.
    /// </summary>
    public bool? JobErrored
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("job_errored");
        }
        init { this._rawData.Set("job_errored", value); }
    }

    /// <summary>
    /// This value tells you if this specific cron job actually fired. It may not
    /// fire. Some cron jobs only fire every 24 hours, for example.
    /// </summary>
    public bool? JobFired
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("job_fired");
        }
        init { this._rawData.Set("job_fired", value); }
    }

    /// <summary>
    /// This value tells you if this specific cron job actually did something. The
    /// job may fire but not change anything.
    /// </summary>
    public bool? JobSucceeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("job_succeeded");
        }
        init { this._rawData.Set("job_succeeded", value); }
    }

    /// <summary>
    /// If the cron job ran into some kind of an error, this value will be the error
    /// message. The success message if the job actually ran OK.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JobErrored;
        _ = this.JobFired;
        _ = this.JobSucceeded;
        _ = this.Message;
    }

    public CronResultRow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CronResultRow(CronResultRow cronResultRow)
        : base(cronResultRow) { }
#pragma warning restore CS8618

    public CronResultRow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CronResultRow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CronResultRowFromRaw.FromRawUnchecked"/>
    public static CronResultRow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CronResultRowFromRaw : IFromRawJson<CronResultRow>
{
    /// <inheritdoc/>
    public CronResultRow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CronResultRow.FromRawUnchecked(rawData);
}
