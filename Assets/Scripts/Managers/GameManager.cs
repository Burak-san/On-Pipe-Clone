using System;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            Application.targetFrameRate = 60;
            CoreGameSignals.Instance.onChangeGameState?.Invoke(GameStates.Stop);
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        private void OnPlay()
        {
            CoreGameSignals.Instance.onChangeGameState?.Invoke(GameStates.Playing);
        }

        private void OnReset()
        {
            CoreGameSignals.Instance.onChangeGameState?.Invoke(GameStates.Stop);
        }
    }
}