/**
    File: build.cake
    Description : Hive.Core build system
    Maintainer: maciej.misztal@cloud-technologies.net
    Copyright: Cloud Technologies 2015 (C), All rights reserved
 */
 
var target = Argument("target", "UnitTests");
var configuration = Argument("configuration", "Debug");

var buildDir = "./Build";
var solutionFile = "./Hive.Core.sln";

Task("Clean").Does(() => {
        
}); // Clean

Task("RestorePackages")
    .IsDependentOn("Clean")
    .Does(()=>{
    NuGetRestore(solutionFile);     
}); // RestorePackages

Task("Build")
    .IsDependentOn("RestorePackages")
    .Does(() => {
     DotNetBuild (solutionFile, c => c.Configuration = configuration);
     //CopyFiles ("./**/*.dll", buildDir);        
}); // Build

Task("UnitTests")
    .IsDependentOn("Build")
    .Does(() => {
    XUnit2(string.Format("**/bin/{0}/*.UnitTests.dll", configuration));
}); // UnitTests

RunTarget(target);