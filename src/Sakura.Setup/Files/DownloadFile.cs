// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Spectre.Console;

namespace Sakura.Setup.Files;

internal sealed class DownloadFile(Uri download) : FileHandler
{
    internal override async ValueTask<Result> HandleAsync(string file)
    {
        Status status = AnsiConsole.Status().Spinner(Spinner.Known.BouncingBar).SpinnerStyle(Style.Parse("cyan"));

        Task<Result> task = status.StartAsync("Downloading file...", async _ =>
        {
            try
            {
                using HttpClient client = new();

                Stream stream = await client.GetStreamAsync(download).ConfigureAwait(false);
                FileStream fileStream = File.Create(file);

                await using (fileStream.ConfigureAwait(false))
                {
                    await stream.CopyToAsync(fileStream).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failed to download file: {ex.Message}");
            }

            return Result.Success();
        });

        Result result = await task.ConfigureAwait(false);

        return result.IsSuccess ? await base.HandleAsync(file).ConfigureAwait(false) : result;
    }
}
