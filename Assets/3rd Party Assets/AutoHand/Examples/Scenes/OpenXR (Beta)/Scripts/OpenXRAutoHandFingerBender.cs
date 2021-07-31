using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Autohand.Demo{
    public class OpenXRAutoHandFingerBender : MonoBehaviour{
        public Hand hand;
        public InputActionProperty bendAction;
        public InputActionProperty unbendAction;
        
        [HideInInspector]
        public float[] bendOffsets;

        bool pressed;

        private void Start() {
            bendAction.action.Enable();
            bendAction.action.performed += BendAction;
            unbendAction.action.Enable();
            unbendAction.action.performed += UnbendAction;
        }

        void BendAction(InputAction.CallbackContext a) {
            for(int i = 0; i < hand.fingers.Length; i++) {
                hand.fingers[i].bendOffset += bendOffsets[i];
            }
        }

        void UnbendAction(InputAction.CallbackContext a) {
            for(int i = 0; i < hand.fingers.Length; i++) {
                hand.fingers[i].bendOffset -= bendOffsets[i];
            }
        }
    }
}
