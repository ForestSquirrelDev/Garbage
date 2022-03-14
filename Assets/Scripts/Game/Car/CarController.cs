using System;
using Game.Configs;
using Game.Input;
using UnityEngine;

namespace Game.Car {
    public class CarController : MonoBehaviour {
        public Reviver Reviver => GetComponent<Reviver>();
        
        [SerializeField] private CarConfig _config;
        [SerializeField] private WheelCollider[] _wheels;
        [SerializeField] private InputReader _input;

        private Rigidbody _rb;
        
        private void Awake() {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            for (int i = 0; i < _wheels.Length; i++) {
                _wheels[i].motorTorque = _input.AxisVertical * _config.Torque;
            }
            foreach (var wheel in _wheels) {
                wheel.brakeTorque = _input.SpaceBarPressed * _config.BrakeTorque;
            }
            for (int i = 2; i < _wheels.Length; i++) {
                _wheels[i].steerAngle = _input.AxisHorizontal * _config.SteerAngle;
            }
        }

        public MotorInfo GetMotorInfo() {
            return new MotorInfo {
                Speed = _rb.velocity.magnitude
            };
        }

        public void ResetVelocity() {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }

    public struct MotorInfo {
        public float Speed;
    }
}
