using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingUnexpectedStatusCodeException : MoreConflictingApiException
{
    public MoreConflictingUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
