using BepInEx;
using TrapDisabler.Patch;
using UnityEngine;

namespace TrapDisabler
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInProcess("Lycans.exe")]
    public class TrapDisabler : BaseUnityPlugin
    {
        // Le GUID du plugin doit être unique au plugin que vous créez
        // Il doit également être lisible car est utilisé dans le nom des fichiers de config
        // Changez le nom d'auteur et le nom du plugin afin que le GUID soit correctement
        // initialisé pour votre mod
        public const string PLUGIN_GUID = $"{PLUGIN_AUTHOR}.{PLUGIN_NAME}";
        public const string PLUGIN_AUTHOR = "LloydHawkeye";
        public const string PLUGIN_NAME = "TrapDisabler";
        public const string PLUGIN_VERSION = "1.0.0";

        private void Awake()
        {
            // Initialise le logger global du plugin
            Log.Init(Logger);
            GameManagerPatch.Patch();
        }
    }
}