using Game.Input;
using UnityEngine;

namespace Game.Car {
    public class Reviver : MonoBehaviour {
        [SerializeField] private InputReader _input;

        private Vector3 _initialPos;
        private Quaternion _initialRota;
        private Rigidbody _rb;

        private void Awake() {
            SetInitialTransformData();
            _rb = GetComponent<Rigidbody>();
        }

        private void SetInitialTransformData() {
            _initialPos = transform.position;
            _initialRota = transform.rotation;
        }

        private void Update() {
            if (_input.RPressedOnce) {
                transform.position = _initialPos;
                transform.rotation = _initialRota;
                _rb.velocity = Vector3.zero;
                _rb.angularVelocity = Vector3.zero;
            }
        }

        public void ResetInitialTransformData() {
            SetInitialTransformData();
        }
    }
}