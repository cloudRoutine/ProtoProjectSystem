namespace FSharpProjectSystem


open System
open System.Reflection
open System.Threading
open System.Threading.Tasks
open System.Diagnostics
open Microsoft.VisualStudio
open Microsoft.VisualStudio.Shell
open Microsoft.VisualStudio.ProjectSystem


type DebuggerTraceListener () =
    inherit TraceListener()

    override __.Write(message:string) =
        if Debugger.IsLogging() then Debugger.Log(0,null,message)

    override self.WriteLine(message:string) = 
        self.Write (message + Environment.NewLine)


///     Registers a trace listener to the CPS trace source that writes to the debugger.
[<PackageRegistration(AllowsBackgroundLoading = true, RegisterUsing = RegistrationMethod.CodeBase, UseManagedResourcesOnly = true)>]
[<ProvideAutoLoad(VSConstants.UICONTEXT.SolutionExists_string, PackageAutoLoadFlags.BackgroundLoad)>]
type FSharpProjectSystemPackage () = 
    inherit AsyncPackage()

    member __.RegisterTraceListener () =
        let assemblyName = (typeof<AppliesToAttribute>).Assembly.FullName
        let traceType = Type.GetType<| sprintf "Microsoft.VisualStudio.ProjectSystem.TraceUtilities, %s" assemblyName
        let fieldInfo = traceType.GetField("Source", BindingFlags.NonPublic ||| BindingFlags.Static)
        let source = fieldInfo.GetValue(null) :?> TraceSource
        source.Switch.Level <- SourceLevels.Warning
        source.Listeners.Add(new DebuggerTraceListener()) |> ignore


    override self.InitializeAsync (cancellationToken:CancellationToken, progress:IProgress<ServiceProgressData>) =
        self.RegisterTraceListener()
        Task.CompletedTask
