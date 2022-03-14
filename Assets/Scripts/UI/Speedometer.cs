using System.Globalization;
using Game.Car;
using TMPro;
using UnityEngine;

namespace UI {
    public class Speedometer : MonoBehaviour {
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private CarController _car;

        private void Update() {
            _speedText.text = ToKmph(_car.GetMotorInfo().Speed).ToString("0", CultureInfo.InvariantCulture) + " km/h";
        }

        private float ToKmph(float magnitude) {
            return ((magnitude / 1000) * 60) * 60 * 0.62f;
        }
    }
}