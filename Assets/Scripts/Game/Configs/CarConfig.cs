using UnityEngine;

namespace Game.Configs {
    [CreateAssetMenu(menuName = "Configs/Car Config")]
    public class CarConfig : ScriptableObject {
        public float Torque = 200;
        public float SteerAngle = 200;
        public float AntiRoll = 5000f;
        public float BrakeTorque = 600f;
    }
}