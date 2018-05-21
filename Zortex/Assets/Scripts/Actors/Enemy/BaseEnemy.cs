using Assets.Scripts.Framework.Sets;
using UnityEngine;

namespace Assets.Scripts.Actors.Enemy {
    public abstract class BaseEnemy : MonoBehaviour {
        [SerializeField] protected GameObjectRuntimeSet _runtimeSet;
        protected GameObject Player { get; private set; }
        
        protected virtual void Start() {
            this.Player = GameObject.FindGameObjectWithTag("Player");
        }

        private void OnEnable() {
            this._runtimeSet.Add(this.gameObject);
        }

        private void OnDisable() {
            this._runtimeSet.Remove(this.gameObject);
        }
    }
}