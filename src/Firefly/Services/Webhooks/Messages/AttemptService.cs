using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Webhooks.Messages.Attempts;

namespace Firefly.Services.Webhooks.Messages;

/// <inheritdoc/>
public sealed class AttemptService : IAttemptService
{
    readonly Lazy<IAttemptServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAttemptServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IAttemptService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AttemptService(this._client.WithOptions(modifier));
    }

    public AttemptService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AttemptServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AttemptRetrieveResponse> Retrieve(
        AttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AttemptRetrieveResponse> Retrieve(
        long attemptID,
        AttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { AttemptID = attemptID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AttemptListResponse> List(
        AttemptListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AttemptListResponse> List(
        long messageID,
        AttemptListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        AttemptDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        long attemptID,
        AttemptDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { AttemptID = attemptID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AttemptServiceWithRawResponse : IAttemptServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAttemptServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AttemptServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AttemptServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttemptRetrieveResponse>> Retrieve(
        AttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AttemptID == null)
        {
            throw new FireflyInvalidDataException("'parameters.AttemptID' cannot be null");
        }

        HttpRequest<AttemptRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var attempt = await response
                    .Deserialize<AttemptRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    attempt.Validate();
                }
                return attempt;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AttemptRetrieveResponse>> Retrieve(
        long attemptID,
        AttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { AttemptID = attemptID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttemptListResponse>> List(
        AttemptListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new FireflyInvalidDataException("'parameters.MessageID' cannot be null");
        }

        HttpRequest<AttemptListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var attempts = await response
                    .Deserialize<AttemptListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    attempts.Validate();
                }
                return attempts;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AttemptListResponse>> List(
        long messageID,
        AttemptListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        AttemptDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AttemptID == null)
        {
            throw new FireflyInvalidDataException("'parameters.AttemptID' cannot be null");
        }

        HttpRequest<AttemptDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        long attemptID,
        AttemptDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { AttemptID = attemptID }, cancellationToken);
    }
}
