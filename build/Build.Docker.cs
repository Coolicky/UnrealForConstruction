using System;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Docker;
using Nuke.Common.Tools.GitVersion;
using Polly;
using Serilog;
using static Nuke.Common.Tools.Docker.DockerTasks;
using static Nuke.GitHub.GitHubTasks;

partial class Build
{
    [GitVersion] readonly GitVersion GitVersion;
    [GitRepository] readonly GitRepository GitRepository;
    [Secret] 
    [Parameter("Github Personal Access Token")] string GitHubToken;

    [Parameter("The GitHub user account that will be used to push the Docker image to the container registry")]
    readonly string GitHubUsername;


    Target BuildDockerImage => _ => _
        .DependsOn(Compile)
        .Requires(() => GitVersion)
        .Requires(() => ActiveProject)
        .Executes(() =>
        {
            var (repositoryOwner, repositoryName) = GetGitHubRepositoryInfo(GitRepository);
            DockerBuild(r => r
                .SetProcessEnvironmentVariable("DOCKER_BUILDKIT", "1")
                .SetProcessWorkingDirectory(RootDirectory / "src")
                .SetFile(ProjectPath / "Dockerfile")
                .SetPath(".")
                .SetLabel(
                    $"org.opencontainers.image.source={GitRepository.HttpsUrl?[..^4]}",
                    $"org.opencontainers.image.licenses=MIT")
                .SetTag(ActiveProject.DockerImage));
        });

    Target PushImageToGitHubRegistry => _ => _
        .DependsOn(BuildDockerImage)
        .Requires(() => GitHubToken)
        .Requires(() => GitHubUsername)
        .Requires(() => GitRepository)
        .Requires(() => ActiveProject)
        .OnlyWhenDynamic(() => GitRepository.IsOnMainOrMasterBranch())
        .Executes(() =>
        {
            Policy.Handle<Exception>()
                .WaitAndRetry(5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (ex, timeSpan, retryCount, context) =>
                    {
                        Log.Warning("Docker login exited with code: {Ex}", ex);
                        Log.Information("Attempting to login into GitHub Docker image registry. Try #{RetryCount}", retryCount);
                    })
                .Execute(() => DockerLogin(settings => settings
                    .SetServer("https://ghcr.io")
                    .SetUsername(GitHubUsername)
                    .SetPassword(GitHubToken)
                    .DisableProcessLogOutput()));
            
            var (repositoryOwner, repositoryName) = GetGitHubRepositoryInfo(GitRepository);

            var versionImageName =
                $"ghcr.io/{repositoryOwner.ToLowerInvariant()}/{ActiveProject.DockerImage}:{GitVersion.MajorMinorPatch}";
            var latestImageName = $"ghcr.io/{repositoryOwner.ToLowerInvariant()}/{ActiveProject.DockerImage}:latest";

            DockerTag(settings => settings
                .SetSourceImage(ActiveProject.DockerImage)
                .SetTargetImage(versionImageName));

            DockerTag(settings => settings
                .SetSourceImage(ActiveProject.DockerImage)
                .SetTargetImage(latestImageName));

            DockerPush(settings => settings.SetName(versionImageName));
            DockerPush(settings => settings.SetName(latestImageName));
        });
}