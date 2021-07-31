using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

namespace Autohand.Demo{
    public class OpenXRTeleporterLink : MonoBehaviour{
        public Teleporter hand;
        public InputActionProperty startTeleportAction;
        public InputActionProperty finishTeleportAction;
        
        bool teleporting = false;

        void Start() {
            startTeleportAction.action.Enable();
            startTeleportAction.action.performed += StartTeleportAction;
            finishTeleportAction.action.Enable();
            finishTeleportAction.action.performed += FinishTeleportAction;
        }

        void StartTeleportAction(InputAction.CallbackContext a) {
            if(!teleporting){
                hand.StartTeleport();
                teleporting = true;
            }
        }

        void FinishTeleportAction(InputAction.CallbackContext a) {
            if(teleporting){
                hand.Teleport();
                teleporting = false;
            }
        }
    }
}
