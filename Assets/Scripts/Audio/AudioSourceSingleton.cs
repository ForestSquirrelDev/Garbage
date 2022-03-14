using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audio {
    public class AudioSourceSingleton : MonoBehaviour {
        public static AudioSourceSingleton Instance => _instance;
        [field: SerializeField] public AudioSource BackgroundMusicSource { get; private set; }
        [field: SerializeField] public AudioSource ClipsSource { get; private set; }
        
        [SerializeField] private AudioClip[] _backgroundMusic;
        
        private static AudioSourceSingleton _instance;
        private List<AudioClip> _clips = new List<AudioClip>();
        private Coroutine _loopedSongsRoutine;

        private void Awake() {
            _instance = this;
        }

        public static void PlayClipOneShot(AudioClip clip) {
            _instance.ClipsSource.PlayOneShot(clip);
        }

        public static void PlayRandomSongsLooped() {
            if (_instance._loopedSongsRoutine != null) return;
            _instance._loopedSongsRoutine = _instance.StartCoroutine(_instance.PlayRandomSongsRoutine());
        }

        public static void PauseMusic() {
            _instance.BackgroundMusicSource.Pause();
        }

        public static void ResumeMusic() {
            _instance.BackgroundMusicSource.UnPause();
        }

        public static void SetGeneralVolume(float value) {
            _instance.BackgroundMusicSource.volume = value;
            _instance.ClipsSource.volume = value;
        }

        private IEnumerator PlayRandomSongsRoutine() {
            while (true) {
                _clips.AddRange(_backgroundMusic);
                _clips = _clips.OrderBy(clip => Random.Range(1, 100)).ToList();
                for (var i = 0; i < _clips.Count; i++) {
                    var clip = _clips[i];
                    BackgroundMusicSource.clip = clip;
                    BackgroundMusicSource.Play(0);
                    _clips.Remove(clip);
                    yield return new WaitForSeconds(clip.length);
                }
                yield return null;
            }
        }
    }
}