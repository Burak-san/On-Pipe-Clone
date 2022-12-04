using System;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using UnityEngine;
using Object = System.Object;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform levelHolder;
        private LevelData _levelData;
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _levelData = GetLevelData;
        }

        private void Start()
        {
            LevelLoader();
        }

        private LevelData GetLevelData => Resources.Load<CD_Level>("Data/CD_Level").Levels[0];

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onNextLevel += OnReset;
            CoreGameSignals.Instance.onReset += OnReset;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onNextLevel -= OnReset;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void ClearLevel()
        {
            Destroy(levelHolder.transform.GetChild(0).gameObject);
        }
        
        private void LevelLoader()
        {
            Instantiate(Resources.Load<GameObject>("LevelPrefabs/Level 1"), levelHolder.transform);
        }

        private void OnReset()
        {
            ClearLevel();
            LevelLoader();
        }
    }
}