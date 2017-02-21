namespace FSharpProjectSystem

open System

open System.ComponentModel.Composition
open Microsoft.VisualStudio.ProjectSystem
open Microsoft.VisualStudio.ProjectSystem.Properties
open System.Diagnostics.CodeAnalysis
open FSharpProjectSystem.Capabilities


//type FSharpProjectProperties [<ImportingConstructor>] (configuredProject:ConfiguredProject) =
[<Export>]
[<AppliesTo(Capabilities.fsproj)>]
type FSharpProjectProperties =
    inherit StronglyTypedPropertyAccess

    [<ImportingConstructor>] 
    new  (configuredProject:ConfiguredProject) =
        { inherit StronglyTypedPropertyAccess(configuredProject) }
    
    new (configuredProject:ConfiguredProject,file:string,itemType:string,itemName:string) =
        { inherit StronglyTypedPropertyAccess (configuredProject, file,itemType,itemName) }

    new (configuredProject:ConfiguredProject,projectPropertiesContext:IProjectPropertiesContext) =
        { inherit StronglyTypedPropertyAccess(configuredProject,projectPropertiesContext) }

    new (configuredProject:ConfiguredProject,unconfiguredProject:UnconfiguredProject) =
        { inherit StronglyTypedPropertyAccess(configuredProject,unconfiguredProject) }


[<Export>]
[<AppliesTo(Capabilities.fsproj)>]    
type FSharpConfiguredProject [<ImportingConstructor>] ( configuredProject:ConfiguredProject,properties:FSharpProjectProperties) =
    
    [<SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "MEF")>]
    member __.ConfiguredProject = configuredProject
    
    [<SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "MEF")>]
    member __.Properties = lazy properties



[<Export>]
[<AppliesTo(Capabilities.fsproj)>]
type FSharpUnconfiguredProject [<ImportingConstructor>]
    (   unconfiguredProject:UnconfiguredProject
    ,   fsharpActiveConfiguredProject:FSharpConfiguredProject
    ,   activeConfiguredProject:ConfiguredProject) =

    member __.UnconfiguredProject = unconfiguredProject


