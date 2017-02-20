namespace FSharpProjectSystem

open System
open System.Collections.Generic
open System.ComponentModel.Composition
open System.Threading.Tasks
open Microsoft.VisualStudio.ProjectSystem
open Microsoft.VisualStudio.ProjectSystem.VS



module Providers = 
    ()


[<Export (ExportContractNames.Scopes.UnconfiguredProject, typeof<IProjectCapabilitiesProvider>)>]
[<AppliesTo (ProjectCapabilities.AlwaysApplicable)>]
type FSharpProjectCapabilitiesProvider () =
    
    member __.GetCapabilitiesAsync() = ()
