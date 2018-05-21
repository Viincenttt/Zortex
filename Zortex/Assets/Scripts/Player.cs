using UnityEngine;

namespace Assets.Scripts {
    [SelectionBase]
    public class Player : MonoBehaviour {
        [SerializeField] private float _viewRadius = 20f;
        [SerializeField] [Range(0, 360)] private float _viewAngle = 30f;
        
        private void Start() { }

        private void Update() { }

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