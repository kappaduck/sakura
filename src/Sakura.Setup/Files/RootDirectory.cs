// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

namespace Sakura.Setup.Files;

internal static class RootDirectory
{
    private const string RootFile = ".git";

    internal static string GetPath()
    {
        DirectoryInfo? directory = new(Directory.GetCurrentDirectory());

        while (directory is not null)
        {
            string path = Path.Combine(directory.FullName, RootFile);

            if (Directory.Exists(path))
                return directory.FullName;

            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException("Root directory not found.");
    }
}
