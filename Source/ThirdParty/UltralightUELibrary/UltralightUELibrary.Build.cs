/*
 *   Copyright (c) 2023 Mikael Aboagye & Ultralight Inc.
 *   All rights reserved.

 *   Permission is hereby granted, free of charge, to any person obtaining a copy
 *   of this software and associated documentation files (the "Software"), to deal
 *   in the Software without restriction, including without limitation the rights
 *   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *   copies of the Software, and to permit persons to whom the Software is
 *   furnished to do so, subject to the following conditions:
 
 *   The above copyright notice and this permission notice shall be included in all
 *   copies or substantial portions of the Software.
 
 *   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *   SOFTWARE.
 */
using System.Collections.Generic;
using System.IO;
using UnrealBuildTool;

public class UltralightUELibrary : ModuleRules
{
    public UltralightUELibrary(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;

        PublicIncludePaths.Add("$(PluginDir)/Source/ThirdParty/UltralightUELibrary/include");
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            // Add the import library
            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "x64", "Release", "AppCore.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "x64", "Release", "WebCore.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "x64", "Release", "UltralightCore.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "x64", "Release", "Ultralight.lib"));
            // Delay-load the DLL, so we can load it from the right place first
            PublicDelayLoadDLLs.Add("AppCore.dll");
            PublicDelayLoadDLLs.Add("WebCore.dll");
            PublicDelayLoadDLLs.Add("Ultralight.dll");
            PublicDelayLoadDLLs.Add("UltralightCore.dll");
            // Ensure that the DLL(s) is staged along with the executable
            RuntimeDependencies.Add("$(PluginDir)/Binaries/ThirdParty/UltralightUE/Win64/AppCore.dll");
            RuntimeDependencies.Add("$(PluginDir)/Binaries/ThirdParty/UltralightUE/Win64/WebCore.dll");
            RuntimeDependencies.Add("$(PluginDir)/Binaries/ThirdParty/UltralightUE/Win64/UltralightCore.dll");
            RuntimeDependencies.Add("$(PluginDir)/Binaries/ThirdParty/UltralightUE/Win64/Ultralight.dll");
        }
        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            PublicDelayLoadDLLs.Add(Path.Combine(ModuleDirectory, "Mac", "Release", "libAppCore.dylib"));
            PublicDelayLoadDLLs.Add(Path.Combine(ModuleDirectory, "Mac", "Release", "libUltralight.dylib"));
            PublicDelayLoadDLLs.Add(Path.Combine(ModuleDirectory, "Mac", "Release", "libUltralightCore.dylib"));
            PublicDelayLoadDLLs.Add(Path.Combine(ModuleDirectory, "Mac", "Release", "libWebCore.dylib"));
            RuntimeDependencies.Add("$(PluginDir)/Source/ThirdParty/UltralightUE/Mac/Release/libAppCore.dylib");
            RuntimeDependencies.Add("$(PluginDir)/Source/ThirdParty/UltralightUE/Mac/Release/libUltralight.dylib");
            RuntimeDependencies.Add("$(PluginDir)/Source/ThirdParty/UltralightUE/Mac/Release/libUltralightCore.dylib");
            RuntimeDependencies.Add("$(PluginDir)/Source/ThirdParty/UltralightUE/Mac/Release/libWebCore.dylib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            string SoWebCorePath = Path.Combine("$(PluginDir)", "Binaries", "ThirdParty", "UltralightUE", "Linux", "x86_64-unknown-linux-gnu", "libWebCore.so");
            string SoULCorePath = Path.Combine("$(PluginDir)", "Binaries", "ThirdParty", "UltralightUE", "Linux", "x86_64-unknown-linux-gnu", "libUltralightCore.so");
            string SoULPath = Path.Combine("$(PluginDir)", "Binaries", "ThirdParty", "UltralightUE", "Linux", "x86_64-unknown-linux-gnu", "libUltralight.so");
            string SoAppCorePath = Path.Combine("$(PluginDir)", "Binaries", "ThirdParty", "UltralightUE", "Linux", "x86_64-unknown-linux-gnu", "libAppCore.so");
            PublicAdditionalLibraries.Add(SoWebCorePath);
            PublicAdditionalLibraries.Add(SoAppCorePath);
            PublicAdditionalLibraries.Add(SoULCorePath);
            PublicAdditionalLibraries.Add(SoULPath);
            PublicDelayLoadDLLs.Add(SoWebCorePath);
            PublicDelayLoadDLLs.Add(SoAppCorePath);
            PublicDelayLoadDLLs.Add(SoULCorePath);
            PublicDelayLoadDLLs.Add(SoULPath);
            RuntimeDependencies.Add(SoWebCorePath);
            RuntimeDependencies.Add(SoAppCorePath);
            RuntimeDependencies.Add(SoULCorePath);
            RuntimeDependencies.Add(SoULPath);
        }
    }
}