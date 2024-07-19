using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QualityOfLife
{
	[HarmonyPatch]
	internal class Patches
	{
		// Fixes vanilla bug where list of resolution options in slider can get messed up
		// the original bug was caused by implicitly casting the index equation to int instead of flooring it
		// so depending on how many resolution options player had, it could skip some or repeat some indices
		// in slider list options
		[HarmonyPrefix]
		[HarmonyPatch(typeof(GuiSliderComboListApplier), nameof(GuiSliderComboListApplier.SliderChanged))]
		public static bool GuiSliderComboListApplier_SliderChanged_Patch(GuiSliderComboListApplier __instance, float value)
		{
			int index = Mathf.FloorToInt(value * (__instance.currChildren.Count - 1));

			if (index < 0 && index >= __instance.currChildren.Count)
				return false;

			__instance._valueNode?.ApplyContent(__instance.GetActiveInData()[index], true);

			GameObject child = __instance.currChildren[index];
			GuiClickable clickable = child.GetComponentInChildren<GuiClickable>();
			clickable.SendClick();

			return false;
		}

		// Fixes vanilla "Fluffy lake warp" bug where the respawn override for intro dialogue would
		// continue to override the spawn position anytime you loaded into Fluffy room A, causing a
		// pause warp to return you to lake instead of last entrance you came from
		[HarmonyPrefix]
		[HarmonyPatch(typeof(ChangeRespawnerEventObserver), nameof(ChangeRespawnerEventObserver.DoChange))]
		public static bool ChangeRespawnerEventObserver_DoChange_Patch(ChangeRespawnerEventObserver __instance)
		{
			if (SceneManager.GetActiveScene().name == "FluffyFields" && __instance._isDefault)
				return ModCore.Plugin.MainSaver.LevelStorage.GetLocalSaver("A").LoadInt("IntroDialog-39--26") == 0;

			return true;
		}
	}
}