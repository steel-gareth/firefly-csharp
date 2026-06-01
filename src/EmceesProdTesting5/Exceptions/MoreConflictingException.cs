using System;
using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingException : Exception
{
    public MoreConflictingException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected MoreConflictingException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
