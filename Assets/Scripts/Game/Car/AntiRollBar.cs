using Game.Configs;
using UnityEngine;

namespace Game.Car {
    public class AntiRollBar : MonoBehaviour {
        [SerializeField] private WheelCollider _wheelLeft, _wheelRight;
        [SerializeField] private CarConfig _config;

        private Rigidbody _rb;

        private void Awake() {
            _rb = GetComponentInParent<Rigidbody>();
        }

        private void FixedUpdate() {
            float travelLeft = 1.0f;
            float travelRight = 1.0f;

            bool groundedLeft = _wheelLeft.GetGroundHit(out WheelHit hitLeft);
            if (groundedLeft) {
                travelLeft = (-_wheelLeft.transform.InverseTransformPoint(hitLeft.point).y - _wheelLeft.radius) / _wheelLeft.suspensionDistance;
            }

            bool groundedRight = _wheelRight.GetGroundHit(out WheelHit hitRight);
            if (groundedRight) {
                travelRight = (-_wheelRight.transform.InverseTransformPoint(hitRight.point).y - _wheelRight.radius) / _wheelRight.suspensionDistance;
            }

            float antiRollForce = (travelLeft - travelRight) * _config.AntiRoll;
            if (groundedLeft) {
                _rb.AddForceAtPosition(_wheelLeft.transform.up * -antiRollForce, _wheelLeft.transform.position);
            }
            if (groundedRight) {
                _rb.AddForceAtPosition(_wheelRight.transform.up * antiRollForce, _wheelRight.transform.position);
            }
        }
    }
}