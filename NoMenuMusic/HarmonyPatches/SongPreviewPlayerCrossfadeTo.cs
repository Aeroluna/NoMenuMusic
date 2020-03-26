using HarmonyLib;
using IPA.Utilities;
using System;
using UnityEngine;

namespace NoMenuMusic.HarmonyPatches
{
    [HarmonyPatch(typeof(SongPreviewPlayer))]
    [HarmonyPatch("CrossfadeTo")]
    [HarmonyPatch(new Type[] { typeof(AudioClip), typeof(float), typeof(float), typeof(float) })]
    public class SongPreviewPlayerCrossfadeTo
    {
        static bool Prefix(SongPreviewPlayer __instance, AudioClip audioClip)
        {
            var defaultClip = __instance.GetField<AudioClip, SongPreviewPlayer>("_defaultAudioClip");
            __instance.volume = audioClip == defaultClip ? 0 : 1;
            return true;
        }
    }
}