namespace FSharpProjectSystem

open Microsoft.VisualStudio.ProjectSystem

module Capabilities =

    let [<Literal>] fsproj = "fsproj"


    let projectSytem = 
        Empty.CapabilitiesSet.Union 
            [   ProjectCapabilities.Cps
                ProjectCapabilities.AssemblyReferences
                ProjectCapabilities.SdkReferences
                ProjectCapabilities.ProjectReferences
                ProjectCapabilities.HostSetActiveProjectConfiguration
                ProjectCapabilities.Managed
                ProjectCapabilities.LanguageService
            ]

    /// AssemblyReferences
    let [<Literal>] AssemblyReferences = "AssemblyReferences"

    /// ProjectReferences
    let [<Literal>] ProjectReferences = "ProjectReferences"

    /// CPS
    let [<Literal>] CPS = "CPS"

    /// Managed
    let [<Literal>] Managed = "Managed"

    /// SDKReferences
    let [<Literal>] SdkReferences = "SDKReferences"

(*
        public const string AllTargetOutputGroups = "AllTargetOutputGroups";
        //
        // Summary:
        //     The empty string, because project capability expressions that are empty evaluate
        //     to true.
        public const string AlwaysApplicable = "";
        //
        // Summary:
        //     Expressed on parts applicable to projects that support assembly references.
        public const string AssemblyReferences = "AssemblyReferences";
        //
        // Summary:
        //     A capability present in projects that produce all or part of an application that
        //     can be both: 1. launched using Win32 CreateProcess, and 2. debugged using a standard
        //     Visual Studio debug engine.
        public const string BuildWindowsDesktopTarget = "BuildWindowsDesktopTarget";
        //
        // Summary:
        //     Expressed on parts applicable to projects that support COM references.
        public const string ComReferences = "COMReferences";
        //
        // Summary:
        //     Expressed on parts applicable to any pure-CPS project type.
        public const string Cps = "CPS";
        //
        // Summary:
        //     Expressed on parts applicable to any C# project.
        public const string CSharp = "CSharp";
        //
        // Summary:
        //     Present when the project is loaded in the context of a host process that has
        //     a concept of active project configurations.
        public const string HostSetActiveProjectConfiguration = "HostSetActiveProjectConfiguration";
        //
        // Summary:
        //     Present to activate the language service.
        public const string LanguageService = "LanguageService";
        //
        // Summary:
        //     A project capability expressed by projects that compile to MSIL (e.g. C#, VB,
        //     F#, and Managed C++ or C++/CLI).
        public const string Managed = "Managed";
        //
        // Summary:
        //     Expressed on parts that provide services for nested projects.
        public const string NestedProjects = "NestedProjects";
        //
        // Summary:
        //     A capability defined when a project is loaded without integration with the IDE.
        //     Examples include .filters file and platform projects internally used by the project
        //     system.
        public const string NotLoadedWithIDEIntegration = "NotLoadedWithIDEIntegration";
        //
        // Summary:
        //     Activates the overall output groups support in a project system.
        public const string OutputGroups = "OutputGroups";
        //
        // Summary:
        //     Present to activate support for VC codesharing parent project.
        public const string ParentVCProject = "ParentVCProject";
        //
        // Summary:
        //     Present when a project explicitly declares its own project configurations as
        //     ProjectConfiguration msbuild items.
        //
        // Remarks:
        //     This capability tends to be used for C++/JS.
        public const string ProjectConfigurationsDeclaredAsItems = "ProjectConfigurationsDeclaredAsItems";
        //
        // Summary:
        //     Present when a project does not explicitly declare its own project configurations,
        //     but rather expects the project system to infer what they are based on MSBuild
        //     element Condition attributes that appear in the project.
        //
        // Remarks:
        //     This capability tends to be used for C#/VB.
        public const string ProjectConfigurationsInferredFromUsage = "ProjectConfigurationsInferredFromUsage";
        //
        // Summary:
        //     Expressed on parts applicable to projects that support project references.
        public const string ProjectReferences = "ProjectReferences";
        //
        // Summary:
        //     Expressed on parts that provide the special References folder.
        public const string ReferencesFolder = "ReferencesFolder";
        //
        // Summary:
        //     Present to activate tracking folder names in namespace (i.e. RootNamespace.Folder1.Folder2).
        public const string RelativePathDerivedDefaultNamespace = "RelativePathDerivedDefaultNamespace";
        //
        // Summary:
        //     A capability that opts a project into automatically having its imported files
        //     renamed with the project.
        //
        // Remarks:
        //     For example, if a.proj imports a.proj.user and a.proj is renamed to b.proj, then
        //     a.proj.user should be renamed to b.proj.user.
        public const string RenameNearbySimilarlyNamedImportsWithProject = "RenameNearbySimilarlyNamedImportsWithProject";
        //
        // Summary:
        //     Present when the CPS-VS MEF components are available.
        //
        // Remarks:
        //     This project capability is here to help VC adjust to turning off stable composition
        //     by forcing parts that would be rejected to be removed from the MEF catalog. It
        //     is not intended for general purpose consumption.
        public const string RunningInVisualStudio = "RunningInVisualStudio";
        //
        // Summary:
        //     Expressed on parts applicable to projects that support SDK references.
        public const string SdkReferences = "SDKReferences";
        //
        // Summary:
        //     Expressed on parts that provide services for Code Sharing projects (i.e. Mercury
        //     master projects).
        public const string SharedAssetsProject = "SharedAssetsProject";
        //
        // Summary:
        //     Expressed on parts that provide services for projects that contain imports of
        //     MSBuild files that may be imported by other projects.
        public const string SharedImports = "SharedImports";
        //
        // Summary:
        //     Expressed on parts applicable to projects that support shared project references.
        public const string SharedProjectReferences = "SharedProjectReferences";
        //
        // Summary:
        //     Present to activate support for single file generators (aka custom tools that
        //     execute at design-time).
        public const string SingleFileGenerators = "SingleFileGenerators";
        //
        // Summary:
        //     Indicates that source items should be presented in the UI even if they appear
        //     in imported files (as opposed to the project manifest itself).
        public const string SourceItemsFromImports = "SourceItemsFromImports";
        //
        // Summary:
        //     Expressed on parts applicable to any Visual Basic .NET project.
        public const string VB = "VB";
        //
        // Summary:
        //     Expressed on parts applicable to any Visual C++ project.
        public const string VisualC = "VisualC";
        //
        // Summary:
        //     Activates auto-detection of targets supporting well-known output groups.
        public const string VisualStudioWellKnownOutputGroups = "VisualStudioWellKnownOutputGroups";
        //
        // Summary:
        //     A project capability defined on a project that supports Windows Xaml (not WPF)
        //     as a UI framework.
        public const string WindowsXaml = "WindowsXaml";
        //
        // Summary:
        //     A project capability defined on a project that supports Windows Xaml (not WPF)
        //     code-behinds.
        public const string WindowsXamlCodeBehind = "WindowsXamlCodeBehind";
        //
        // Summary:
        //     A project capability defined on a project that supports Windows Xaml (not WPF)
        //     as a UI framework for pages.
        public const string WindowsXamlPage = "WindowsXamlPage";
        //
        // Summary:
        //     A project capability defined on a project that supports Windows Xaml (not WPF)
        //     for resource dictionaries.
        public const string WindowsXamlResourceDictionary = "WindowsXamlResourceDictionary";
        //
        // Summary:
        //     A project capability defined on a project that supports Windows Xaml (not WPF)
        //     as a UI framework for user controls.
        public const string WindowsXamlUserControl = "WindowsXamlUserControl";
        //
        // Summary:
        //     Expressed on parts applicable to projects that support WinRT references.
        public const string WinRTReferences = "WinRTReferences";

        //
        // Summary:
        //     Checks whether a given project capability name is valid.
        //
        // Parameters:
        //   projectCapability:
        //     The project capability to validate.
        //
        // Returns:
        //     true if the project capability is valid; otherwise false.
        public static bool IsValidProjectCapabilityName ( string projectCapability );
    }

*)
