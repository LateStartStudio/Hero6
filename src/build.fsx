// Includes
#r @"packages/FAKE/tools/FakeLib.dll"

open System
open Fake
open Fake.Testing.NUnit3

type OS = | OSX | Windows | Linux

let getOS =
        match int Environment.OSVersion.Platform with
        | 4 | 128 -> Linux
        | 6       -> OSX
        | _       -> Windows

// Properties
let buildDesktopGLDebugConfig = "Debug"
let buildDesktopGLReleaseConfig = "Release"
let buildWindowsDXDebugConfig = "WindowsDX Debug"
let buildWindowsDXReleaseConfig = "WindowsDX Release"
let buildAndroidDebugConfig = "Android Debug"
let buildeAndroidReleasConfig = "Android Release"

let buildDesktopGLDebugDir = "../bin/DesktopGL/Debug/"
let buildDesktopGLReleaseDir = "../bin/DesktopGL/Release/"
let buildWindowsDXDebugDir = "../bin/WindowsDX/Debug/"
let buildWindowsDXReleaseDir = "../bin/WindowsDX/Release/"
let buildAndroidDebugDir = "../bin/Android/Debug/"
let buildAndroidReleaseDir = "../bin/Android/Release/"

let solutionFile = if getOS = Windows then "./Hero6.Windows.sln" else "./Hero6.Linux.sln"

let isGpuAvailable = not (getEnvironmentVarAsBool "TRAVIS" || getEnvironmentVarAsBool "APPVEYOR")

let build dir config =
    !! solutionFile
    |> MSBuild dir "Build"
        [
            "Configuration", config
        ]
    |> Log ("Her6 Build " + config + " Configuration Output: ")

let testFile dir file =
    !! (dir + file)
    |> NUnit3 (fun p ->
    { p with
        ToolPath = "packages/NUnit.ConsoleRunner/tools/nunit3-console.exe"
    })

let testBuild dir =
    testFile dir "Collections.Tests.dll"
    testFile dir "Search.Tests.dll"
    if isGpuAvailable then
        testFile dir "Hero6.Tests.dll"

// Targets - Clean
Target "Clean DesktopGL Debug" (fun _ ->
    CleanDir buildDesktopGLDebugDir
)

Target "Clean DesktopGL Release" (fun _ ->
    CleanDir buildDesktopGLReleaseDir
)

Target "Clean WindowsDX Debug" (fun _ ->
    if getOS = Windows then
        CleanDir buildWindowsDXDebugDir
    else
        trace "Skipping Clean - WindowsDX is only supported on Windows"
)

Target "Clean WindowsDX Release" (fun _ ->
    if getOS = Windows then
        CleanDir buildWindowsDXReleaseDir
    else
        trace "Skipping Clean - WindowsDX is only supported on Windows"
)

Target "Clean Android Debug" (fun _ ->
    if getOS = Windows then
        CleanDir buildAndroidDebugDir
    else
        trace "Skipping Clean - Android is only supported on Windows"
)

Target "Clean Android Release" (fun _ ->
    if getOS = Windows then
        CleanDir buildAndroidReleaseDir
    else
        trace "Skipping Clean - Android is only supported on Windows"
)

// Targets - Build
Target "Build DesktopGL Debug" (fun _ ->
    build buildDesktopGLDebugDir buildDesktopGLDebugConfig
)

Target "Build DesktopGL Release" (fun _ ->
    build buildDesktopGLReleaseDir buildDesktopGLReleaseConfig
)

Target "Build WindowsDX Debug" (fun _ ->
    if getOS = Windows then
        build buildWindowsDXDebugDir buildWindowsDXDebugConfig
    else
        trace "Skipping Build - WindowsDX is only supported on Windows"
)

Target "Build WindowsDX Release" (fun _ ->
    if getOS = Windows then
        build buildWindowsDXReleaseDir buildWindowsDXReleaseConfig
    else
        trace "Skipping Build - WindowsDX is only supported on Windows"
)

