// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

namespace KappaDuck.Sakura.Input.Events;

/// <summary>
/// The types of events that can be delivered.
/// </summary>
public enum EventType
{
    /// <summary>
    /// No event. Do not use this value. It purpose is to used for <see cref="EventManager.Push(Span{Event})"/>.
    /// </summary>
    None = 0x0,

    /// <summary>
    /// User-requested quit.
    /// </summary>
    Quit = 0x100,

    /// <summary>
    /// The user's locale preference has changed.
    /// </summary>
    LocaleChanged = 0x107,

    /// <summary>
    /// The system theme has changed.
    /// </summary>
    SystemThemeChanged = 0x108,

    /// <summary>
    /// Display orientation has changed to data1.
    /// </summary>
    DisplayOrientationChanged = 0x151,

    /// <summary>
    /// Display has been added to the system.
    /// </summary>
    DisplayAdded = 0x152,

    /// <summary>
    /// Display has been removed from the system.
    /// </summary>
    DisplayRemoved = 0x153,

    /// <summary>
    /// Display has changed position.
    /// </summary>
    DisplayMoved = 0x154,

    /// <summary>
    /// Display has changed desktop mode.
    /// </summary>
    DesktopModeChanged = 0x155,

    /// <summary>
    /// Display has changed current mode.
    /// </summary>
    CurrentModeChanged = 0x156,

    /// <summary>
    /// Display has changed content scale.
    /// </summary>
    ContentScaleChanged = 0x157,

    /// <summary>
    /// Window has been shown.
    /// </summary>
    WindowShown = 0x202,

    /// <summary>
    /// Window has been hidden.
    /// </summary>
    WindowHidden = 0x203,

    /// <summary>
    /// Window has been exposed and should be redrawn, and can be redrawn directly from event watchers for this event.
    /// </summary>
    WindowExposed = 0x204,

    /// <summary>
    /// Window has been moved to data1, data2.
    /// </summary>
    WindowMoved = 0x205,

    /// <summary>
    /// Window has been resized to data1 x data2.
    /// </summary>
    WindowResized = 0x206,

    /// <summary>
    /// The pixel size of the window has changed to data1 x data2.
    /// </summary>
    WindowPixelSizeChanged = 0x207,

    /// <summary>
    /// The pixel size of a Metal view associated with the window has changed.
    /// </summary>
    MetalViewResized = 0x208,

    /// <summary>
    /// Window has been minimized.
    /// </summary>
    WindowMinimized = 0x209,

    /// <summary>
    /// Window has been maximized.
    /// </summary>
    WindowMaximized = 0x20A,

    /// <summary>
    /// Window has been restored to normal size and position.
    /// </summary>
    WindowRestored = 0x20B,

    /// <summary>
    /// Window has gained mouse focus.
    /// </summary>
    MouseEnter = 0x20C,

    /// <summary>
    /// Window has lost mouse focus.
    /// </summary>
    MouseLeave = 0x20D,

    /// <summary>
    /// Window has gained keyboard focus.
    /// </summary>
    FocusGained = 0x20E,

    /// <summary>
    /// Window has lost keyboard focus.
    /// </summary>
    FocusLost = 0x20F,

    /// <summary>
    /// The window manager requests that the window be closed.
    /// </summary>
    WindowCloseRequested = 0x210,

    /// <summary>
    /// Window had a hit test that wasn't SDL_HITTEST_NORMAL.
    /// </summary>
    WindowHitTest = 0x211,

    /// <summary>
    /// The ICC profile of the window's display has changed.
    /// </summary>
    IccProfileChanged = 0x212,

    /// <summary>
    /// Window has been moved to display data1.
    /// </summary>
    WindowDisplayChanged = 0x213,

    /// <summary>
    /// Window display scale has been changed.
    /// </summary>
    WindowDisplayScaleChanged = 0x214,

    /// <summary>
    /// The window safe area has been changed.
    /// </summary>
    WindowSafeAreaChanged = 0x215,

    /// <summary>
    /// Window has been occluded.
    /// </summary>
    WindowOccluded = 0x216,

    /// <summary>
    /// The window has entered Fullscreen mode.
    /// </summary>
    EnterFullScreen = 0x217,

    /// <summary>
    /// The window has left Fullscreen mode.
    /// </summary>
    LeaveFullScreen = 0x218,

