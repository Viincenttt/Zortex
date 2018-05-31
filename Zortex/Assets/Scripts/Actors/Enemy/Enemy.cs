using Assets.Scripts.Framework;
using Assets.Scripts.Framework.Sets;
using UnityEngine;

namespace Assets.Scripts.Actors.Enemy {
    [SelectionBase]
    [RequireComponent(typeof(HealthSystem))]
    public abstract class Enemy : MonoBehaviour {
        [SerializeField] private GameObjectRuntimeSet _runtimeSet;

        protected GameObject Player { get; private set; }
        protected HealthSystem HealthSystem { get; set; }
        
        protected virtual void Start() {
            this.Player = GameObject.FindGameObjectWithTag(KnownTags.Player);
            this.HealthSystem = this.GetComponent<HealthSystem>();
        }

        public void MoveTowardsPlayer(float movementSpeed) {
            this.transform.position += this.transform.forward * movementSpeed * Time.deltaTime;
        }

        public void RotateTowardsPlayer(float rotationSpeed) {
            Vector3 directionToPlayer = (this.Player.transform.position - this.transform.position).normalized;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionToPlayer), rotationSpeed * Time.deltaTime);
        }

        private void OnEnable() {
            this._runtimeSet.Add(this.gameObject);
        }

        private void OnDisable() {
            this._runtimeSet.Remove(this.gameObject);
        }
    }
}