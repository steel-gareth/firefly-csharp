using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingNotFoundException : MoreConflicting4xxException
{
    public MoreConflictingNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
