using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingForbiddenException : MoreConflicting4xxException
{
    public MoreConflictingForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