    /// <summary>
    /// The window with the associated ID is being or has been destroyed. If this message is being handled
    /// in an event watcher, the window handle is still valid and can still be used to retrieve any properties
    /// associated with the window. Otherwise, the handle has already been destroyed and all resources
    /// associated with it are invalid.
    /// </summary>
    WindowDestroyed = 0x219,

    /// <summary>
    /// Window HDR properties have changed.
    /// </summary>
    HdrStateChanged = 0x21A,

    /// <summary>
    /// Key pressed.
    /// </summary>
    KeyDown = 0x300,

    /// <summary>
    /// Key released.
    /// </summary>
    KeyUp = 0x301,

    /// <summary>
    /// Keyboard text editing (composition).
    /// </summary>
    TextEditing = 0x302,

    /// <summary>
    /// Keyboard text input.
    /// </summary>
    TextInput = 0x303,

    /// <summary>
    /// Keymap changed due to a system event such as an input language or keyboard layout change.
    /// </summary>
    KeymapChanged = 0x304,

    /// <summary>
    /// A new keyboard has been inserted to the system.
    /// </summary>
    KeyboardAdded = 0x305,

    /// <summary>
    /// A keyboard has been removed from the system.
    /// </summary>
    KeyboardRemoved = 0x306,

    /// <summary>
    /// Keyboard text editing candidates.
    /// </summary>
    TextEditingCandidates = 0x307,

    /// <summary>
    /// Mouse moved.
    /// </summary>
    MouseMotion = 0x400,

    /// <summary>
    /// Mouse button pressed.
    /// </summary>
    MouseButtonDown = 0x401,

    /// <summary>
    /// Mouse button released.
    /// </summary>
    MouseButtonUp = 0x402,

    /// <summary>
    /// Mouse wheel motion.
    /// </summary>
    MouseWheel = 0x403,

    /// <summary>
    /// A new mouse has been inserted to the system.
    /// </summary>
    MouseAdded = 0x404,

    /// <summary>
    /// A mouse has been removed from the system.
    /// </summary>
    MouseRemoved = 0x405,

    /// <summary>
    /// Joystick axis motion.
    /// </summary>
    JoystickAxisMotion = 0x600,

    /// <summary>
    /// Joystick trackball motion.
    /// </summary>
    JoystickBallMotion = 0x601,

    /// <summary>
    /// Joystick hat position change.
    /// </summary>
    JoystickHatMotion = 0x602,

    /// <summary>
    /// Joystick button pressed.
    /// </summary>
    JoystickButtonDown = 0x603,

    /// <summary>
    /// Joystick button released.
    /// </summary>
    JoystickButtonUp = 0x604,

    /// <summary>
    /// A new joystick has been inserted to the system.
    /// </summary>
    JoystickAdded = 0x605,

    /// <summary>
    /// An opened joystick has been removed from the system.
    /// </summary>
    JoystickRemoved = 0x606,

    /// <summary>
    /// Joystick battery level has changed.
    /// </summary>
    JoystickBatteryUpdated = 0x607,

    /// <summary>
    /// Joystick update is complete.
    /// </summary>
    JoystickUpdateComplete = 0x608,

    /// <summary>
    /// Gamepad axis motion.
    /// </summary>
    GamepadAxisMotion = 0x650,

    /// <summary>
    /// Gamepad button pressed.
    /// </summary>
    GamepadButtonDown = 0x651,

    /// <summary>
    /// Gamepad button released.
    /// </summary>
    GamepadButtonUp = 0x652,

    /// <summary>
    /// A new gamepad has been inserted to the system.
    /// </summary>
    GamepadAdded = 0x653,

    /// <summary>
    /// A gamepad has been removed from the system.
    /// </summary>
    GamepadRemoved = 0x654,

    /// <summary>
    /// Gamepad mapping has been updated.
    /// </summary>
    GamepadRemapped = 0x655,

    /// <summary>
    /// Gamepad touchpad touched.
    /// </summary>
    GamepadTouchpadDown = 0x656,

    /// <summary>
    /// Gamepad touchpad finger was moved.
    /// </summary>
    GamepadTouchpadMotion = 0x657,

    /// <summary>
    /// Gamepad touchpad finger was lifted.
    /// </summary>
    GamepadTouchpadUp = 0x658,

