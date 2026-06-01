using System.Net;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingExceptionFactory
{
    public static MoreConflictingApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody
    )
    {
        return (int)statusCode switch
        {
            400 => new MoreConflictingBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            401 => new MoreConflictingUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            403 => new MoreConflictingForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            404 => new MoreConflictingNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            422 => new MoreConflictingUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            429 => new MoreConflictingRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 400 and <= 499 => new MoreConflicting4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 500 and <= 599 => new MoreConflicting5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            _ => new MoreConflictingUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
        };
    }
}
