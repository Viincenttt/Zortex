using Assets.Scripts.Actors.Enemy.Behaviour;
using Assets.Scripts.Framework;
using Assets.Scripts.Framework.Extensions;
using Assets.Scripts.Framework.Sets;
using UnityEngine;

namespace Assets.Scripts.Actors.Enemy {
    [SelectionBase]
    public class Enemy : MonoBehaviour {
        [SerializeField] private GameObjectRuntimeSet _runtimeSet;
        [SerializeField] private GameObject _deathExplosion;
        [SerializeField] public BaseEnemyBehaviour _behaviour;

        public GameObject Player { get; private set; }
        
        private void Start() {
            this.Player = GameObject.FindGameObjectWithTag(KnownTags.Player);
        }

        private void Update() {
            if (!this.Player.IsDestroyed()) {
                this._behaviour.UpdateState(this);
            }
        }

        public void MoveTowardsPlayer(float movementSpeed) {
            this.transform.position += this.transform.forward * movementSpeed * Time.deltaTime;
        }

        public void RotateTowardsPlayer(float rotationSpeed) {
            Vector3 directionToPlayer = (this.Player.transform.position - this.transform.position).normalized;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionToPlayer), rotationSpeed * Time.deltaTime);
        }

        public void Die() {
            if (this._deathExplosion != null) {
                GameObject.Instantiate(this._deathExplosion, this.transform.position, Quaternion.identity);
            }

            GameObject.Destroy(this.gameObject);
        }

        private void OnEnable() {
            this._runtimeSet.Add(this.gameObject);
        }

        private void OnDisable() {
            this._runtimeSet.Remove(this.gameObject);
        }
    }
}