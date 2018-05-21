using UnityEngine;

namespace Assets.Scripts.Actors.Enemy.Behaviour {
    [CreateAssetMenu(menuName = "Enemy/Behaviour/ShootingEnemy")]
    public class ShootingEnemy : BaseEnemyBehaviour {
        [SerializeField] private float _rotationSpeed = 3f;

        public override void UpdateState(Enemy enemy) {
            enemy.RotateTowardsPlayer(this._rotationSpeed);
        }
    }
}