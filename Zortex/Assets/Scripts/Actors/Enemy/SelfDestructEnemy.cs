using UnityEngine;

namespace Assets.Scripts.Actors.Enemy {
    [SelectionBase]
    public class SelfDestructEnemy : BaseEnemy {
        [SerializeField] private float _rotationSpeed = 3f;
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _selfDestructRange = 10f;

        protected override void Start () {
		    base.Start();
        }

        void Update () {
            if (this.IsInSelfDestructRange) {
                this.SelfDestruct();
            }
            else {
                this.RotateTowardsPlayer();
                this.MoveTowardsPlayer();
            }
        }

        private void RotateTowardsPlayer() {
            Vector3 directionToPlayer = (this.Player.transform.position - this.transform.position).normalized;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionToPlayer), this._rotationSpeed * Time.deltaTime);
        }

        private void MoveTowardsPlayer() {
            this.transform.position += this.transform.forward * this._movementSpeed * Time.deltaTime;
        }

        private void SelfDestruct() {
            Debug.Log("Boom");

            // TODO: Spawn explosion particle effect and destroy gameobject
        }

        private bool IsInSelfDestructRange {
            get {
                float distanceToPlayer = Vector3.Distance(this.transform.position, this.Player.transform.position);
                return distanceToPlayer <= this._selfDestructRange;
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, this._selfDestructRange);
        }
    }
}
