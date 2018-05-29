using UnityEngine;

namespace Assets.Scripts {
    public class ScoreBoard : MonoBehaviour {
        [SerializeField] private TextMesh _scoreText;

        public int _currentScore = 0;

        public int Score => this._currentScore;

        public void OnEnemyKilled() {
            this._currentScore++;

            this._scoreText.text = this._currentScore.ToString();
        }
    }
}