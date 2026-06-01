using System;

namespace EmceesProdTesting5.Exceptions;

public class MoreConflictingInvalidDataException : MoreConflictingException
{
    public MoreConflictingInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
