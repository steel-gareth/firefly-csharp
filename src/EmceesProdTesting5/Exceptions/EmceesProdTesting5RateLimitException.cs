using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5RateLimitException : EmceesProdTesting54xxException
{
    public EmceesProdTesting5RateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
