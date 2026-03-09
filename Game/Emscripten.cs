using System.Runtime.InteropServices;

namespace Game;

internal static unsafe partial class Emscripten
{
    public const string LibraryName = "libc";

    [LibraryImport(LibraryName, EntryPoint = "emscripten_set_main_loop")]
    public static partial void SetMainLoop(delegate* unmanaged[Cdecl]<void> func, int fps, sbyte simulateInfiniteLoop);
}
