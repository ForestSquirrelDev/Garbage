using UnityEngine;
using UnityEngine.UI;

namespace Audio {
    public class VolumeSlider : MonoBehaviour {
        private Slider _slider;

        private void Awake() {
            _slider = GetComponent<Slider>();
        }

        private void Update() {
            AudioSourceSingleton.SetGeneralVolume(_slider.value);
        }
    }
}