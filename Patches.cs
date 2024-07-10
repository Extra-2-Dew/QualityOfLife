using HarmonyLib;
using UnityEngine;

namespace QualityOfLife
{
	[HarmonyPatch]
	internal class Patches
	{
		// Fixes vanilla bug where list of resolution options in slider can get messed up
		// The original bug was caused by implicitly casting the index equation to int instead of flooring it
		// So depending on how many resolution options player had, it could skip some or repeat some indices
		// In slider list options
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
	}
}