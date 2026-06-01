using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingRateLimitException : MoreConflicting4xxException
{
    public MoreConflictingRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
