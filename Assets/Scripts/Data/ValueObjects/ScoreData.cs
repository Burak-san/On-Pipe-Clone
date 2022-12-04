using System;

namespace Data.ValueObjects
{
    [Serializable]
    public class ScoreData
    {
        public int LevelScore;
        public int GainLevelScore;
        public int GainScore;
        public int TotalScore;
        public int CoinValue;
        public int ScoreChangeCoinDivisionValue;
    }
}