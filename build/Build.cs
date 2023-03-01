using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Serilog;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

partial class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Project to build")] Project ActiveProject;
    AbsolutePath ProjectPath => RootDirectory / "src" / ActiveProject.ProjectName;

    [Solution] readonly Solution Solution;

    Target Clean => _ => _
        .Requires(() => ActiveProject)
        .Before(Restore)
        .Executes(() =>
        {
            DotNetClean(r =>
                r.SetProject(ProjectPath));
        });

    Target Restore => _ => _
        .Requires(() => ActiveProject)
        .Executes(() =>
        {
            DotNetRestore(r =>
                r.SetProjectFile(ProjectPath));
        });

    Target Compile => _ => _
        .Requires(() => ActiveProject)
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(r => r
                .SetProjectFile(ProjectPath)
                .SetAssemblyVersion(GitVersion.AssemblySemVer)
                .SetFileVersion(GitVersion.AssemblySemFileVer)
                .SetInformationalVersion(GitVersion.InformationalVersion)
                .SetConfiguration(Configuration)
                .EnableNoRestore());

            Log.Information("Current semver: {Version}", GitVersion.MajorMinorPatch);
        });
}