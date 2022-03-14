using UnityEngine;

namespace Audio {
    public abstract class AudioObserver<T> : MonoBehaviour where T : Component {
        protected T _observable;

        protected virtual void Awake() {
            _observable = GetComponent<T>();
        }

        protected void PlayOneShot(AudioClip clip) {
            AudioSourceSingleton.PlayClipOneShot(clip);
        }
    }
}