using TMPro;
using UnityEngine;

namespace Game.Scripts.Game.View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        public void SetScore(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    }
}
