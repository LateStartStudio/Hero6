# [Build Instructions](https://github.com/LateStartStudio/Hero6/blob/master/docs/BUILD-INSTRUCTIONS.md)

## Prerequisites

* [git](https://git-scm.com/)
* [git-lfs](https://git-lfs.github.com/)
* [.NET SDK (Windows)](https://dotnet.microsoft.com/download/visual-studio-sdks) or [Mono (*nix)](https://www.mono-project.com/)¹
* [.NET Core SDK v2.2.100](https://dotnet.microsoft.com/download/dotnet-core/2.2)

¹ We hope this prerequisite will not be needed in the future, but we rely on 3rd party frameworks to upgrade their tools for this to happen.

## Instructions

### Clone the project

If you have git and git-lfs installed and configured, simply cloning the project should be enough.

`git clone --recurse-submodules https://github.com/LateStartStudio/Hero6`

### Pre-build MonoGame Pipeline extension

Because of incompatabilities with the old .NET and .NET core(building old .NET code with the dotnet CLI on *nix systems isn't supported) so we have to pre-build the MonoGame Pipeline extensions to build our assets successfully. We hope this inconvenience is gone in the future.

It should only be necessary to do this step once unless you modify the MonoGame Pipeline extensions source.

#### Windows

`dotnet build ./src/Hero6.MonoGamePipeline.sln`

#### *nix systems

1. `msbuild ./src/Hero6.MonoGamePipeline.sln /t:restore`
2. `msbuild ./src/Hero6.MonoGamePipeline.sln`

### Building, running, etc. the game

Hero6 is built using standard [dotnet CLI commands](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x).

#### Run game

`dotnet run --project ./src/Hero6.DesktopGL/Hero6.DesktopGL.csproj`

#### Run unit tests

`dotnet test ./src/Hero6.sln`

## Other things to know

### .editorconfig

Make sure your IDE/text editor is compatible with [.editorconfig](https://editorconfig.org/) to make sure you're using the same text editor rules as everyone else contributing.

### Editing nuget packages

We use [Paket](https://fsprojects.github.io/Paket/) for nuget packages.

### Editing MonoGame Content project

If you want to edit the MonoGame Content project you'll need the CLI or GUI tools from the [MonoGame SDK v3.7](http://community.monogame.net/t/monogame-3-7-release/10971)

### Unit test coverage

If you want to see unit test coverage run the script `./src/coverage.sh`, it will generate reports, to see open `./src/.coverage/html/index.html`.
