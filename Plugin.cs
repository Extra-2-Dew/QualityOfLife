﻿using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace QualityOfLife
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	[BepInDependency("ModCore")]
	public class Plugin : BaseUnityPlugin
	{
		private void Awake()
		{
			// Plugin startup logic
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

			Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

			SkipSplash();
		}

		private void SkipSplash()
		{
			// Load Main Menu
			ModCore.Utility.LoadScene(1);
		}
	}
}