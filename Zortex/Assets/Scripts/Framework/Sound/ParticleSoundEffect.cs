using UnityEngine;

namespace Assets.Scripts.Framework.Sound {
    [RequireComponent(typeof(ParticleSystem))]
    [RequireComponent(typeof(AudioSource))]
    public class ParticleSoundEffect : MonoBehaviour {
        [SerializeField] private AudioClip _onEmitSoundEffect;

        private ParticleSystem _particleSystem;
        private AudioSource _audioSource;

        private int _lastNumberOfParticles = 0;

        void Start () {
            this._particleSystem = this.GetComponent<ParticleSystem>();
            this._audioSource = this.GetComponent<AudioSource>();
        }

        void Update () {
            if (this.HasParticleSpawnedSinceLastUpdate) {
                this.PlayOnEmitSoundEffect();
            }

            this._lastNumberOfParticles = this._particleSystem.particleCount;
        }

        private void PlayOnEmitSoundEffect() {
            this._audioSource.PlayOneShot(this._onEmitSoundEffect);
        }

        private bool HasParticleSpawnedSinceLastUpdate {
            get { return this._particleSystem.particleCount > this._lastNumberOfParticles; }
        }
    }
}
