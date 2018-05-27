using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Framework.Sound {
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour {
        [SerializeField] private AudioClip[] _playlist;
        [SerializeField] private float _musicFadeOutTime = 2f;

        private AudioSource _audioSource;

        private void Start() {
            this._audioSource = this.GetComponent<AudioSource>();

            if (this._playlist == null || this._playlist.Length == 0) {
                throw new InvalidOperationException("Musicplayer requires at least one audioclip for it's playlist");
            }

            this.PlayRandomClip();
        }

        private void PlayRandomClip() {
            this._audioSource.Stop();
            AudioClip musicClipToPlay = this.GetRandomAudioClip();
            this._audioSource.clip = musicClipToPlay;
            this._audioSource.Play();
        }

        private AudioClip GetRandomAudioClip() {
            int randomMusicClip = Random.Range(0, this._playlist.Length);
            return this._playlist[randomMusicClip];
        }

        public void FadeOut() {
            this.StartCoroutine(this.FadeOutMusic());
        }

        private IEnumerator FadeOutMusic() {
            float startVolume = this._audioSource.volume;
            while (this._audioSource.volume > 0) {
                this._audioSource.volume -= startVolume * Time.deltaTime / this._musicFadeOutTime;

                yield return new WaitForEndOfFrame();
            }

            this._audioSource.Stop();
            this._audioSource.volume = startVolume;
        }
    }
}
