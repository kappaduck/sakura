// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

namespace KappaDuck.Sakura.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an error occurs in the Sakura library.
/// </summary>
public class SakuraException : Exception
{
    internal SakuraException()
    {
    }

    internal SakuraException(string? message) : base(message)
    {
    }

    internal SakuraException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
