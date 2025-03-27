// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Spectre.Console;
using System.IO.Compression;

namespace Sakura.Setup.Files;

internal sealed class ExtractFile(string rootPath) : FileHandler
{
    internal override ValueTask<Result> HandleAsync(string file)
    {
        AnsiConsole.MarkupLine("[cyan]Extracting file...[/]");

        try
        {
            string directory = Path.Combine(rootPath, file[..file.LastIndexOf('.')]);

            ZipFile.ExtractToDirectory(file, directory, overwriteFiles: true);
            File.Delete(file);
        }
        catch (Exception ex)
        {
            return ValueTask.FromResult(Result.Failure($"Failed to extract file: {ex.Message}"));
        }

        return base.HandleAsync(file);
    }
}
