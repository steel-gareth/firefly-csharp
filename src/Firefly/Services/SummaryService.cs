using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Summary;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class SummaryService : ISummaryService
{
    readonly Lazy<ISummaryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISummaryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public ISummaryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SummaryService(this._client.WithOptions(modifier));
    }

    public SummaryService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SummaryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, SummaryRetrieveBasicResponse>> RetrieveBasic(
        SummaryRetrieveBasicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveBasic(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SummaryServiceWithRawResponse : ISummaryServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISummaryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SummaryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SummaryServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, SummaryRetrieveBasicResponse>>> RetrieveBasic(
        SummaryRetrieveBasicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SummaryRetrieveBasicParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<Dictionary<string, SummaryRetrieveBasicResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse.Values)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }
}
