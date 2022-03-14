using UnityEngine;
using UnityEngine.UI;

namespace Audio {
    public class SingleClipButtonAudioObserver : AudioObserver<Button> {
        [SerializeField] private AudioClip _clip;
        
        protected override void Awake() {
            base.Awake();
            _observable.onClick.AddListener(PlayClip);
        }

        private void PlayClip() {
            PlayOneShot(_clip);
        }

        private void OnDestroy() {
            _observable.onClick.RemoveAllListeners();
        }
    }
}