using UnityEngine;

namespace Assets.Scripts.Actors.Enemy.Behaviour {
    [CreateAssetMenu(menuName = "Enemy/Behaviour/SelfDestructEnemy")]
    public class SelfDestructEnemy : BaseEnemyBehaviour {
        [SerializeField] private float _rotationSpeed = 3f;
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _selfDestructRange = 10f;

        public override void UpdateState(Enemy enemy) {
            if (this.IsInSelfDestructRange(enemy)) {
                this.SelfDestruct(enemy);
            }
            else {
                enemy.RotateTowardsPlayer(this._rotationSpeed);
                enemy.MoveTowardsPlayer(this._movementSpeed);
            }
        }
        
        private void SelfDestruct(Enemy enemy) {
            enemy.Die();
        }

        private bool IsInSelfDestructRange(Enemy enemy) {
            float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.Player.transform.position);
            return distanceToPlayer <= this._selfDestructRange;
        }
    }
}
