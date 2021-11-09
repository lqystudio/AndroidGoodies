// Copyright (c) 2018 Nineva Studios

using System.IO;
using UnrealBuildTool;

public class AndroidGoodies : ModuleRules
{
	public AndroidGoodies(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicIncludePaths.AddRange(
			new string[] 
			{
#if UE_4_20_OR_LATER
				Path.Combine (ModuleDirectory, "Public")
#else
				"AndroidGoodies/Public"
#endif
				// ... add public include paths required here ...
			}
		);

		PrivateIncludePaths.AddRange(
			new string[] 
			{
#if UE_4_20_OR_LATER
				Path.Combine (ModuleDirectory, "Private")
#else
				"AndroidGoodies/Private"
#endif
				// ... add other private include paths required here ...
			}
		);

		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Engine",
				"Core",
				"CoreUObject"
				// ... add other public dependencies that you statically link with here ...
			}
		);

		// additional routine for Android
		if (Target.Platform == UnrealTargetPlatform.Android)
		{
#if UE_4_20_OR_LATER
			PrivateIncludePaths.Add(Path.Combine(ModuleDirectory, "Private/Android"));
#else
			PrivateIncludePaths.AddRange(
				new string[]
				{
					"AndroidGoodies/Private/Android"
					// ... add other private include paths required here ...
				}
			);
#endif
			
			PrivateDependencyModuleNames.AddRange(new string[] { "Launch" });
			string PluginPath = Utils.MakePathRelativeTo(ModuleDirectory, Target.RelativeEnginePath);

#if UE_4_19_OR_LATER
			AdditionalPropertiesForReceipt.Add("AndroidPlugin", Path.Combine(PluginPath, "AndroidGoodies_UPL.xml"));
#else
			AdditionalPropertiesForReceipt.Add(new ReceiptProperty("AndroidPlugin", Path.Combine(PluginPath, "AndroidGoodies_UPL.xml")));
#endif
		}
	}
}
