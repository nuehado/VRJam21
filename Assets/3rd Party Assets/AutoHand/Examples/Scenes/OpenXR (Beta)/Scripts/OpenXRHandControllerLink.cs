using UnityEngine;
using UnityEngine.InputSystem;

namespace Autohand.Demo
{
    public class OpenXRHandControllerLink : MonoBehaviour
    {
        public Hand hand;
        
        public InputActionProperty grabAction;
        public InputActionProperty releaseAction;
        public InputActionProperty squeezeAction;
        public InputActionProperty stopSqueezeAction;
        

        private bool squeezing;
        private bool grabbing;

        public void Start(){
            if (grabAction == squeezeAction){
                Debug.LogError("AUTOHAND: You are using the same button for grab and squeeze on HAND CONTROLLER LINK, this will create conflict or errors", this);
            }
            
            grabAction.action.Enable();
            grabAction.action.performed += Grab;
            releaseAction.action.Enable();
            releaseAction.action.performed += Release;
            squeezeAction.action.Enable();
            squeezeAction.action.performed += Squeeze;
            stopSqueezeAction.action.Enable();
            stopSqueezeAction.action.performed += StopSqueeze;
        }

        private void Update() {
            hand.SetGrip(0);
        }

        private void Grab(InputAction.CallbackContext grab){
            if (!grabbing){
                hand.Grab();
                grabbing = true;
            }
        }
        
        private void Release(InputAction.CallbackContext grab){
            if (grabbing){
                hand.Release();
                grabbing = false;
            }
        }

        private void Squeeze(InputAction.CallbackContext grab){
            hand.SetGrip(grab.ReadValue<float>());

            if (!squeezing){
                hand.Squeeze();
                squeezing = true;
            }
        }
        
        private void StopSqueeze(InputAction.CallbackContext grab){
            if (squeezing){
                hand.Unsqueeze();
                squeezing = false;
            }
        }
        
    }
}
