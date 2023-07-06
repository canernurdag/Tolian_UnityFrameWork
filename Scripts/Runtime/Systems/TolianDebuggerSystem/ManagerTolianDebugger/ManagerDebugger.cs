using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Systems.DebuggerSystem
{
    public static class ManagerDebugger
    {
        /// <summary>
        /// This bool controls availability of LOG function
        /// </summary>
        public static bool PreventDebugging = false;

        /// <summary>
        /// This is a controllable DEBUG-LOG function 
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="senderGameObject"></param>
        public static void Log(string logMessage, GameObject senderGameObject)
        {
            if(PreventDebugging) return;
            
#if (DEVELOPMENT_BUILD || UNITY_EDITOR)
        Debug.Log(logMessage, senderGameObject);
#endif
       
        }
    }
}

