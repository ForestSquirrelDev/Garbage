using UnityEngine;

namespace Game.Car {
    public class WheelsTransformRotator : MonoBehaviour {
        private WheelCollider[] _wheels;

        private void Awake() {
            _wheels = GetComponentsInChildren<WheelCollider>();
        }

        private void FixedUpdate() {
            foreach (var wheelCollider in _wheels) {
                wheelCollider.GetWorldPose(out _, out Quaternion quaternion);
                wheelCollider.transform.GetChild(0).rotation = quaternion;
            }
        }
    }
}