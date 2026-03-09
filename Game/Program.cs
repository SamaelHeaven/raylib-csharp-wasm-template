using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace Game;

internal static unsafe class Program
{
    // STAThread is required if you deploy using NativeAOT on Windows - See https://github.com/raylib-cs/raylib-cs/issues/301
    [STAThread]
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Hello World");

        if (OperatingSystem.IsBrowser())
        {
            Emscripten.SetMainLoop(&UnmanagedFrame, 0, 1);
        }
        else
        {
            while (!Raylib.WindowShouldClose())
            {
                Frame();
            }

            Raylib.CloseWindow();
        }
    }

    private static void Frame()
    {
        Raylib.BeginDrawing();
        {
            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
        }
        Raylib.EndDrawing();
    }
    
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void UnmanagedFrame()
    {
        Frame();
    }
}
