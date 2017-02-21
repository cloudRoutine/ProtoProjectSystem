open System.IO; Directory.SetCurrentDirectory __SOURCE_DIRECTORY__

let (^) = (<|)

let run cmd args = using (new System.Diagnostics.Process()) ^ fun proc -> 
    let pi, cmd = proc.StartInfo, Path.GetFullPath cmd
    pi.FileName <- cmd; pi.Arguments <- args; pi.UseShellExecute <- false
    ignore ^ proc.Start(); proc.WaitForExit(); printfn ""

run @"./.paket/paket.bootstrapper.exe" ""
run @"./.paket/paket.exe" "restore"

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

