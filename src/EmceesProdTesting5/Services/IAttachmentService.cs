using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Endpoints to manage the attachments of the authenticated user, including up- and
/// downloading of the files.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAttachmentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAttachmentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAttachmentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new attachment. The data required can be submitted as a JSON body or
    /// as a list of parameters. You cannot use this endpoint to upload the actual file
    /// data (see below). This endpoint only creates the attachment object.
    /// </summary>
    Task<AttachmentSingle> Create(
        AttachmentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single attachment. This endpoint only returns the available metadata for
    /// the attachment. Actual file data is handled in two other endpoints (see below).
    /// </summary>
    Task<AttachmentSingle> Retrieve(
        AttachmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AttachmentRetrieveParams, CancellationToken)"/>
    Task<AttachmentSingle> Retrieve(
        string id,
        AttachmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the meta data for an existing attachment. This endpoint does not allow
    /// you to upload or download data. For that, see below.
    /// </summary>
    Task<AttachmentSingle> Update(
        AttachmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AttachmentUpdateParams, CancellationToken)"/>
    Task<AttachmentSingle> Update(
        string id,
        AttachmentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint lists all attachments.
    /// </summary>
    Task<AttachmentArray> List(
        AttachmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// With this endpoint you delete an attachment, including any stored file data.
    /// </summary>
    Task Delete(AttachmentDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(AttachmentDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        AttachmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to download the binary content of a transaction. It
    /// will be sent to you as a download, using the content type
    /// "application/octet-stream" and content disposition "attachment;
    /// filename=example.pdf".
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Download(
        AttachmentDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(AttachmentDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string id,
        AttachmentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to upload (and possible overwrite) the file contents of an
    /// attachment. Simply put the entire file in the body as binary data.
    /// </summary>
    Task Upload(AttachmentUploadParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Upload(AttachmentUploadParams, CancellationToken)"/>
    Task Upload(
        string id,
        BinaryContent body,
        AttachmentUploadParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAttachmentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAttachmentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAttachmentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/attachments</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.Create(AttachmentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentSingle>> Create(
        AttachmentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/attachments/{id}</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.Retrieve(AttachmentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentSingle>> Retrieve(
        AttachmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AttachmentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentSingle>> Retrieve(
        string id,
        AttachmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/attachments/{id}</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.Update(AttachmentUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentSingle>> Update(
        AttachmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AttachmentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentSingle>> Update(
        string id,
        AttachmentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/attachments</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.List(AttachmentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentArray>> List(
        AttachmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/attachments/{id}</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.Delete(AttachmentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        AttachmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AttachmentDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        AttachmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/attachments/{id}/download</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.Download(AttachmentDownloadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Download(
        AttachmentDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(AttachmentDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string id,
        AttachmentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/attachments/{id}/upload</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.Upload(AttachmentUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Upload(
        AttachmentUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(AttachmentUploadParams, CancellationToken)"/>
    Task<HttpResponse> Upload(
        string id,
        BinaryContent body,
        AttachmentUploadParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
