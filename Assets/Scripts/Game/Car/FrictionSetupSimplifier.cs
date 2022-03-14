using EasyButtons;
using UnityEngine;

namespace Game.Car {
    /// <summary>
    /// Injects curves into sideways freection fields of wheel colliders.
    /// </summary>
    public class FrictionSetupSimplifier : MonoBehaviour {
        [SerializeField, Range(0, 2f)] private float _forwardFriction;
        [SerializeField, Range(0, 2f)] private float _sidewaysFriction;
        [SerializeField] private float _spring = 75000f;
        
        [Button]
        private void SetupWheelColliders() {
            WheelCollider[] wheels = GetComponentsInChildren<WheelCollider>();
            foreach (var wheelCollider in wheels) {
                WheelFrictionCurve curve = wheelCollider.forwardFriction;
                JointSpring spring = wheelCollider.suspensionSpring;

                curve.asymptoteValue = _forwardFriction;
                wheelCollider.forwardFriction = curve;

                curve.asymptoteValue = _sidewaysFriction;
                wheelCollider.sidewaysFriction = curve;

                spring.spring = _spring;
                wheelCollider.suspensionSpring = spring;
            }
        }
    }
}