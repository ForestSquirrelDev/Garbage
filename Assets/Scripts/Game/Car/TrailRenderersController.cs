using System;
using Game.Input;
using UnityEngine;

namespace Game.Car {
    public class TrailRenderersController : MonoBehaviour {
        [SerializeField] private InputReader _input;
        [SerializeField] private WheelTrailData[] _trails;

        private void Update() {
            foreach (var trail in _trails) {
                trail.TrailRenderer.emitting = _input.AnyBrakePressed && trail.WheelCollider.isGrounded;
            }
        }

        [Serializable]
        private struct WheelTrailData {
            public WheelCollider WheelCollider;
            public TrailRenderer TrailRenderer;
        }
    }
}