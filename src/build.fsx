// Includes
#r @"packages/FAKE/tools/FakeLib.dll"

open System
open System.IO
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

let solutionFile = "Hero6.sln"

let clean =
    for i in Directory.GetDirectories("./") do
        for j in Directory.GetDirectories(i, "bin") do
            CleanDir(j)
        for j in Directory.GetDirectories(i, "obj") do
            CleanDir(j)

let build config =
    !! solutionFile
    |> MSBuild "" "Build"
        [
            "Configuration", config
        ]
    |> Log ("Her6 Build " + config + " Configuration Output: ")

let test configDir =
    let mutable testCount = false

    for i in Directory.GetDirectories "./" do
        let dir = i + "/bin/" + configDir + "/"

        if Directory.Exists dir then
            for j in Directory.GetFiles(dir, "./*.Tests.dll") do
                trace j
                !! (j)
                |> NUnit3 (fun p ->
                { p with
                    ToolPath = "packages/NUnit.ConsoleRunner/tools/nunit3-console.exe"
                })

                testCount <- true

    if not testCount then
        raise (System.ArgumentException("No test assemblies found!! Have you configured your paths correctly?"))

Target "Clean DesktopGL Debug" (fun _ ->
    clean
)

Target "Clean DesktopGL Release" (fun _ ->
    clean
)

Target "Clean WindowsDX Debug" (fun _ ->
    clean
)

Target "Clean WindowsDX Release" (fun _ ->
    clean
)

Target "Clean Android Debug" (fun _ ->
    clean
)

Target "Clean Android Release" (fun _ ->
    clean
)

// Targets - Build
Target "Build DesktopGL Debug" (fun _ ->
    build buildDesktopGLDebugConfig
)

Target "Build DesktopGL Release" (fun _ ->
    build buildDesktopGLReleaseConfig
)

Target "Build WindowsDX Debug" (fun _ ->
    if getOS = Windows then
        build buildWindowsDXDebugConfig
    else
        trace "Skipping Build - WindowsDX is only supported on Windows"
)

Target "Build WindowsDX Release" (fun _ ->
    if getOS = Windows then
        build buildWindowsDXReleaseConfig
    else
        trace "Skipping Build - WindowsDX is only supported on Windows"
)

Target "Build Android Debug" (fun _ ->
    if getOS = Windows then
        build buildAndroidDebugConfig
    else
        trace "Skipping Build - Android is only supported on Windows"
)

Target "Build Android Release" (fun _ ->
    if getOS = Windows then
        build buildeAndroidReleasConfig
    else
        trace "Skipping Build - Android is only supported on Windows"
)

// Targets - Test
Target "Test DesktopGL Debug" (fun _ ->
    test "Debug"
)

Target "Test DesktopGL Release" (fun _ ->
    test "Release"
)

Target "Test WindowsDX Debug" (fun _ ->
    if getOS = Windows then
        test "Debug"
    else
        trace "Skipping Test - WindowsDX is only supported on Windows"
)

Target "Test WindowsDX Release" (fun _ ->
    if getOS = Windows then
        test "Release"
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

// Android is not supported or maintained so it is commented out for now
// "Android Debug"
//     ==> "Default Windows"

// "Android Release"
//     ==> "Default Windows"

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
