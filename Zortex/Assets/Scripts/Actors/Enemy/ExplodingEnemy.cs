using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors.Enemy {
    public class ExplodingEnemy : Enemy {
        [Header("Explosion")]
        [SerializeField] private float _explodeAfterSeconds = 10f;
        [SerializeField] private ParticleSystem _bulletExplosion;

        [Header("Rotation speed")]
        [SerializeField] private float _rotationSpeedIncrementX = 0.0005f;
        [SerializeField] private float _rotationSpeedIncrementY = 0.005f;
        [SerializeField] private float _rotationSpeedIncrementZ = 0.0005f;

        private float _currentRotationSpeedX = 0f;
        private float _currentRotationSpeedY = 0f;
        private float _currentRotationSpeedZ = 0f;

        protected override void Start() {
            base.Start();

            this.StartCoroutine(this.CountdownToSelfDestruct());
        }

        protected void Update() {
            this._currentRotationSpeedX += this._rotationSpeedIncrementX;
            this._currentRotationSpeedY += this._rotationSpeedIncrementY;
            this._currentRotationSpeedZ += this._rotationSpeedIncrementZ;

            this.transform.Rotate(new Vector3(this._currentRotationSpeedX, this._currentRotationSpeedY, this._currentRotationSpeedZ));
        }

        protected IEnumerator CountdownToSelfDestruct() {
            yield return new WaitForSeconds(this._explodeAfterSeconds);

            this.SpawnBulletExplosion();
            this.HealthSystem.Die();
        }

        private void SpawnBulletExplosion() {
            GameObject.Instantiate(this._bulletExplosion, this.transform.position, Quaternion.identity);
        }
    }
}