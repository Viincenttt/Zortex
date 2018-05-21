using System.Collections;
using System.Linq;
using Assets.Scripts.Actors.Enemy;
using Assets.Scripts.Framework.Sets;
using UnityEngine;

namespace Assets.Scripts.Actors.Player {
    [SelectionBase]
    public class PlayerView : MonoBehaviour {
        [SerializeField] private EnemyRuntimeSet _enemySet;
        [SerializeField] private float _viewRadius = 20f;
        [SerializeField] [Range(0, 360)] private float _viewAngle = 30f;
        [SerializeField] private float _delayBetweenScans = 0.25f;

        public BaseEnemy VisibleTarget { get; set; }

        private void Start() {
            this.StartCoroutine(this.FindClosestVisibleEnemyWithDelay());
        }

        private IEnumerator FindClosestVisibleEnemyWithDelay() {
            while (true) {
                this.VisibleTarget = this.FindClosestVisibleEnemy();
                yield return new WaitForSeconds(this._delayBetweenScans);
            }
        }

        private BaseEnemy FindClosestVisibleEnemy() {
            foreach (BaseEnemy enemy in this._enemySet.Items.OrderBy(x => Vector3.Distance(x.transform.position, this.transform.position))) {
                if (this.IsEnemyInView(enemy)) {
                    return enemy;
                }
            }

            return null;
        }

        private bool IsEnemyInView(BaseEnemy enemy) {
            if (!this.IsEnemyInRange(enemy)) {
                return false;
            }

            Vector3 directionToTarget = (enemy.transform.position - this.transform.position).normalized;
            float angleToTarget = Vector3.Angle(this.transform.forward, directionToTarget);
            return angleToTarget <= this._viewAngle / 2;
        }

        private bool IsEnemyInRange(BaseEnemy enemy) {
            return Vector3.Distance(this.transform.position, enemy.transform.position) <= this._viewRadius;
        }

        private void OnDrawGizmos() {
            float rightAngle = this._viewAngle / 2;
            float leftAngle = -this._viewAngle / 2;

            this.DrawAngleGizmoView(rightAngle);
            this.DrawAngleGizmoView(leftAngle);
        }

        private void DrawAngleGizmoView(float angle) {
            Quaternion angleAxis = Quaternion.AngleAxis(angle, this.transform.up);
            Vector3 lineEndPoint = angleAxis * (this.transform.forward * this._viewRadius) + this.transform.position;

            Gizmos.DrawLine(this.transform.position, lineEndPoint);
        }
    }
}