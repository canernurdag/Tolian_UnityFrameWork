using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;

namespace Tolian.Runtime.Systems.VibrateDomain
{
    public class VibrateSystem : MonoBehaviour
    {
        public bool PreventVibration { get; private set; } = false;
        
        public void Vibrate(HapticTypes targetHapticType)
        {
            if (PreventVibration) return;
            MMVibrationManager.Haptic(targetHapticType);
        }
        
        public void SetPreventVibration(bool value)
        {
            PreventVibration = value;
        }
    }

}
