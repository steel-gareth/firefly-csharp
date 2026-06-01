using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflicting5xxException : MoreConflictingApiException
{
    public MoreConflicting5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
