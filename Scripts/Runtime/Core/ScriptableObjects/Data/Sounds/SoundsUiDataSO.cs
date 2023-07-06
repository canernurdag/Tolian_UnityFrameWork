using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Core.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "SoundsUiDataSO", menuName = "TolianGames/Data/Sound/SoundsUiDataSO")]

    public class SoundsUiDataSO : ScriptableObject
    {
        public AudioClip ButtonSelectSFX;
        public AudioClip ButtonExitSFX;
        public AudioClip ButtonToggleSFX;
        public AudioClip PopUpSFX;
        public AudioClip StarSFX;
    }

}
