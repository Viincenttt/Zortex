using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Actors {
    public class HealthSystem : MonoBehaviour {
        [Header("Health", order = 1)]
        [SerializeField] private int _maximumHealth = 5;

        [Header("Impact", order = 2)]
        [SerializeField] private ParticleSystem _impactEffect;
        [SerializeField] private Transform _impactEffectPosition;

        [Header("Death", order = 3)]
        [SerializeField] private ParticleSystem _deathExplosion;
        [SerializeField] private UnityEvent _onKilled;

        private int _currentHealth;

        private void Start() {
            this._currentHealth = this._maximumHealth;
        }

        void OnParticleCollision(GameObject shooter) {
            this.TakeDamage(shooter);
        }

        private void TakeDamage(GameObject shooter) {
            this.DecreaseHealth();
            this.SpawnImpactEffect(shooter);

            if (this.IsDead) {
                this.Explode();
            }
        }

        private void DecreaseHealth() {
            this._currentHealth -= 1;
        }

        private void SpawnImpactEffect(GameObject shooter) {
            if (this._impactEffect != null && this._impactEffectPosition != null) {
                Vector3 directionToShooter = (shooter.transform.position - this._impactEffectPosition.transform.position).normalized;
                Vector3 spawnPosition = this.transform.position + directionToShooter;
                GameObject.Instantiate(this._impactEffect, spawnPosition, Quaternion.identity);
            }
        }

        private void Explode() {
            if (this._deathExplosion != null) {
                ParticleSystem explosion = GameObject.Instantiate(this._deathExplosion, this.transform.position, Quaternion.identity);
                explosion.gameObject.layer = this.gameObject.layer;
            }
            this._onKilled.Invoke();

            GameObject.Destroy(this.gameObject);
        }

        private bool IsDead => this._currentHealth <= 0;
    }
}