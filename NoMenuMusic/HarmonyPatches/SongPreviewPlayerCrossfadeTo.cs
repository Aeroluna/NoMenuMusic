using Harmony;
using IPA.Utilities;
using System;
using UnityEngine;

namespace NoMenuMusic.HarmonyPatches
{
    [HarmonyPatch(typeof(SongPreviewPlayer))]
    [HarmonyPatch("CrossfadeTo")]
    [HarmonyPatch(new Type[] { typeof(AudioClip), typeof(float), typeof(float), typeof(float) })]
    internal class SongPreviewPlayerCrossfadeTo
    {
        private static bool Prefix(SongPreviewPlayer __instance, AudioClip audioClip, float startTime, float duration, float volumeScale = 1f)
        {
            var defaultClip = __instance.GetPrivateField<AudioClip>("_defaultAudioClip");
            __instance.volume = audioClip == defaultClip ? 0 : 1;
            return true;
        }
    }
}