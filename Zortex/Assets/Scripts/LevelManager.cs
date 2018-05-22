using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class LevelManager : MonoBehaviour {
        [SerializeField] private float _delayBeforeSceneReload = 3f;

        public void RestartLevel() {
            this.StartCoroutine(this.ReloadSceneAfterDelay());
        }

        private IEnumerator ReloadSceneAfterDelay() {
            yield return new WaitForSeconds(this._delayBeforeSceneReload);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}