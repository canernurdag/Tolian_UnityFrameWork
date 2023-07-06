using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Tolian.Runtime.Core.UiSystem;
using Tolian.Runtime.Systems.ObjectPoolDomain;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tolian.Runtime.Core.Managers.UiSystem
{
    /// <summary>
    /// This class handles ui money objects which are used widely in mobile games
    /// </summary>
    [DefaultExecutionOrder(40)]
    public class ControllerUiMoneyCanvas : MonoBehaviour
    {
        #region REFERENCES
        public ManagerObjectPool ManagerObjectPool { get; private set; }
        #endregion
        
        #region Fields
        [SerializeField] private Canvas _moneyCanvas;
        [SerializeField] private TMP_Text _moneyText;
        #endregion
        
        private void Start()
        {
            ManagerObjectPool = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerObjectPool>();
            SetScoreText(ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>().SaveSystem.SaveState.TotalMoneyAmount);
        }

        /// <summary>
        /// This functions raise a "Money Image" from WorldSpace position to ScreenSpace "Total Money" area
        /// </summary>
        /// <param name="worldPos"></param>
        /// <param name="callback"></param>
        public void SendMoneyImage(Vector3 worldPos, Action callback)
        {
            GameObject moneyImageObject = ManagerObjectPool.ObjectPoolSystem.Spawn(ObjectPoolType.UiCoin);
            moneyImageObject.transform.SetParent(_moneyCanvas.transform);

            Vector3 spawnPos = GetScreenPos(worldPos);
            Vector3 randomizedSpawnPos = GetRandomizedScreenPos(worldPos);

            moneyImageObject.transform.position = spawnPos;
            moneyImageObject.transform.DOMove(randomizedSpawnPos, 0.35f + Random.Range(0, 0.15f)).OnComplete(() =>
            {
                moneyImageObject.transform.DOMove(_moneyText.transform.position, (0.5f + Random.Range(0.3f, 0.6f)))
                    .OnComplete(() =>
                    {
                        callback();
                        UiCoin uiCoin = moneyImageObject.GetComponent<UiCoin>();
                        ManagerObjectPool.ObjectPoolSystem.Despawn(ObjectPoolType.UiCoin, uiCoin);
                    });
            });
        }

        /// <summary>
        /// This function is multiple version of "SendMoneyImage" function
        /// </summary>
        /// <param name="worldPos"></param>
        /// <param name="callback"></param>
        /// <param name="moneyCount"></param>
        public void SendMultipleMoneyImage(Vector3 worldPos, Action callback, int moneyCount=8)
        {
            for (int i = 0; i < moneyCount; i++)
            {
                int no = i;
                SendMoneyImage(worldPos, null);
                if (no == moneyCount - 1)
                {
                    callback();
                }
            }
        }

        public void SetScoreText(int targetScore)
        {
            _moneyText.text = targetScore.ToString();
        }

        #region Helper Functions

        private Vector3 GetScreenPos(Vector3 worldPos)
        {
            Vector3 spawnPos = Camera.main.WorldToScreenPoint(worldPos);
            return spawnPos;
        }

        private Vector3 GetRandomizedScreenPos(Vector3 worldPos)
        {
            Vector3 spawnPos = Camera.main.WorldToScreenPoint(worldPos);
            Vector3 randomizedSpawnPos = new Vector3(
                spawnPos.x + Random.Range(0, 500),
                spawnPos.y + Random.Range(0, 500),
                spawnPos.z);
            return randomizedSpawnPos;
        }

        #endregion

    }
}


