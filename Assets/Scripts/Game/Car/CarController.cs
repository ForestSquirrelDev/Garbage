using Game.Configs;
using Game.Input;
using UnityEngine;

namespace Game.Car {
    public class CarController : MonoBehaviour {
        [SerializeField] private CarConfig _config;
        [SerializeField] private WheelCollider[] _wheels;
        [SerializeField] private InputReader _input;

        private void FixedUpdate() {
            foreach (var wheel in _wheels) {
                wheel.motorTorque = _input.AxisVertical * _config.Torque;
                wheel.brakeTorque = _input.SpaceBarPressed * _config.BrakeTorque;
            }
            for (int i = 2; i < _wheels.Length; i++) {
                _wheels[i].steerAngle = _input.AxisHorizontal * _config.SteerAngle;
            }
        }
    }
}
