using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Abstract.DesignPatterns.SingletonSystem
{
    /// <summary>
    /// / For SINGLETON Design Pattern => Base and abstract class for Singletons. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// This bool determines that this singleton is "DontDestroyOnLoad" or not
        /// </summary>
        [SerializeField] private bool dontDestroy = false;

        static T m_Instance;
        public static T Instance {
            get {
                if (m_Instance == null) 
                {
                    m_Instance = FindObjectOfType<T>();
                }
                return m_Instance;
            }
        }

        protected virtual void Awake() {
            if (m_Instance == null)
            {
                m_Instance = this as T;
                if (dontDestroy)
                {
                    transform.parent = null;
                    DontDestroyOnLoad(this.gameObject);
                }
            }
            else {
                if (m_Instance != this as T)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
