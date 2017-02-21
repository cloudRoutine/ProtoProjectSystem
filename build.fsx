open System.IO; Directory.SetCurrentDirectory __SOURCE_DIRECTORY__

let (^) = (<|)

using (new System.Diagnostics.Process()) ^ fun proc -> 
    proc.StartInfo.FileName <- Path.GetFullPath @"./.paket/paket.bootstrapper.exe"
    proc.StartInfo.UseShellExecute <- false
    ignore ^ proc.Start(); proc.WaitForExit(); printfn ""

#r @"./.paket/paket.exe" 
open Paket
open Paket.Logging

let dependencies = "./paket.dependencies"

using (event.Publish |> Observable.subscribe traceToConsole) ^ fun _ -> 
    try tracefn "Paket restoring packages from - '%s'" ^ Path.GetFullPath dependencies
        Dependencies.Locate("./paket.dependencies").Restore(false)
        tracefn "Package Restoration Complete\n"
    with exn -> traceErrorfn "Package Restoration Failed -\n%s" exn.Message

#r @"packages/FAKE/tools/FakeLib.dll"; open Fake 

let solutionFile = "ProtoProjectSystem.sln"

Target "Clean" ^ fun _ ->
    CleanDirs ["bin"; "temp"]

Target "Build" ^ fun _ ->
    tracefn "Building all projects in '%s'" solutionFile
    !! solutionFile
    |> MSBuildRelease "" "Rebuild"
    |> ignore

"Clean" ==> "Build"

match fsi.CommandLineArgs.Length with
| 1  -> RunTargetOrDefault "Build"
| _  -> RunTargetOrDefault fsi.CommandLineArgs.[1]

