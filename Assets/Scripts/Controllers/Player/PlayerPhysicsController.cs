using System.Threading.Tasks;
using Signals;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Corn"))
            {
                HitCorn(other);
            }

            if (other.CompareTag("Obstacle"))
            {
                HitObstacle(other);
            }
            
            if (other.CompareTag("LevelTrigger"))
            {
                HitLevelTrigger(other);
            }
        }

        private void HitCorn(Collider other)
        {
            CornRigidbodyProcess(other);
            ScoreSignals.Instance.onGainScore?.Invoke();
        }

        private void HitObstacle(Collider other)
        {
            CoreGameSignals.Instance.onLevelFailed?.Invoke();
            CoreGameSignals.Instance.onParticleActive?.Invoke(other.transform,1);
        }

        private void HitLevelTrigger(Collider other)
        {
            CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
            CoreGameSignals.Instance.onParticleActive?.Invoke(other.transform,0);
        }
        
        private async void CornRigidbodyProcess(Collider other)
        {
            var otherRb = other.GetComponent<Rigidbody>();
            otherRb.isKinematic = false;
            otherRb.AddForce(otherRb.position ,ForceMode.Impulse);
            other.enabled = false;

            await Task.Delay(2000);
            PoolSignals.Instance.onReturnToPool?.Invoke("Corn",other.gameObject);
        }
    }
}