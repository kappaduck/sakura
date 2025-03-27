# Sakura 🌸

Sakura is a high-performance, lightweight, and fast game engine built on [SDL3] and its extensions ([SDL_image], [SDL_ttf], and [SDL_mixer]). Designed for modern .NET 9.0+ applications, it provides a clean and flexible API that simplifies game development. By hiding low-level complexities, Sakura allows developers to focus entirely on building games without worrying about memory management or system internals.

Optimized for speed and efficiency, Sakura leverages SDL3’s powerful features, including audio, graphics ([Renderer] and [GPU]), input handling, and window management. With its streamlined architecture, Sakura ensures a smooth and intuitive development experience, making game creation faster and easier.

## Sakura & SDL3 compatibility

Below is a list of Sakura versions and the corresponding SDL3 versions they support:

| Sakura Version | SDL3 Version | SDL_image Version | SDL_ttf Version | SDL_mixer Version |
| :------------: | :----------: | :---------------: | :-------------: | :---------------: |
|   `>= 0.1.0`   |   `3.2.8`    |   `unsupported`   |  `unsupported`  |   `unsupported`   |

> Support for SDL_image, SDL_ttf, and SDL_mixer is planned for future releases. Stay tuned!

## Cross-Platform

Sakura currently supports Windows, with Linux support planned for future releases.

> Other platforms may be considered in the future, but there are no plans for them at this time.

## Installation

Sakura is available as a NuGet package. You can install it using the following command:

```bash
dotnet add package KappaDuck.Sakura -v 0.1.0
```

or by adding the following line to your `.csproj` file:

```xml
<PackageReference Include="KappaDuck.Sakura" Version="0.1.0" />
```

or by using the Visual Studio NuGet Package Manager.

## Usage

*Work in progress...*

## Development

To build Sakura from source, you will need the following tools installed:

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

> The SDK includes everything you need to build and run .NET applications on your machine.

### Dependencies

You can install the required dependencies using the following command:

```bash
./setup.bat
```

> This script download and install the latest SDL3 version based on the [Sakura & SDL3 compatibility](#sakura--sdl3-compatibility) table.

You can display all available options by running the following command:

```bash
./setup.bat --help
```

## Credits

Sakura leverages and draws inspiration from the following projects:

- [SDL3]
- [SDL_image]
- [SDL_ttf]
- [SDL_mixer]
- [LazyFoo](https://lazyfoo.net/index.php)
- [Sayers.SDL2.Core](https://github.com/JeremySayers/Sayers.SDL2.Core)
- [SDL3-CS](https://github.com/flibitijibibo/SDL3-CS)
- [SFML](https://www.sfml-dev.org/)

[SDL3]: https://www.libsdl.org/
[SDL_image]: https://www.libsdl.org/projects/SDL_image/
[SDL_ttf]: https://www.libsdl.org/projects/SDL_ttf/
[SDL_mixer]: https://www.libsdl.org/projects/SDL_mixer/
[Renderer]: https://wiki.libsdl.org/CategoryRender
[GPU]: https://wiki.libsdl.org/CategoryGPU
