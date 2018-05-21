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
            this.SetGunEmissionModuleEnabled(false);
        }

        private void StartFiring() {
            this.SetGunEmissionModuleEnabled(true);
        }

        private void SetGunEmissionModuleEnabled(bool enabled) {
            // We can't use ParticleSystem.Stop/Start for this, because this will wait untill all particles have died before
            // starting the particlesystem. A quick fix for this to enable/disable the emissionmodule of the particle system.
            ParticleSystem.EmissionModule emissionModule = this._gun.emission;
            emissionModule.enabled = enabled;
        }
    }
}