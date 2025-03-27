// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Sakura.Setup;

internal readonly struct Result
{
    [MemberNotNullWhen(false, nameof(Error))]
    internal bool IsSuccess => Error is null;

    internal string? Error { get; }

    private Result(string? error) => Error = error;

    internal static Result Success() => new(error: null);

    internal static Result Failure(string error) => new(error);
}
