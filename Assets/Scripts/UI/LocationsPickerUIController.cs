using System;
using Game.Management;
using UnityEngine;
using UnityEngine.UI;

namespace Ui {
    public class LocationsPickerUIController : MonoBehaviour {
        [SerializeField] private UILocationData[] _locationDatas;
        [SerializeField] private LocationsPicker _picker;

        private void Awake() {
            foreach (var locationData in _locationDatas) {
                locationData.Button.onClick.AddListener(() => PickLocation(locationData.Type));
            }
        }

        private void PickLocation(LocationType type) {
            _picker.PickLocation(type);
        }

        private void OnDestroy() {
            foreach (var VARIABLE in _locationDatas) {
                VARIABLE.Button.onClick.RemoveAllListeners();
            }
        }

        [Serializable]
        private struct UILocationData {
            public Button Button;
            public LocationType Type;
        }
    }
}