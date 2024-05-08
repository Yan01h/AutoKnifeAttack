// Copyright (c) 2024 Yan01h
// MIT license

using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace AutoKnifeAttack.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatches
    {
        private static float _timeAtLastAttack = 0.0f;

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        internal static void ItemActivatePostfix(PlayerControllerB __instance)
        {
            if (__instance.currentlyHeldObjectServer && __instance.currentlyHeldObjectServer.GetType() == typeof(KnifeItem))
            {
                bool attack = IngamePlayerSettings.Instance.playerInput.actions.FindAction("ActivateItem", false).IsPressed();
                if (attack && Time.realtimeSinceStartup - _timeAtLastAttack > 0.43f)
                {
                    _timeAtLastAttack = Time.realtimeSinceStartup;
                    __instance.currentlyHeldObjectServer.UseItemOnClient(true);
                }
            }
        }
    }
}