    /// <summary>
    /// Gamepad sensor was updated.
    /// </summary>
    GamepadSensorUpdate = 0x659,

    /// <summary>
    /// Gamepad update is complete.
    /// </summary>
    GamepadUpdateComplete = 0x65A,

    /// <summary>
    /// Gamepad Steam handle has changed.
    /// </summary>
    SteamHandleUpdated = 0x660,

    /// <summary>
    /// Finger was touched.
    /// </summary>
    FingerDown = 0x700,

    /// <summary>
    /// Finger was lifted.
    /// </summary>
    FingerUp = 0x701,

    /// <summary>
    /// Finger was moved.
    /// </summary>
    FingerMotion = 0x702,

    /// <summary>
    /// Finger touch was canceled.
    /// </summary>
    FingerCanceled = 0x703,

    /// <summary>
    /// The clipboard or primary selection changed.
    /// </summary>
    ClipboardUpdate = 0x900,

    /// <summary>
    /// The system requests a file open.
    /// </summary>
    DropFile = 0x1000,

    /// <summary>
    /// text/plain drag-and-drop event.
    /// </summary>
    DropText = 0x1001,

    /// <summary>
    /// A new set of drops is beginning.
    /// </summary>
    /// <remarks>
    /// The filename will be <see langword="null"/>.
    /// </remarks>
    DropBegin = 0x1002,

    /// <summary>
    /// Current set of drops is now complete.
    /// </summary>
    /// <remarks>
    /// The filename will be <see langword="null"/>.
    /// </remarks>
    DropComplete = 0x1003,

    /// <summary>
    /// Position while moving over the window.
    /// </summary>
    DropPosition = 0x1004,

    /// <summary>
    /// A new audio device is available.
    /// </summary>
    AudioDeviceAdded = 0x1100,

    /// <summary>
    /// An audio device has been removed.
    /// </summary>
    AudioDeviceRemoved = 0x1101,

    /// <summary>
    /// An audio device's format has been changed by the system.
    /// </summary>
    AudioDeviceFormatChanged = 0x1102,

    /// <summary>
    /// A sensor was updated.
    /// </summary>
    SensorUpdate = 0x1200,

    /// <summary>
    /// Pressure-sensitive pen has become available.
    /// </summary>
    PenProximityIn = 0x1300,

    /// <summary>
    /// Pressure-sensitive pen has become unavailable.
    /// </summary>
    PenProximityOut = 0x1301,

    /// <summary>
    /// Pressure-sensitive pen touched drawing surface.
    /// </summary>
    PenDown = 0x1302,

    /// <summary>
    /// Pressure-sensitive pen stopped touching drawing surface.
    /// </summary>
    PenUp = 0x1303,

    /// <summary>
    /// Pressure-sensitive pen button pressed.
    /// </summary>
    PenButtonDown = 0x1304,

    /// <summary>
    /// Pressure-sensitive pen button released.
    /// </summary>
    PenButtonUp = 0x1305,

    /// <summary>
    /// Pressure-sensitive pen is moving on the tablet.
    /// </summary>
    PenMotion = 0x1306,

    /// <summary>
    /// Pressure-sensitive pen angle/pressure/etc changed.
    /// </summary>
    PenAxis = 0x1307,

    /// <summary>
    /// A new camera device is available.
    /// </summary>
    CameraDeviceAdded = 0x1400,

    /// <summary>
    /// A camera device has been removed.
    /// </summary>
    CameraDeviceRemoved = 0x1401,

    /// <summary>
    /// A camera device has been approved for use by the user.
    /// </summary>
    CameraDeviceApproved = 0x1402,

    /// <summary>
    /// A camera device has been denied for use by the user.
    /// </summary>
    CameraDeviceDenied = 0x1403,

    /// <summary>
    /// The render targets have been reset and their contents need to be updated.
    /// </summary>
    RenderTargetsReset = 0x2000,

    /// <summary>
    /// The device has been reset and all textures need to be recreated.
    /// </summary>
    RenderDeviceReset = 0x2001,

    /// <summary>
    /// The device has been lost and can't be recovered.
    /// </summary>
    RenderDeviceLost = 0x2002,

    /// <summary>
    /// This last event is only for bounding internal arrays.
    /// </summary>
    LastEvent = 0xFFFF
}