Target "Build Android Debug" (fun _ ->
    if getOS = Windows then
        build buildAndroidDebugDir buildAndroidDebugConfig
    else
        trace "Skipping Build - Android is only supported on Windows"
)

Target "Build Android Release" (fun _ ->
    if getOS = Windows then
        build buildAndroidReleaseDir buildeAndroidReleasConfig
    else
        trace "Skipping Build - Android is only supported on Windows"
)

// Targets - Test
Target "Test DesktopGL Debug" (fun _ ->
    testBuild buildDesktopGLDebugDir
)

Target "Test DesktopGL Release" (fun _ ->
    testBuild buildDesktopGLDebugDir
)

Target "Test WindowsDX Debug" (fun _ ->
    if getOS = Windows then
        testBuild buildWindowsDXDebugDir
    else
        trace "Skipping Test - WindowsDX is only supported on Windows"
)

Target "Test WindowsDX Release" (fun _ ->
    if getOS = Windows then
        testBuild buildWindowsDXReleaseDir
    else
        trace "Skipping Test - WindowsDX is only supported on Windows"
)

Target "Test Android Debug" (fun _ ->
    trace "Skipping Test - Not supported on config Android"
)

Target "Test Android Release" (fun _ ->
    trace "Skipping Test - Not supported on config Android"
)

// Single Configurations
Target "DesktopGL Debug" (fun _ ->
    trace "Completed DesktopGL Debug Build"
)

Target "DesktopGL Release" (fun _ ->
    trace "Completed DesktopGL Release Build"
)

Target "WindowsDX Debug" (fun _ ->
    trace "Completed WindowsDX Debug Build"
)

Target "WindowsDX Release" (fun _ ->
    trace "Completed WindowsDX Release Build"
)

Target "Android Debug" (fun _ ->
    trace "Completed Android Debug Build"
)

Target "Android Release" (fun _ ->
    trace "Completed Android Release Build"
)

Target "Default Windows" (fun _ ->
    trace "Completed Hero6 Build"
)

Target "Default Linux" (fun _ ->
    trace "Completed Hero6 Build"
)

// Dependencies - DesktopGL Debug
"Clean DesktopGL Debug"
    ==> "Build DesktopGL Debug"
    ==> "Test DesktopGL Debug"
    ==> "DesktopGL Debug"

// Dependencies - DesktopGL Release
"Clean DesktopGL Release"
    ==> "Build DesktopGL Release"
    ==> "Test DesktopGL Release"
    ==> "DesktopGL Release"

// Dependencies - WindowsDX Debug
"Clean WindowsDX Debug"
    ==> "Build WindowsDX Debug"
    ==> "Test WindowsDX Debug"
    ==> "WindowsDX Debug"

// Dependencies - WindowsDX Release
"Clean WindowsDX Release"
    ==> "Build WindowsDX Release"
    ==> "Test WindowsDX Release"
    ==> "WindowsDX Release"

// Dependencies - Android Debug
"Clean Android Debug"
    ==> "Build Android Debug"
    ==> "Test Android Debug"
    ==> "Android Debug"

// Dependencies - Android Release
"Clean Android Release"
    ==> "Build Android Release"
    ==> "Test Android Release"
    ==> "Android Release"

// Dependencies - Windows Developer Environment
"DesktopGL Debug"
    ==> "Default Windows"

"DesktopGL Release"
    ==> "Default Windows"

"WindowsDX Debug"
    ==> "Default Windows"

"WindowsDX Release"
    ==> "Default Windows"

"Android Debug"
    ==> "Default Windows"

"Android Release"
    ==> "Default Windows"

// Dependencies - Linux Developer Environment
"DesktopGL Debug"
    ==> "Default Linux"

"DesktopGL Release"
    ==> "Default Linux"

// Start Build
if getOS = Windows then
    RunTargetOrDefault "Default Windows"
else
    RunTargetOrDefault "Default Linux"
