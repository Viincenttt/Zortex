using Assets.Scripts.Framework.Extensions;
using UnityEngine;

namespace Assets.Scripts.Actors.Enemy {
    public class ShootingEnemy : Enemy {
        [SerializeField] private float _rotationSpeed = 3f;

        protected void Update() {
            if (this.Player.IsDestroyed()) {
                return;
            }

            this.RotateTowardsPlayer(this._rotationSpeed);
        }
    }
}