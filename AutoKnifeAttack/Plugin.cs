// Copyright (c) 2024 Yan01h
// MIT license

using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace AutoKnifeAttack
{
    /// <summary>
    /// Main AutoKnifeAttack plugin class.
    /// </summary>
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PluginGUID = "Yan01h.AutoKnifeAttack";
        private const string PluginName = "AutoKnifeAttack";
        private const string PluginVersion = "1.0.0";

        public static ManualLogSource Log { get; private set; }

        private readonly Harmony _harmony = new Harmony(PluginGUID);

        public void Awake()
        {
            Log = BepInEx.Logging.Logger.CreateLogSource(PluginGUID);
            Log.LogInfo($"Loading {PluginName} (v{PluginVersion})");

            _harmony.PatchAll();

            Log.LogInfo($"Plugin: {PluginName}, Version: {PluginVersion} loaded!");
        }
    }
}