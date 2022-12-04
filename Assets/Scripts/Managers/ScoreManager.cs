using System;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private ScoreData _scoreData;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _scoreData = GetScoreData();
            UISignals.Instance.onSetCoinText?.Invoke(_scoreData.CoinValue);
            UISignals.Instance.onSetLevelText?.Invoke(_scoreData.LevelScore);
            UISignals.Instance.onSetTotalScoreText?.Invoke(_scoreData.TotalScore);
        }

        private ScoreData GetScoreData() => Resources.Load<CD_Score>("Data/CD_Score").ScoreData;
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onGainScore += OnGainScore;
            
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onReset += OnReset;
        }
        
        private void UnSubscribeEvents()
        {
            ScoreSignals.Instance.onGainScore -= OnGainScore;
            
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void OnGainScore()
        {
            _scoreData.TotalScore += _scoreData.GainScore;
            UISignals.Instance.onSetTotalScoreText?.Invoke(_scoreData.TotalScore);
        }
        
        private void OnSetLevelScore()
        {
            _scoreData.LevelScore += _scoreData.GainLevelScore;
            UISignals.Instance.onSetLevelText?.Invoke(_scoreData.LevelScore);
        }

        private void OnSetCoinValue()
        {
            _scoreData.CoinValue += _scoreData.TotalScore / _scoreData.ScoreChangeCoinDivisionValue;
            UISignals.Instance.onSetCoinText?.Invoke(_scoreData.CoinValue);
        }
        
        private void ResetTotalScore()
        {
            _scoreData.TotalScore = 0 ;
            UISignals.Instance.onSetTotalScoreText?.Invoke(_scoreData.TotalScore);
        }
        
        private void OnNextLevel()
        {
            OnSetLevelScore();
            OnSetCoinValue();
            ResetTotalScore();
        }

        private void OnReset()
        {
            ResetTotalScore();
        }
    }
}