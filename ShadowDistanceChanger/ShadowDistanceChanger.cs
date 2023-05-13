using HarmonyLib;
using NeosModLoader;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrooxEngine;

namespace ShadowDistanceChanger
{
    public class ShadowDistanceChanger : NeosMod
    {
        public override string Name => "ShadowDistanceChanger";
        public override string Author => "art0007i";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/art0007i/ShadowDistanceChanger/";

        [AutoRegisterConfigKey]
        public static ModConfigurationKey<float> KEY_SHADOW_DISTANCE = new("shadow_distance", "Changes the shadow distance to the specified value (in meters).", () => 50.0f);
        public override void OnEngineInit()
        {
            var config = GetConfiguration();
            //Harmony harmony = new Harmony("me.art0007i.ShadowDistanceChanger");
            UnityEngine.QualitySettings.shadowDistance = config.GetValue(KEY_SHADOW_DISTANCE);
            config.OnThisConfigurationChanged += (e) =>
            {
                if (e.Key == KEY_SHADOW_DISTANCE)
                {
                    UnityEngine.QualitySettings.shadowDistance = config.GetValue(KEY_SHADOW_DISTANCE);
                }
            };
        }
    }
}