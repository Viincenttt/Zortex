using UnityEngine;

namespace Assets.Scripts.Actors.Player {
    [RequireComponent(typeof(PlayerView))]
    public class PlayerGun : MonoBehaviour {
        [SerializeField] private ParticleSystem _gun;

        private PlayerView _playerView;

        private void Start() {
            this._playerView = this.GetComponent<PlayerView>();
        }

        private void Update() {
            if (this._playerView.VisibleTarget == null) {
                this.StopFiring();
            }
            else {
                this.AimAtTarget();
                this.StartFiring();
            }
        }

        private void AimAtTarget() {
            this._gun.transform.LookAt(this._playerView.VisibleTarget.transform);
        }

        private void StopFiring() {
            ParticleSystem.EmissionModule emissionModule = this._gun.emission;
            emissionModule.enabled = false;
        }

        private void StartFiring() {
            ParticleSystem.EmissionModule emissionModule = this._gun.emission;
            emissionModule.enabled = true;
        }
    }
}