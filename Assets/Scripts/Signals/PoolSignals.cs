using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class PoolSignals : MonoSingleton<PoolSignals>
    {
        public UnityAction<string, Vector3,Quaternion,Transform> onSpawnFromPool = delegate {  };
        public UnityAction<string,GameObject> onReturnToPool = delegate {  };
    }
}