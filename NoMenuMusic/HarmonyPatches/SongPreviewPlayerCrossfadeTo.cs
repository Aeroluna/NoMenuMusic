using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMenuMusic.HarmonyPatches
{
    [HarmonyPatch(typeof(SongPreviewPlayer))]
    [HarmonyPatch("CrossfadeTo")]
    [HarmonyPatch(new Type[] { typeof(AudioClip), typeof(float), typeof(float), typeof(float) })]
    class SongPreviewPlayerCrossfadeTo
    {
        static bool Prefix(SongPreviewPlayer __instance, AudioClip audioClip, float startTime, float duration, float volumeScale = 1f)
        {
            // Check if this is the default audio clip, and if it is, use the Menu BG Music Volume, otherwise use the preview volume.
            var defaultClip = ReflectionUtil.GetPrivateField<AudioClip>(__instance, "_defaultAudioClip");
            if (audioClip == defaultClip)
            {
                __instance.volume = 0;
                Logger.Log("Setting SongPreviewPlayer volume to MenuBGVolume : " + __instance.volume, IPA.Logging.Logger.Level.Debug);
            }
            else
            {
                __instance.volume = 1;
                Logger.Log("Setting SongPreviewPlayer volume to PreviewVolume : " + __instance.volume, IPA.Logging.Logger.Level.Debug);
            }

            // Return true to run the original method as well
            return true;
        }
    }
}
