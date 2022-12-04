using System.Collections.Generic;
using System.Threading.Tasks;
using Signals;
using UnityEngine;

namespace Managers
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> particles;
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onParticleActive += OnParticleActive;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onParticleActive -= OnParticleActive;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private async void OnParticleActive(Transform transform,int value)
        {
            ActiveParticle(transform,value);
            await Task.Delay(2000);
            PassiveParticle(value);
        }

        private void ActiveParticle(Transform transform,int value)
        {
            particles[value].transform.position = transform.position;
            particles[value].SetActive(true);
        }

        private void PassiveParticle(int value)
        {
            particles[value].SetActive(false);
            particles[value].transform.position = transform.position;
        }
    }
}