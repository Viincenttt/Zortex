using UnityEngine;

namespace Assets.Scripts {
    public class ScoreBoard : MonoBehaviour {
        [SerializeField] private TextMesh _scoreText;

        private int _currentScore = 0;

        public void OnEnemyKilled() {
            this._currentScore++;

            this._scoreText.text = this._currentScore.ToString();
        }
    }
}