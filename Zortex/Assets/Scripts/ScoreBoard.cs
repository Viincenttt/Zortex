using UnityEngine;

namespace Assets.Scripts {
    public class ScoreBoard : MonoBehaviour {
        public int _currentScore = 0;

        public int Score {
            get { return this._currentScore; }
        }
        
        public void ResetScore() {
            this._currentScore = 0;
        }

        public void OnEnemyKilled() {
            this._currentScore++;
        }
    }
}