using UnityEngine;

namespace Game.Scripts.Game.Core
{
    public class ScoreData
    {
        public int Score { get; private set; }

        public void SetScore(int score)
        {
            Score += score;
        }

        public void ResetScore()
        {
            Score = 0;
        }
    }
}
