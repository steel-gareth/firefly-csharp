using System;
using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingIOException : MoreConflictingException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public MoreConflictingIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
