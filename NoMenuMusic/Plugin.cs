using Harmony;
using IPA;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace NoMenuMusic
{
    public class Plugin : IBeatSaberPlugin
    {
        internal static HarmonyInstance harmony;

        public void Init(object thisIsNull, IPALogger logger)
        {
            Logger.log = logger;
        }

        public void OnApplicationStart()
        {
            harmony = HarmonyInstance.Create("com.aeroluna.BeatSaber.NoMenuMusic");
            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
        }

        public void OnApplicationQuit()
        {
        }

        public void OnFixedUpdate()
        {
        }

        public void OnUpdate()
        {
        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
        }

        public void OnSceneUnloaded(Scene scene)
        {
        }
    }
}