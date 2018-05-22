using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Actors {
    public class HealthSystem : MonoBehaviour {
        [SerializeField] private int _maximumHealth = 5;
        [SerializeField] private ParticleSystem _deathExplosion;
        [SerializeField] private UnityEvent _onKilled;

        private int _currentHealth;

        private void Start() {
            this._currentHealth = this._maximumHealth;
        }

        void OnParticleCollision(GameObject other) {
            this.TakeDamage();
        }

        private void TakeDamage() {
            this.DecreaseHealth();

            if (this.IsDead) {
                this.Explode();
            }
        }

        private void DecreaseHealth() {
            this._currentHealth -= 1;
        }

        private void Explode() {
            if (this._deathExplosion != null) {
                ParticleSystem explosion = GameObject.Instantiate(this._deathExplosion, this.transform.position, Quaternion.identity);
                explosion.gameObject.layer = this.gameObject.layer;
            }
            this._onKilled.Invoke();

            GameObject.Destroy(this.gameObject);
        }

        private bool IsDead {
            get { return this._currentHealth <= 0; }
        }
    }
}