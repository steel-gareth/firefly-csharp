using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingBadRequestException : MoreConflicting4xxException
{
    public MoreConflictingBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
