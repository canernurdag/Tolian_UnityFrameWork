using System;
using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Systems.DebuggerSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Tolian.Runtime.Systems.AddressablesDomain
{
    /// <summary>
    /// This class handles the logic of addressables system.
    /// This class mainly handles GameObject loading/unloading and Scene loading/unloading.
    /// This class can be extended by adding bundles and remote control according to needs
    /// </summary>
    public class AddressablesSystem : MonoBehaviour
    {
        #region SCENE
        private SceneInstance _currentSceneInstance;
        #endregion
        

        #region OBJECT FUNCTIONS

        public void GetGameObjectAsyncWithCallback(AssetReference assetReference, Action<GameObject> callback)
        {
            var asyncOperationHandle = assetReference.InstantiateAsync();
            
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject newGameObject = asyncOperationHandle.Result;
                callback(newGameObject);
            }
            else
            {
                callback(null);
                ManagerDebugger.Log("Failed to load gameobject", this.gameObject);
            }
        }
        
        public void ReleaseAndDestroy(GameObject addressedGameObject)
        {
            if (!Addressables.ReleaseInstance(addressedGameObject))
                Destroy(addressedGameObject);
        }

        #endregion
    
        #region SCENE FUNCTIONS

        public void LoadSceneAsync(string scenePath, LoadSceneMode targetSceneMode)
        {
            Addressables.LoadSceneAsync(scenePath, targetSceneMode).Completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> asyncOperationHandle)
        {
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                SceneInstance loadedSceneInstance = asyncOperationHandle.Result;
                _currentSceneInstance = loadedSceneInstance;
            }
            else
            {
                ManagerDebugger.Log("Failed to load scene", this.gameObject);
            }
        }

        public void UnloadSceneAsync(SceneInstance targetSceneInstance)
        {
            Addressables.UnloadSceneAsync(targetSceneInstance).Completed += OnSceneUnloaded;
        }

        private void OnSceneUnloaded(AsyncOperationHandle<SceneInstance> asyncOperationHandle)
        {
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                _currentSceneInstance = new SceneInstance();
            }
            else
            {
                ManagerDebugger.Log("Failed to unload scene", this.gameObject);
            }
        }

        #endregion

    }

}
