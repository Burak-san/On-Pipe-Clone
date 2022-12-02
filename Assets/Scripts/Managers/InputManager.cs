using System;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private GameStates _gameStates;

        private void Update()
        {
            GamePlayInput();
        }

        private void GamePlayInput()
        {
            if (Input.GetMouseButton(0))
            {
                if (_gameStates == GameStates.Playing)
                {
                    InputSignals.Instance.onInputTaken?.Invoke();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_gameStates == GameStates.Playing)
                {
                    InputSignals.Instance.onInputReleased?.Invoke();
                }
            }
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        private void OnChangeGameState(GameStates currentState)
        {
            _gameStates = currentState;
        }
        
    }
}