using Controllers.UI;
using Enums;
using Signals;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIPanelController _uıPanelController;
        [SerializeField] private TextMeshProUGUI startPanelCoin;
        [SerializeField] private TextMeshProUGUI gamePanelLevel;
        [SerializeField] private TextMeshProUGUI winPanelLevel;
        [SerializeField] private TextMeshProUGUI failPanelLevel;
        [SerializeField] private TextMeshProUGUI gamePanelTotalScore;
        [SerializeField] private TextMeshProUGUI winPanelTotalScore;
        [SerializeField] private TextMeshProUGUI failPanelTotalScore;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onSetLevelText += OnSetLevelText;
            UISignals.Instance.onSetTotalScoreText += OnSetTotalScoreText;
            UISignals.Instance.onSetCoinText += OnSetCoinText;

            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;

        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onSetLevelText -= OnSetLevelText;
            UISignals.Instance.onSetTotalScoreText -= OnSetTotalScoreText;
            UISignals.Instance.onSetCoinText -= OnSetCoinText;

            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        public void PlayButton()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        public void RestartButton()
        {
            CoreGameSignals.Instance.onReset?.Invoke();
        }

        public void NextLevelButton()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
        }
        
        private void OnOpenPanel(UIPanelStates panelStates)
        {
            _uıPanelController.OpenPanel(panelStates);
        }
        
        private void OnClosePanel(UIPanelStates panelStates)
        {
            _uıPanelController.ClosePanel(panelStates);
        }

        private void OnSetLevelText(int value)
        {
            gamePanelLevel.text = "LEVEL " + value.ToString();
            failPanelLevel.text = "LEVEL " + value.ToString();
            winPanelLevel.text = "LEVEL " + value.ToString();
        }

        private void OnSetTotalScoreText(int value)
        {
            gamePanelTotalScore.text = value.ToString();
            failPanelTotalScore.text = "TOTAL SCORE " + value.ToString();
            winPanelTotalScore.text = "TOTAL SCORE " + value.ToString();
        }

        private void OnSetCoinText(int value)
        {
            startPanelCoin.text = value.ToString();
        }
        
        private void OnLevelFailed()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanelStates.GamePanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelStates.FailPanel);
        }

        private void OnLevelSuccessful()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanelStates.GamePanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelStates.WinPanel);
        }

        private void OnPlay()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanelStates.StartPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelStates.GamePanel);
        }

        private void OnNextLevel()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelStates.StartPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanelStates.WinPanel);
        }

        private void OnReset()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelStates.StartPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanelStates.FailPanel);
        }
    }
}