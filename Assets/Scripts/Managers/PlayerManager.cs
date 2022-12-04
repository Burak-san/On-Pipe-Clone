using Controllers.Player;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMeshController _playerMeshController;
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += _playerMeshController.GetPipeScale;
            InputSignals.Instance.onInputReleased += _playerMeshController.GetFirstScale;
        }

        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= _playerMeshController.GetPipeScale;
            InputSignals.Instance.onInputReleased -= _playerMeshController.GetFirstScale;
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        

    }
}