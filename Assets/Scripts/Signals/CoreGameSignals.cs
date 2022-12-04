using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onPlay = delegate {  };
        public UnityAction onReset = delegate {  };
        public UnityAction onNextLevel = delegate {  };
        public UnityAction onLevelFailed = delegate {  };
        public UnityAction onLevelSuccessful = delegate {  };
        public UnityAction<Transform,int> onParticleActive = delegate {  };
        public UnityAction<GameStates> onChangeGameState = delegate {  };
    }
}