using Assets.Scripts.Framework.Extensions;
using UnityEngine;

namespace Assets.Scripts.Actors.Enemy {
    public class SelfDestructEnemy : Enemy {
        [SerializeField] private float _rotationSpeed = 3f;
        [SerializeField] private float _movementSpeed = 1.25f;
        [SerializeField] private float _selfDestructRange = 0.25f;

        protected void Update() {
            if (this.Player.IsDestroyed()) {
                return;
            }

            if (this.IsInSelfDestructRange()) {
                this.SelfDestruct();
            }
            else {
                this.RotateTowardsPlayer(this._rotationSpeed);
                this.MoveTowardsPlayer(this._movementSpeed);
            }
        }
        
        private void SelfDestruct() {
            this.HealthSystem.Die();
        }

        private bool IsInSelfDestructRange() {
            float distanceToPlayer = Vector3.Distance(this.transform.position, this.Player.transform.position);
            return distanceToPlayer <= this._selfDestructRange;
        }
    }
}
