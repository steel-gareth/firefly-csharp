using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Pets;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class PetService : IPetService
{
    readonly Lazy<IPetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IMoreConflictingClient _client;

    /// <inheritdoc/>
    public IPetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PetService(this._client.WithOptions(modifier));
    }

    public PetService(IMoreConflictingClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Pet> Create(
        PetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Pet> Retrieve(
        PetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Pet> Retrieve(
        long petID,
        PetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PetID = petID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Pet> Update(
        PetUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(PetDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        long petID,
        PetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { PetID = petID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<Pet>> FindByStatus(
        PetFindByStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FindByStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<Pet>> FindByTags(
        PetFindByTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FindByTags(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task UpdateByID(
        PetUpdateByIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.UpdateByID(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpdateByID(
        long petID,
        PetUpdateByIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.UpdateByID(parameters with { PetID = petID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PetUploadImageResponse> UploadImage(
        PetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UploadImage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PetUploadImageResponse> UploadImage(
        long petID,
        BinaryContent image,
        PetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadImage(
            parameters with
            {
                PetID = petID,
                Image = image,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class PetServiceWithRawResponse : IPetServiceWithRawResponse
{
    readonly IMoreConflictingClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PetServiceWithRawResponse(IMoreConflictingClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Pet>> Create(
        PetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pet = await response.Deserialize<Pet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pet.Validate();
                }
                return pet;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Pet>> Retrieve(
        PetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PetID == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.PetID' cannot be null");
        }

        HttpRequest<PetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pet = await response.Deserialize<Pet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pet.Validate();
                }
                return pet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Pet>> Retrieve(
        long petID,
        PetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PetID = petID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Pet>> Update(
        PetUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PetUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pet = await response.Deserialize<Pet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pet.Validate();
                }
                return pet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        PetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PetID == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.PetID' cannot be null");
        }

        HttpRequest<PetDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        long petID,
        PetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { PetID = petID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Pet>>> FindByStatus(
        PetFindByStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PetFindByStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pets = await response.Deserialize<List<Pet>>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in pets)
                    {
                        item.Validate();
                    }
                }
                return pets;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Pet>>> FindByTags(
        PetFindByTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PetFindByTagsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pets = await response.Deserialize<List<Pet>>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in pets)
                    {
                        item.Validate();
                    }
                }
                return pets;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UpdateByID(
        PetUpdateByIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PetID == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.PetID' cannot be null");
        }

        HttpRequest<PetUpdateByIDParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UpdateByID(
        long petID,
        PetUpdateByIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateByID(parameters with { PetID = petID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PetUploadImageResponse>> UploadImage(
        PetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PetID == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.PetID' cannot be null");
        }
        if (parameters.Image == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.Image' cannot be null");
        }

        HttpRequest<PetUploadImageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PetUploadImageResponse>(token)
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
    public Task<HttpResponse<PetUploadImageResponse>> UploadImage(
        long petID,
        BinaryContent image,
        PetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadImage(
            parameters with
            {
                PetID = petID,
                Image = image,
            },
            cancellationToken
        );
    }
}
