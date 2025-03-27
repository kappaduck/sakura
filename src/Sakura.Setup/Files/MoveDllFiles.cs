// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Spectre.Console;

namespace Sakura.Setup.Files;

internal sealed class MoveDllFiles(string installPath) : FileHandler
{
    internal override ValueTask<Result> HandleAsync(string file)
    {
        AnsiConsole.MarkupLine("[cyan]Moving dll files...[/]");

        try
        {
            Directory.CreateDirectory(installPath);
            DirectoryInfo source = new(file[..file.LastIndexOf('.')]);

            foreach (FileInfo sourceFile in source.EnumerateFiles("*.dll", SearchOption.AllDirectories))
            {
                string destination = Path.Combine(installPath, sourceFile.Name);
                sourceFile.MoveTo(destination);
            }

            source.Delete(recursive: true);
        }
        catch (Exception ex)
        {
            return ValueTask.FromResult(Result.Failure($"Failed to move dll files: {ex.Message}"));
        }

        return base.HandleAsync(file);
    }
}
