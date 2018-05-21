using UnityEngine;

namespace Assets.Scripts.Actors.Enemy {
    [SelectionBase]
    public class ShootingEnemy : BaseEnemy {
        [SerializeField] private float _rotationSpeed = 3f;

        protected override void Start() {
            base.Start();
        }

        void Update() {
            this.RotateTowardsPlayer(this._rotationSpeed);
        }
    }
}