using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMCSwipeTableViewCellLibSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
