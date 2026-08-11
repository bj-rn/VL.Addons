// Headless compile checks via VL.TestFramework: the VL compiler is booted headlessly
// and verifies that every package's main document and every patch under its help/
// folder compile without errors. Packages (VL.Addons.*) and help patches are
// discovered automatically, so a new package or help patch is covered the moment the
// file exists. Each document runs through the full compiler pipeline (load, dependency
// resolution, type checking, code emission) but nothing is executed, no window opens.
// vvvv can stay open while the tests run.
//
// Run all tests from the repo root:
//
//   dotnet test tests\VL.Addons.Tests
//
// Useful variations:
//
//   dotnet test tests\VL.Addons.Tests --filter "Name~MainDocumentCompiles"  # just the main documents
//   dotnet test tests\VL.Addons.Tests --filter "Name~HelpPatchCompiles"     # all help patches
//   dotnet test tests\VL.Addons.Tests --filter "Name~Combinatorics"         # a specific patch (relative path is the test name)
//   dotnet test tests\VL.Addons.Tests --logger "console;verbosity=detailed" # full compiler messages on failure
//
// Against a different vvvv installation (PowerShell):
//
//   $env:VVVV_DIR = "D:\vvvv\vvvv_gamma_7.4-win-x64"; dotnet test tests\VL.Addons.Tests
//
// Preconditions: a local vvvv installation (the fixture's default path matches the
// author's machine, on any other machine set the VVVV_DIR environment variable as
// shown above).
//
//  - entryAssembly is the path to vvvv.exe — vvvv's own standard libraries are then
//    included automatically and stay version-coherent.
//  - preCompilePackages MUST stay true: without it the VL compiler never loads the
//    runtime assemblies of referenced packages and computing imported pin defaults
//    crashes as soon as any referenced assembly declares an enum parameter default.
//  - The search path is the repo root itself: all VL.Addons.* packages live directly
//    under it, so they resolve against each other like vvvv's --package-repositories.

using NUnit.Framework;
using VL.TestFramework;

namespace VL.Addons.Tests;

[TestFixture]
public class VlDocumentTests
{
    private TestEnvironment? testEnvironment;

    // The vvvv installation this library targets; override with the VVVV_DIR environment variable.
    private static string VvvvDir =>
        Environment.GetEnvironmentVariable("VVVV_DIR") ?? @"D:\vvvv\vvvv_gamma_7.4-win-x64";

    /// <summary>Repo root located by walking up from the test assembly to the deployment folder.</summary>
    private static string RepoRoot { get; } = FindRepoRoot();

    private static string FindRepoRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null)
        {
            if (Directory.Exists(Path.Combine(dir.FullName, "deployment")) &&
                File.Exists(Path.Combine(dir.FullName, "VL.Addons", "VL.Addons.vl")))
                return dir.FullName;
            dir = dir.Parent;
        }
        throw new DirectoryNotFoundException("Could not locate the repository root (deployment + VL.Addons/VL.Addons.vl).");
    }

    // NUnit sync-context issue: keep setup non-async (see vvvv testing docs)
    [OneTimeSetUp]
    public void Setup()
    {
        var searchPaths = new[] { RepoRoot };
        testEnvironment = TestEnvironmentLoader.Load(Path.Combine(VvvvDir, "vvvv.exe"), searchPaths, preCompilePackages: true);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        testEnvironment?.Dispose();
        testEnvironment = null;
    }

    [TestCaseSource(nameof(MainDocuments))]
    public async Task MainDocumentCompiles(string relativePath)
    {
        await testEnvironment!.LoadAndTestAsync(Path.Combine(RepoRoot, relativePath));
    }

    [TestCaseSource(nameof(HelpPatches))]
    public async Task HelpPatchCompiles(string relativePath)
    {
        await testEnvironment!.LoadAndTestAsync(Path.Combine(RepoRoot, relativePath));
    }

    // <Package>\<Package>.vl for every VL.Addons* folder in the repo root
    public static IEnumerable<string> MainDocuments()
    {
        foreach (var packageDir in PackageDirs())
        {
            var mainDoc = Path.Combine(packageDir, Path.GetFileName(packageDir) + ".vl");
            if (File.Exists(mainDoc))
                yield return Path.GetRelativePath(RepoRoot, mainDoc);
        }
    }

    // <Package>\help\**\*.vl for every VL.Addons* folder in the repo root
    public static IEnumerable<string> HelpPatches()
    {
        foreach (var packageDir in PackageDirs())
        {
            var helpDir = Path.Combine(packageDir, "help");
            if (!Directory.Exists(helpDir))
                continue;
            foreach (var file in Directory.EnumerateFiles(helpDir, "*.vl", SearchOption.AllDirectories))
                yield return Path.GetRelativePath(RepoRoot, file);
        }
    }

    private static IEnumerable<string> PackageDirs() =>
        Directory.EnumerateDirectories(RepoRoot, "VL.Addons*").OrderBy(d => d);
}
