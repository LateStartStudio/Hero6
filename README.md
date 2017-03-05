# [Hero6 Readme](https://github.com/LateStartStudio/Hero6/blob/master/README.md)
Welcome to the Hero6 project. This readme should be included in your copy of Hero6, it is also available in the [source code repository](https://github.com/LateStartStudio/Hero6). The Hero6 project started in 1999, the project was shut down and the game files released to public in 2011, until it was rebooted by a new team in 2013.

* [Links](https://github.com/LateStartStudio/Hero6/blob/master/README.md#links)
* [Sponsors](https://github.com/LateStartStudio/Hero6/blob/master/README.md#sponsors)
* [Build](https://github.com/LateStartStudio/Hero6#build)
* [Contribution](https://github.com/LateStartStudio/Hero6#contribution)
* [Changelog](https://github.com/LateStartStudio/Hero6/blob/master/README.md#links)
* [License](https://github.com/LateStartStudio/Hero6/blob/master/README.md#links)

## Links
* [Homepage](http://www.hero6.org/)
* [Facebook](https://www.facebook.com/hero6)
* [Twitter](https://twitter.com/LateStartStudio)
* [Google+](https://plus.google.com/113761218770982404275/posts)
* [Developer Forum](http://hero6.org/forum/index.php?sid=14b99a3ea3beb965dae84d1ce6dd50d8)
* [GitHub - Development](https://github.com/LateStartStudio/Hero6)
* [Sourceforge - Game Download](http://sourceforge.net/projects/hero6/)

## Sponsors

### Advanced Installer
The Windows Installer is made with [Advanced Installer](http://www.advancedinstaller.com/) on an open source license. Advanced Installer allowed us to create a feature complete installer in a user friendly environment with minimal effort.

## Build

### Build Status

#### Official Builds
||Debug|Release|
|:---|:---:|:---:|
|**master**| - | - |
|Windows (DirectX)|![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/11/badge)|![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/12/badge)|
|Windows (OpenGL)|![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/9/badge)|![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/10/badge)|
|**v0.1.0**| - | - |
|Windows (DirectX)|![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/7/badge)|![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/4/badge)|
|Windows (OpenGL)|![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/6/badge)|![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/3/badge)|
[//]: # "* Android Release: "
[//]: # "![](https://hero6.visualstudio.com/_apis/public/build/definitions/f4557623-2016-4a6b-821d-942e8a1b7e6e/5/badge)"
[//]: # "Android Release is disabled until we decide to focus on Android development"

#### Experimental Builds
||Debug|Release|
|:---|:---:|:---:|
|**master**| - | - |
|Ubuntu 12.04.5 LTS and OS X 10.11.6 El Capitan|![](https://api.travis-ci.org/LateStartStudio/Hero6.svg?branch=master)| Same as Debug|
|**v0.1.0**| - | - |
|Ubuntu 12.04.5 LTS and OS X 10.11.6 El Capitan|![](https://api.travis-ci.org/LateStartStudio/Hero6.svg?branch=v0.1.0)| Same as Debug|

### Build Instructions
Ideally, we want anyone to be able to build Hero6 on any OS with any IDE. This is an ongoing task and we continue our efforts to make that possible. Currently, we can guarantee that it will work on Windows with Visual Studio 2015.

#### Windows
##### Prerequisites

* To clone the repo you will need [git](https://git-for-windows.github.io/), if you prefer a GUI layout we recommend [Git Extensions](https://gitextensions.github.io/) or [TortoiseGit](https://tortoisegit.org/), your preferred IDE may also have git support. You will also need [git-lfs](https://git-lfs.github.com/) as we use this to store assets like graphics and audio.
  * If you do not have git-lfs installed you will still be able to clone the repo, but all assets will be corrupt. You can verify if you have it installed with the command `git lfs`
* To build you will need an IDE with [MonoGame v3.5](http://www.monogame.net/2016/03/17/monogame-3-5/) installed. Typically, this will be Visual Studio, but you could also use [MonoDevelop/Xamarin Studio](http://www.monodevelop.com/download/). Refer to the MonoGame web pages on how to set up MonoGame with your IDE.
  * We have setup MonoGame in our repository using donwloadable packages, however it is important that you also install MonoGame standalone as it provides the "MonoGame Pipeline" tool.  This tool is required to build assets in a format compatible across platforms.
  * If you are not a dedicated coder or contributor to the Hero6 project and want to check out the bleeding-edge builds, you will most likely prefer MonoDevelop/Xamarin Studio. While the Visual Studio IDE takes hours to install and requires several GBs of your disk, Xamarin Studio installs in a few minutes and requires approximately 100+ MBs.
  * [Rider EAP](https://www.jetbrains.com/rider/) has been tested and works with Hero6. However, we will not maintain this compatibility until Rider receives a public release and its conditions for use are well defined.
  * If you want to run our unit tests and are also using Visual Studio you will need the [NUnit3 Test Adapter](https://visualstudiogallery.msdn.microsoft.com/0da0f6bd-9bb6-4ae3-87a8-537788622f2d).
  * If you want to build the Windows installer you will need [Advanced Installer](http://www.advancedinstaller.com/) with a professional License, they also offer [Visual Studio Extensions](http://www.advancedinstaller.com/visual-studio-extension.html).

##### Instructions

1. [Fork the project](https://github.com/LateStartStudio/Hero6).
2. Clone the source `git clone https://github.com/YourHero6Repository/Hero6.git`.
3. You will need to obtain packages of 3rd party frameworks.
  1. Navigate into the directory ".paket".
  2. Run the command `paket.bootstrapper`. This will download the most recent and stable version of [Paket](https://fsprojects.github.io/Paket/index.html) to the same directory.
  3. Run the command `paket restore`. In the root directory of your local repository you should now have a new folder "packages".
4. Open "Hero6.sln" with the IDE of your choice.
5. Set the build configuration to the platform you want to work with. We have individual Debug and Release configurations for each platform.
  * The default "Debug" and "Release" refers to the Hero6.DesktopGL project.
  * "WindowsDX Debug" and "WindowsDX Release" refers to the Hero6.WindowsDX project.
  * "Android Debug" and "Android Release" refers to the Hero6.Android project.
6. Set startup project to the project that corresponds with your configuration, "Hero6.Android", "Hero6.DesktopGL" or "Hero6.WindowsDX".
7. Build.
8. Run.

#### Linux and OS X
Theoretically, you should be able to build and run Hero6 on Linux and OS X, but this is not something we maintain right now, and we do not intend to do this until we have a working CI build server in place.

### Supported Platforms
* Windows (DirectX)
  * Requires a minimum of Windows Vista SP 2.
  * [Requires Microsoft .NET Framework 4.5.](https://www.microsoft.com/en-us/download/details.aspx?id=30653)
  * [Requires DirectX 9.0c.](https://www.microsoft.com/en-us/download/details.aspx?id=34429)
* Windows (OpenGL)
  * Requires a minimum of Windows Vista SP 2.
  * [Requires Microsoft .NET Framework 4.5.](https://www.microsoft.com/en-us/download/details.aspx?id=30653)

Theoretically the OpenGL Windows build should also work with Linux and OS X, but this goes unsupported and unmaintained for now. We also have a build configuration for Android but we do not maintain it.

## Contribution
If you find a bug, want to suggest a new feature, or just suggest general ideas for improvement, please do so in our [bug tracker](https://github.com/LateStartStudio/Hero6/issues).

If you have any general questions that are non development related about Hero6 you can reach us on our [forums](http://www.hero6.org/forum/), or [IM](http://www.hero6.org/?page_id=84). We're also available on [Facebook](https://www.facebook.com/hero6) and [Twitter](https://twitter.com/LateStartStudio).

## Changelog
A changelog listing what is new and happening for each version release is at [CHANGELOG.md](https://github.com/LateStartStudio/Hero6/blob/master/docs/CHANGELOG.md).

## License
Licensing details are available at [LICENSE.md](https://github.com/LateStartStudio/Hero6/blob/master/docs/LICENSE.md).
