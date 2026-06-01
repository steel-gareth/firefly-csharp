using System.Net;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5ExceptionFactory
{
    public static EmceesProdTesting5ApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody
    )
    {
        return (int)statusCode switch
        {
            400 => new EmceesProdTesting5BadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            401 => new EmceesProdTesting5UnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            403 => new EmceesProdTesting5ForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            404 => new EmceesProdTesting5NotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            422 => new EmceesProdTesting5UnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            429 => new EmceesProdTesting5RateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 400 and <= 499 => new EmceesProdTesting54xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 500 and <= 599 => new EmceesProdTesting55xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            _ => new EmceesProdTesting5UnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
        };
    }
}
