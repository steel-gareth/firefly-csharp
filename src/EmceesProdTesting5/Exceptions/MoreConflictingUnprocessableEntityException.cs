using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingUnprocessableEntityException : MoreConflicting4xxException
{
    public MoreConflictingUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
