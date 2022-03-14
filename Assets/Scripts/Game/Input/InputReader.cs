using UnityEngine;

namespace Game.Input {
    public class InputReader : MonoBehaviour {
        public float AxisVertical { get; private set; }
        public float AxisHorizontal { get; private set; }
        public int SpaceBarPressed { get; private set; }
        public bool AnyBrakePressed { get; private set; }
        public bool RPressedOnce { get; private set; }

        private void Update() {
            AxisVertical = UnityEngine.Input.GetAxis("Vertical");
            AxisHorizontal = UnityEngine.Input.GetAxis("Horizontal");
            SpaceBarPressed = UnityEngine.Input.GetKey(KeyCode.Space) ? 1 : 0;

            AnyBrakePressed = UnityEngine.Input.GetKey(KeyCode.S) || UnityEngine.Input.GetKey(KeyCode.Space);
            RPressedOnce = UnityEngine.Input.GetKeyDown(KeyCode.R);
        }
    }
}