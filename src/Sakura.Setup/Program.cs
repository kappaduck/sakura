// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Sakura.Setup;
using Sakura.Setup.Files;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

CommandApp app = new();

app.Configure(config =>
{
    config.SetApplicationName("setup");

    config.AddCommand<Program>(Name)
        .WithDescription(Description)
        .WithExample("sdl")
        .WithExample("sdl --force");
});

return await app.RunAsync(args)
                .ConfigureAwait(false);

file sealed partial class Program : AsyncCommand<Program.Settings>
{
    public const string Name = "sdl";
    public const string Description = "Install SDL";

    private readonly string _workingDirectory;
    private readonly string _installPath;

    public Program()
    {
        _workingDirectory = RootDirectory.GetPath();

        _installPath = Path.Combine(_workingDirectory, "SDL3");
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (Directory.Exists(_installPath) && !settings.Force)
        {
            AnsiConsole.MarkupLine("[yellow]SDL3 is already installed. Use --force/-f to reinstall.[/]");
            return 0;
        }

        Result result = await InstallSDLAsync(settings).ConfigureAwait(false);

        if (!result.IsSuccess)
        {
            AnsiConsole.MarkupLine($"[red]Failed to install SDL3: {result.Error}[/]");
            return 1;
        }

        AnsiConsole.MarkupLine("[green]SDL3 installed successfully![/]");
        return 0;
    }

    private ValueTask<Result> InstallSDLAsync(Settings settings)
    {
        Uri download = new($"https://github.com/libsdl-org/SDL/releases/download/release-{settings.Version}/SDL3-{settings.Version}-win32-x64.zip");

        AnsiConsole.MarkupLine("[cyan]Installing SDL...[/]");

        string file = $"{Path.Combine(_workingDirectory, $"SDL3-{settings.Version}")}.zip";
        DownloadFile handler = new(download);

        handler.Next(new ExtractFile(_workingDirectory))
               .Next(new MoveDllFiles(_installPath));

        return handler.HandleAsync(file);
    }

    internal sealed class Settings : CommandSettings
    {
        [CommandOption("-v|--version")]
        [Description("SDL3 version to install")]
        [DefaultValue("3.2.8")]
        public required string Version { get; init; }

        [CommandOption("-f|--force")]
        [Description("Indicating whether to force an installation")]
        public bool Force { get; init; }
    }
}
