using ObjCRuntime;

[assembly: LinkWith ("DeskKitSDK.framework", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64, SmartLink = true, ForceLoad = true, Frameworks = "Foundation")]
