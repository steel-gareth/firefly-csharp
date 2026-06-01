using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflicting4xxException : MoreConflictingApiException
{
    public MoreConflicting4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
