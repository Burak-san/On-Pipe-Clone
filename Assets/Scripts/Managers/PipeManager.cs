using UnityEngine;

namespace Managers
{
    public class PipeManager : MonoBehaviour
    {
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            
        }
        
        private void UnSubscribeEvents()
        {
            
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
    }
}