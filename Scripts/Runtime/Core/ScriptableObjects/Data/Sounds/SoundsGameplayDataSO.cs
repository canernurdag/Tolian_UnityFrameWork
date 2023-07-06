using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Core.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "SoundsGameplayDataSO", menuName = "TolianGames/Data/Sound/SoundsGameplayDataSO")]
    public class SoundsGameplayDataSO : ScriptableObject
    {
        [Header("Collectables")]
        public AudioClip CoingCollectableSFX;
        public AudioClip FancyCoinCollectableSFX;
        public AudioClip ItemCollectableSFX;
        public AudioClip BubbleSFX;

        [Header("Others")]
        public AudioClip TimeTickingSFX;
        public AudioClip EatingSFX;
        public AudioClip SlideUpSFX;
        public AudioClip SlideDownSFX;
    }
}

