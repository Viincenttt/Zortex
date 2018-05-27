using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Framework.Effects {
    [RequireComponent(typeof(Light))]
    public class FadingLight : MonoBehaviour {
        private Light _light;

        [SerializeField][Range(0.1f, 30f)] private float _fadeAfterSeconds = 2f;

        private void Start() {
            this._light = this.GetComponent<Light>();

            this.StartCoroutine(this.DestroyAfterFade());
        }

        private void Update() {
            float intensityDecrease = Time.deltaTime / this._fadeAfterSeconds;
            this._light.intensity -= this._light.intensity * intensityDecrease;
        }

        private IEnumerator DestroyAfterFade() {
            yield return new WaitForSeconds(this._fadeAfterSeconds);

            GameObject.Destroy(this.gameObject);
        }
    }
}