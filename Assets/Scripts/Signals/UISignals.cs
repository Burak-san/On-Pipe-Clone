using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanelStates> onOpenPanel = delegate {  };
        public UnityAction<UIPanelStates> onClosePanel = delegate {  };
        public UnityAction<int> onSetLevelText = delegate {  };
        public UnityAction<int> onSetTotalScoreText = delegate {  };
        public UnityAction<int> onSetCompletedText = delegate {  };
        public UnityAction<int> onSetCoinText = delegate {  };
    }
}