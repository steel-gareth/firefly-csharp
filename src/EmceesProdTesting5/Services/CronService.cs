using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Cron;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class CronService : ICronService
{
    readonly Lazy<ICronServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICronServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public ICronService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CronService(this._client.WithOptions(modifier));
    }

    public CronService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new CronServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CronRunResponse> Run(
        CronRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Run(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CronRunResponse> Run(
        string cliToken,
        CronRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Run(parameters with { CliToken = cliToken }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CronServiceWithRawResponse : ICronServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICronServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CronServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CronServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CronRunResponse>> Run(
        CronRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CliToken == null)
        {
            throw new EmceesProdTesting5InvalidDataException(
                "'parameters.CliToken' cannot be null"
            );
        }

        HttpRequest<CronRunParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<CronRunResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CronRunResponse>> Run(
        string cliToken,
        CronRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Run(parameters with { CliToken = cliToken }, cancellationToken);
    }
}
