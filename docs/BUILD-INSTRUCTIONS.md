# [Build Instructions](https://github.com/LateStartStudio/Hero6/blob/master/docs/BUILD-INSTRUCTIONS.md)

## Prerequisites

* [git](https://git-scm.com/)
* [git-lfs](https://git-lfs.github.com/)
* [.NET SDK (Windows)](https://dotnet.microsoft.com/download/visual-studio-sdks) or [Mono (*nix)](https://www.mono-project.com/)¹
* [.NET Core SDK v2.2.100](https://dotnet.microsoft.com/download/dotnet-core/2.2)

¹ We hope this prerequisite will not be needed in the future, but we rely on 3rd party frameworks to upgrade their tools for this to happen.

## Instructions

### 1. Clone the project

If you have git and git-lfs installed and configured, simply cloning the project should be enough.

`git clone --recurse-submodules https://github.com/LateStartStudio/Hero6`

### 2. Pre-build the MonoGame Pipeline extension

When using the dotnet CLI and building the source code we have to build this project first because we have difficulties making the dotnet CLI respect the build order. If someone knows a fix for his it would be appreciated.

`dotnet build ./src/Hero6.MonoGamePipeline/Hero6.MonoGamePipeline.csproj`

### 3. Building, running, etc. the game

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
