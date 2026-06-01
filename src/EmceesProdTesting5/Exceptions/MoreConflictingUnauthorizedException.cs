using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingUnauthorizedException : MoreConflicting4xxException
{
    public MoreConflictingUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
