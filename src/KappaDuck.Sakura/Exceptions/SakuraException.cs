// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Diagnostics.CodeAnalysis;

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

    internal static void ThrowIf([DoesNotReturnIf(true)] bool condition, string? message)
    {
        if (condition)
            throw new SakuraException(message);
    }

    internal static void ThrowIfNull<T>([NotNull] T? value, string? message) => ThrowIf(value is null, message);
}
