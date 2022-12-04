using System;
using DG.Tweening;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

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
                HitObstacle();
            }
            
            if (other.CompareTag("LevelTrigger"))
            {
                HitLevelTrigger();
            }
        }

        private void HitCorn(Collider other)
        {
            var otherRb = other.GetComponent<Rigidbody>();
            otherRb.isKinematic = false;
            otherRb.AddForce(otherRb.position ,ForceMode.Impulse);
            other.enabled = false;
        }

        private void HitObstacle()
        {
            CoreGameSignals.Instance.onLevelFailed?.Invoke();
        }

        private void HitLevelTrigger()
        {
            CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
        }
    }
}