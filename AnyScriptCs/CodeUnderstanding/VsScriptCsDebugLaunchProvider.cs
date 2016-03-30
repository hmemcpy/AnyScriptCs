using System;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Workspaces.CodeUnderstanding;
using Microsoft.VisualStudio.Workspaces.CodeUnderstanding.Contexts;

namespace AnyScriptCs.CodeUnderstanding
{
    [ExportVsDebugLaunchTarget(TargetType, new[] { ".csx" }, ProviderPriority.Lowest, ProviderOptions.None)]
    public class VsScriptCsDebugLaunchProvider : IVsDebugLaunchTargetProvider
    {
        private const string TargetType = "EDB4E838-3876-4797-B7F7-6DB30632E486"; // random guid
        private static readonly Guid ManagedOnlyGuid = new Guid("{449EC4CC-30D2-4032-9256-EE18EB41B62B}"); // taken from VSConstants.DebugEnginesGuids.ManagedOnly_guid

        public object SetupDebugTargetInfo(object vsDebugTargetInfo, DebugLaunchActionContext debugLaunchContext)
        {
            if (!debugLaunchContext.LaunchConfiguration.ContainsKey("scriptcs_exe"))
                return vsDebugTargetInfo;

            var scriptcs = debugLaunchContext.LaunchConfiguration.GetValue<string>("scriptcs_exe");
            var debugInfo = (VsDebugTargetInfo)vsDebugTargetInfo;
            var csxFile = debugInfo.bstrExe;
            debugInfo.bstrExe = scriptcs;
            debugInfo.bstrArg = $"\"{csxFile}\" -debug";
            debugInfo.clsidCustom = ManagedOnlyGuid;
            debugInfo.grfLaunch |= (uint)__VSDBGLAUNCHFLAGS.DBGLAUNCH_StopDebuggingOnEnd;
            return debugInfo;
        }
    }
}