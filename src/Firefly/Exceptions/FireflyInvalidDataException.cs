using System;

namespace Firefly.Exceptions;

public class FireflyInvalidDataException : FireflyException
{
    public FireflyInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
