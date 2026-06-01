using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Pets;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Everything about your Pets
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a new pet to the store
    /// </summary>
    Task<Pet> Create(PetCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single pet
    /// </summary>
    Task<Pet> Retrieve(PetRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(PetRetrieveParams, CancellationToken)"/>
    Task<Pet> Retrieve(
        long petID,
        PetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing pet by Id
    /// </summary>
    Task<Pet> Update(PetUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// delete a pet
    /// </summary>
    Task Delete(PetDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(PetDeleteParams, CancellationToken)"/>
    Task Delete(
        long petID,
        PetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Multiple status values can be provided with comma separated strings
    /// </summary>
    Task<List<Pet>> FindByStatus(
        PetFindByStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3
    /// for testing.
    /// </summary>
    Task<List<Pet>> FindByTags(
        PetFindByTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a pet in the store with form data
    /// </summary>
    Task UpdateByID(PetUpdateByIDParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateByID(PetUpdateByIDParams, CancellationToken)"/>
    Task UpdateByID(
        long petID,
        PetUpdateByIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// uploads an image
    /// </summary>
    Task<PetUploadImageResponse> UploadImage(
        PetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadImage(PetUploadImageParams, CancellationToken)"/>
    Task<PetUploadImageResponse> UploadImage(
        long petID,
        BinaryContent image,
        PetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /pet</c>, but is otherwise the
    /// same as <see cref="IPetService.Create(PetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Pet>> Create(
        PetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /pet/{petId}</c>, but is otherwise the
    /// same as <see cref="IPetService.Retrieve(PetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Pet>> Retrieve(
        PetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Pet>> Retrieve(
        long petID,
        PetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /pet</c>, but is otherwise the
    /// same as <see cref="IPetService.Update(PetUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Pet>> Update(
        PetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /pet/{petId}</c>, but is otherwise the
    /// same as <see cref="IPetService.Delete(PetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        PetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(PetDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        long petID,
        PetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /pet/findByStatus</c>, but is otherwise the
    /// same as <see cref="IPetService.FindByStatus(PetFindByStatusParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Pet>>> FindByStatus(
        PetFindByStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /pet/findByTags</c>, but is otherwise the
    /// same as <see cref="IPetService.FindByTags(PetFindByTagsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Pet>>> FindByTags(
        PetFindByTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /pet/{petId}</c>, but is otherwise the
    /// same as <see cref="IPetService.UpdateByID(PetUpdateByIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> UpdateByID(
        PetUpdateByIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateByID(PetUpdateByIDParams, CancellationToken)"/>
    Task<HttpResponse> UpdateByID(
        long petID,
        PetUpdateByIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /pet/{petId}/uploadImage</c>, but is otherwise the
    /// same as <see cref="IPetService.UploadImage(PetUploadImageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PetUploadImageResponse>> UploadImage(
        PetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadImage(PetUploadImageParams, CancellationToken)"/>
    Task<HttpResponse<PetUploadImageResponse>> UploadImage(
        long petID,
        BinaryContent image,
        PetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
