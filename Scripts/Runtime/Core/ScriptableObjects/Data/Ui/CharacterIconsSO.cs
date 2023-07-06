using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Core.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "CharacterIcons", menuName = "TolianGames/Data/UI/CharacterIcons")]
    public class CharacterIconsSO : ScriptableObject
    {
        public List<Sprite> CharacterIcons;
    }

}
