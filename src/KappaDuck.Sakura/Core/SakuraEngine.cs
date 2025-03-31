// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using KappaDuck.Sakura.Exceptions;
using KappaDuck.Sakura.Interop.SDL;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KappaDuck.Sakura.Core;

/// <summary>
/// The engine to initialize and shutdown <see cref="SubSystem"/>.
/// </summary>
public sealed partial class SakuraEngine : IDisposable
{
    private const string IdentifierProperty = "SDL.app.metadata.identifier";
    private const string NameProperty = "SDL.app.metadata.name";
    private const string VersionProperty = "SDL.app.metadata.version";
    private const string AuthorProperty = "SDL.app.metadata.creator";
    private const string CopyrightProperty = "SDL.app.metadata.copyright";
    private const string UrlProperty = "SDL.app.metadata.url";
    private const string TypeProperty = "SDL.app.metadata.type";

    private static readonly Lock _lock = new();

    private static SakuraEngine? _instance;
    private static SubSystem _subSystems = SubSystem.None;
    private static int _refCount;

    private SakuraEngine()
    {
    }

    /// <summary>
    /// Gets the version of the native library that Sakura is using.
    /// </summary>
    public static string Version
    {
        get
        {
            int version = SDL_GetVersion();

            int major = version / 1000000;
            int minor = version / 1000 % 1000;
            int patch = version % 1000;

            return $"{major}.{minor}.{patch}";
        }
    }

    /// <summary>
    /// Shutdown the engine and all subsystems.
    /// </summary>
    public void Dispose()
    {
        lock (_lock)
        {
            if (Interlocked.Decrement(ref _refCount) > 0)
                return;

            SDL_QuitSubSystem(_subSystems);
            SDL_Quit();

            Cleanup();
        }
    }

    /// <summary>
    /// Gets the number of milliseconds since the engine initialization.
    /// </summary>
    /// <returns>The timespan in milliseconds.</returns>
    public static TimeSpan GetTicks()
    {
        ulong ticks = SDL_GetTicks();
        return TimeSpan.FromMilliseconds(ticks);
    }

    /// <summary>
    /// Determines whether the specified <see cref="SubSystem"/> is initialized.
    /// </summary>
    /// <param name="subSystem">The subsystem to check.</param>
    /// <returns><see langword="true"/> if the subsystem is initialized; otherwise, <see langword="false"/>.</returns>
    public static bool Has(SubSystem subSystem)
        => (_subSystems & subSystem) == subSystem;

    /// <summary>
    /// Initialize the engine with the specified <see cref="SubSystem"/> and optional <see cref="AppMetadata"/>.
    /// </summary>
    /// <remarks>
    /// Initialized subsystems are stored and will be uninitialized on <see cref="Dispose" />
    /// or call directly <see cref="QuitSubSystem(SubSystem)"/> to shut down specific subsystems.
    /// You can initialize the same subsystem multiple times. It will only initializes once.
    /// </remarks>
    /// <param name="subSystem">The subsystem to initialize.</param>
    /// <param name="metadata">The metadata of the application.</param>
    /// <returns>An instance of <see cref="SakuraEngine"/>.</returns>
    /// <exception cref="SakuraNativeException">Failed to initialize the subsystem.</exception>
    public static SakuraEngine Init(SubSystem subSystem, AppMetadata? metadata = null)
    {
        lock (_lock)
        {
            _instance ??= new SakuraEngine();

            SetAppMetadata(metadata);
            InternalInit(subSystem);

            return _instance;
        }
    }

    /// <summary>
    /// Initialize specific subsystems.
    /// </summary>
    /// <remarks>
    /// You should call <see cref="Init(SubSystem, AppMetadata?)"/> before using this method to initialize the engine.
    /// </remarks>
    /// <param name="subSystem">The subsystem to initialize.</param>
    /// <exception cref="SakuraException">The engine is not initialized.</exception>
    /// <exception cref="SakuraNativeException">Failed to initialize the subsystem.</exception>
    public static void InitSubsystem(SubSystem subSystem)
    {
        ThrowIfInstanceNull();

        lock (_lock)
        {
            if (Has(subSystem))
                return;

            SakuraNativeException.ThrowIfFailed(SDL_InitSubSystem(subSystem));

            _subSystems |= subSystem;
        }
    }

    /// <summary>
    /// Quit the specified <see cref="SubSystem"/>.
    /// </summary>
    /// <remarks>
    /// <para>You should call <see cref="Init(SubSystem, AppMetadata?)"/> before using this method to initialize the engine.</para>
    /// <para>You can shut down the same subsystem multiple times. It will only shut down once.</para>
    /// You still need to call <see cref="Dispose" /> or <see langword="using"/> even if you close all subsystems.
    /// </remarks>
    /// <param name="subSystem">The subsystem to quit.</param>
    /// <exception cref="SakuraException">The engine is not initialized.</exception>
    public static void QuitSubSystem(SubSystem subSystem)
    {
        ThrowIfInstanceNull();

        lock (_lock)
        {
            if (!Has(subSystem))
                return;

            SDL_QuitSubSystem(subSystem);

            _subSystems &= ~subSystem;
        }
    }

    private static void Cleanup()
    {
        _instance = null;
        _subSystems = SubSystem.None;
    }

    private static void InternalInit(SubSystem subSystem)
    {
        if (Has(subSystem))
        {
            Interlocked.Increment(ref _refCount);
            return;
        }

        SakuraNativeException.ThrowIfFailed(SDL_InitSubSystem(subSystem));

        Interlocked.Increment(ref _refCount);

        _subSystems |= subSystem;
    }

    private static void SetAppMetadata(AppMetadata? metadata)
    {
        if (metadata is null)
            return;

        if (!string.IsNullOrEmpty(metadata.Id))
            SDL_SetAppMetadataProperty(IdentifierProperty, metadata.Id);

        if (!string.IsNullOrEmpty(metadata.Name))
            SDL_SetAppMetadataProperty(NameProperty, metadata.Name);

        if (!string.IsNullOrEmpty(metadata.Version))
            SDL_SetAppMetadataProperty(VersionProperty, metadata.Version);

        if (!string.IsNullOrEmpty(metadata.Author))
            SDL_SetAppMetadataProperty(AuthorProperty, metadata.Author);

        if (!string.IsNullOrEmpty(metadata.Copyright))
            SDL_SetAppMetadataProperty(CopyrightProperty, metadata.Copyright);

        if (metadata.Url is not null)
            SDL_SetAppMetadataProperty(UrlProperty, metadata.Url.ToString());

        if (!string.IsNullOrEmpty(metadata.Type))
            SDL_SetAppMetadataProperty(TypeProperty, metadata.Type);
    }

    private static void ThrowIfInstanceNull()
        => SakuraException.ThrowIfNull(_instance, "The engine is not initialized.");

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ulong SDL_GetTicks();

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int SDL_GetVersion();

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_InitSubSystem(SubSystem subSystem);

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_QuitSubSystem(SubSystem subSystem);

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_Quit();

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_SetAppMetadataProperty(string name, string value);
}
