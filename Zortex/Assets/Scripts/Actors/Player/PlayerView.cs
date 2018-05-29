using System.Collections;
using System.Linq;
using Assets.Scripts.Framework.Sets;
using UnityEngine;

namespace Assets.Scripts.Actors.Player {
    [SelectionBase]
    public class PlayerView : MonoBehaviour {
        [SerializeField] private GameObjectRuntimeSet _targetSet;
        [SerializeField] private float _viewRadius = 20f;
        [SerializeField] [Range(0, 360)] private float _viewAngle = 30f;
        [SerializeField] [Range(0.01f, 1)] private float _delayBetweenScans = 0.25f;

        public GameObject VisibleTarget { get; set; }

        private void Start() {
            this.StartCoroutine(this.FindClosestVisibleEnemyWithDelay());
        }

        private IEnumerator FindClosestVisibleEnemyWithDelay() {
            while (true) {
                this.VisibleTarget = this.FindClosestVisibleEnemy();
                yield return new WaitForSeconds(this._delayBetweenScans);
            }
        }

        private GameObject FindClosestVisibleEnemy() {
            foreach (GameObject target in this._targetSet.Items.OrderBy(x => Vector3.Distance(x.transform.position, this.transform.position))) {
                if (this.IsEnemyInView(target)) {
                    return target;
                }
            }

            return null;
        }

        private bool IsEnemyInView(GameObject target) {
            if (!this.IsEnemyInRange(target)) {
                return false;
            }

            Vector3 directionToTarget = (target.transform.position - this.transform.position).normalized;
            float angleToTarget = Vector3.Angle(this.transform.forward, directionToTarget);
            return angleToTarget <= this._viewAngle / 2;
        }

        private bool IsEnemyInRange(GameObject target) {
            return Vector3.Distance(this.transform.position, target.transform.position) <= this._viewRadius;
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.green;

            float positiveAngle = this._viewAngle / 2;
            float negativeAngle = -positiveAngle;
            
            // Draw the left/right view angles
            this.DrawAngleGizmoView(positiveAngle, this.transform.up);
            this.DrawAngleGizmoView(negativeAngle, this.transform.up);

            // Draw the upper/lower view angles
            this.DrawAngleGizmoView(positiveAngle, this.transform.right);
            this.DrawAngleGizmoView(negativeAngle, this.transform.right);
        }

        private void DrawAngleGizmoView(float angle, Vector3 axis) {
            Quaternion angleAxis = Quaternion.AngleAxis(angle, axis);
            Vector3 lineEndPoint = angleAxis * (this.transform.forward * this._viewRadius) + this.transform.position;
            
            Gizmos.DrawLine(this.transform.position, lineEndPoint);
        }
    }
}