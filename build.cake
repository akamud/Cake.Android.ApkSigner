var target = Argument("target", "Default");

Task("NugetRestore")
    .Does(() =>
{
    NuGetRestore("./Cake.Android.ApkSigning.sln");
});

Task("Build")
    .IsDependentOn("NugetRestore")
    .Does(() => 
    {
        MSBuild("./Cake.Android.ApkSigning.sln");
    });

Task("Default")
    .IsDependentOn("Build")
    .Does(() => 
    {

    });

RunTarget(target);