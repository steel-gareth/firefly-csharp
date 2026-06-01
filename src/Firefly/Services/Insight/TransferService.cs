using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Insight.Expense;
using Firefly.Models.Insight.Transfer;

namespace Firefly.Services.Insight;

/// <inheritdoc/>
public sealed class TransferService : ITransferService
{
    readonly Lazy<ITransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public ITransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TransferService(this._client.WithOptions(modifier));
    }

    public TransferService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TransferServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> GetTotal(
        TransferGetTotalParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetTotal(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<TransferListByAssetAccountResponse>> ListByAssetAccount(
        TransferListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByAssetAccount(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByCategory(
        TransferListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByCategory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByTag(
        TransferListByTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByTag(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> ListWithoutCategory(
        TransferListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListWithoutCategory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> ListWithoutTag(
        TransferListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListWithoutTag(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TransferServiceWithRawResponse : ITransferServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TransferServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightTotalEntry>>> GetTotal(
        TransferGetTotalParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransferGetTotalParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightTotalEntries = await response
                    .Deserialize<List<InsightTotalEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightTotalEntries)
                    {
                        item.Validate();
                    }
                }
                return insightTotalEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<TransferListByAssetAccountResponse>>> ListByAssetAccount(
        TransferListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransferListByAssetAccountParams> request = new()
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
                    .Deserialize<List<TransferListByAssetAccountResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByCategory(
        TransferListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransferListByCategoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightGroupEntries = await response
                    .Deserialize<List<InsightGroupEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightGroupEntries)
                    {
                        item.Validate();
                    }
                }
                return insightGroupEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByTag(
        TransferListByTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransferListByTagParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightGroupEntries = await response
                    .Deserialize<List<InsightGroupEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightGroupEntries)
                    {
                        item.Validate();
                    }
                }
                return insightGroupEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutCategory(
        TransferListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransferListWithoutCategoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightTotalEntries = await response
                    .Deserialize<List<InsightTotalEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightTotalEntries)
                    {
                        item.Validate();
                    }
                }
                return insightTotalEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutTag(
        TransferListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransferListWithoutTagParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightTotalEntries = await response
                    .Deserialize<List<InsightTotalEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightTotalEntries)
                    {
                        item.Validate();
                    }
                }
                return insightTotalEntries;
            }
        );
    }
}
