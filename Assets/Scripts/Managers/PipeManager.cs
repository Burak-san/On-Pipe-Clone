using Controllers.Pipe;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PipeManager : MonoBehaviour
    {
        [SerializeField] private PipeMovementController _pipeMovementController;
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
            CoreGameSignals.Instance.onNextLevel += OnReset;
            CoreGameSignals.Instance.onReset += OnReset;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
            CoreGameSignals.Instance.onNextLevel -= OnReset;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void OnChangeGameState(GameStates currentStates)
        {
            _pipeMovementController.SetState(currentStates);
        }
        
        private void OnReset()
        {
            transform.position = Vector3.zero;
        }

    }
}