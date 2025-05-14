// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Spectre.Console;
using System.IO.Compression;

namespace Sakura.Setup.Files;

internal sealed class ExtractFile(string rootPath) : FileHandler
{
    internal override async ValueTask<Result> HandleAsync(string file)
    {
        AnsiConsole.MarkupLine("[cyan]Extracting file...[/]");

        try
        {
            string directory = Path.Combine(rootPath, file[..file.LastIndexOf('.')]);

            await ZipFile.ExtractToDirectoryAsync(file, directory, overwriteFiles: true).ConfigureAwait(false);
            File.Delete(file);
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to extract file: {ex.Message}");
        }

        return await base.HandleAsync(file).ConfigureAwait(false);
    }
}
