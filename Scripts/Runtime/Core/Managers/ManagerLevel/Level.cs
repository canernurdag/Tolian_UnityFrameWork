using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers.LevelSystem
{
    [System.Serializable]
    public class Level
    {
        public int LevelIndex;
        public bool IsLevelReturnable = true;

        public Level(int levelIndex, bool isLevelReturnable)
        {
            LevelIndex = levelIndex;
            IsLevelReturnable = isLevelReturnable;
        }
    }
 
}
