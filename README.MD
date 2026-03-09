# raylib C# WASM Template

Starter template for building a `raylib-cs` game with .NET NativeAOT for WebAssembly (`browser-wasm`).

## Prerequisites

- .NET SDK
- Emscripten SDK (`emsdk`) installed on the machine

## Toolchain + emsdk setup

This template targets `browser-wasm` using the runtimelab NativeAOT LLVM toolchain, so you need Emscripten tools available locally.

More NativeAOT toolchain documentation:

- [Using Native AOT](https://github.com/dotnet/runtimelab/blob/feature/NativeAOT-LLVM/docs/using-nativeaot/README.md)

Reference from .NET runtimelab NativeAOT-LLVM branch:

- [install-emscripten.ps1](https://github.com/dotnet/runtimelab/blob/feature/NativeAOT-LLVM/eng/pipelines/runtimelab/install-emscripten.ps1)

The runtimelab script pins a known-good commit and installs/activates `3.1.56`. You can do the equivalent manually:

```powershell
git clone https://github.com/emscripten-core/emsdk.git
cd emsdk
git checkout ca7b40ae222a2d8763b6ac845388744b0e57cfb7
.\emsdk install 3.1.56
.\emsdk activate 3.1.56
```

After activation, ensure the Emscripten environment variables are available in your terminal session (or system/user environment if you want persistence between sessions).

## Project configuration

If you need to adjust NativeAOT/WASM settings, linker args, or package references, edit:

- [`Game/Game.csproj`](./Game/Game.csproj)

This file already contains the `browser-wasm` conditional block and LLVM-related package references.

## Build and publish for WebAssembly

Run commands from the repository root:

### Debug WASM publish

```powershell
dotnet publish -r browser-wasm -c Debug
```

### Release WASM publish

```powershell
dotnet publish -r browser-wasm -c Release
```

### Test the published build locally

```powershell
cd .\Game\bin\Release\net10.0\browser-wasm\publish\
python -m http.server 8000
```

## Notes

- Game entry point: [`Game/Program.cs`](./Game/Program.cs)
- Make sure `emsdk` is installed and activated before publishing for `browser-wasm`.
- When switching from web builds to desktop builds, run `dotnet restore` before building.
- Output is written under the project `bin`/`publish` folders for the selected configuration/runtime.
