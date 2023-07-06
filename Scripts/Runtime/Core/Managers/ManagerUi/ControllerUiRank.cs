using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tolian.Runtime.Core.UiSystem;
using Tolian.Runtime.Extentations;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Tolian.Runtime.Core.Managers.UiSystem
{
    //NOT FINISHED
   public class ControllerUiRank : MonoBehaviour
    {
        [SerializeField] private GameObject _rankPrefab;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private ScrollRect _scrollRect;
        
        
        [HideInInspector] public List<UiRank> UiRanks = new List<UiRank>();
        [HideInInspector] public List<string> NameList = new List<string>();

        private ManagerSave _managerSave;

        
        private void Start()
        {
            _managerSave = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>();
            CreateNameList();
            CreateRankList(40);
            // PlacePlayerToRankList();
        }
        private void CreateNameList()
        {
            string path = "Assets/Resources/Texts/names.txt";
            NameList = new List<string>(System.IO.File.ReadAllLines(path)).ToList();
        }

        private void CreateRankList(int rankListCount)
        {
            for (int i = 0; i < rankListCount; i++)
            {
                GameObject rankObject = Instantiate(_rankPrefab);
                rankObject.transform.SetParent(_parentTransform);

                UiRank uiRank = rankObject.GetComponent<UiRank>();
                uiRank.SetName(NameList[Random.Range(0,NameList.Count)]);
                uiRank.SetRank(i+1);
                int score = _managerSave.SaveSystem.SaveState.TotalMoneyAmount - 30 + UnityEngine.Random.Range(-4,4) + ((rankListCount - i) * 10);
                uiRank.SetScore(score);
                uiRank.SetIconSprite(uiRank.GetRandomCharacterSpite());
                uiRank.SetBackgroundImage(false);
                
                UiRanks.Add(uiRank);
            }
        }
        
        private void PlacePlayerToRankList(int playerCurrentScore)
        {
            int playerCurrentNo = UiRanks
                .Where(x => x.Score > playerCurrentScore)
                .OrderBy(x => x.Score)
                .ElementAt(0)
                .Rank-1+1;

            UiRank uiRank = UiRanks[playerCurrentNo];
            uiRank.SetScore(playerCurrentScore);
            uiRank.SetName(_managerSave.SaveSystem.SaveState.PlayerName);
            uiRank.SetBackgroundImage(true);
        }
        

        public void SetPlayerRankPosition()
        {
            _scrollRect.FocusOnItem(UiRanks[15].GetComponent<RectTransform>());
        }


    } 
}

