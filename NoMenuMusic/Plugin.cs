using HarmonyLib;
using IPA;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace NoMenuMusic
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    internal class Plugin
    {
        internal static IPALogger log { get; set; }

        internal static void Log(string message, IPALogger.Level level = IPALogger.Level.Debug)
        {
            log.Log(level, $"{message}");
        }

        [Init]
        public Plugin(IPALogger logger)
        {
            log = logger;
        }

        [OnStart]
        public void OnApplicationStart()
        {
            var harmony = new Harmony("com.aeroluna.BeatSaber.NoMenuMusic");
            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}