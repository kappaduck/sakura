// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

namespace Sakura.Setup.Files;

internal abstract class FileHandler
{
    private FileHandler? _next;

    internal FileHandler Next(FileHandler handler)
    {
        _next = handler;
        return handler;
    }

    internal virtual ValueTask<Result> HandleAsync(string file)
        => _next?.HandleAsync(file) ?? ValueTask.FromResult(Result.Success());
}
