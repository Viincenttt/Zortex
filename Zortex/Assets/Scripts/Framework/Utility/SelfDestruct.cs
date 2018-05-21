using UnityEngine;

namespace Assets.Scripts.Framework.Utility {
    public class SelfDestruct : MonoBehaviour {
        [SerializeField] private float _timeBeforeSelfDestruct;

        private void Start() {
            GameObject.Destroy(this.gameObject, this._timeBeforeSelfDestruct);
        }
    }
}