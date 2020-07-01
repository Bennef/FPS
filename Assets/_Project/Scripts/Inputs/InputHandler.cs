using System;
using UnityEngine;

namespace Scripts.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public bool GetBackwardButtonDown() => Input.GetButton("Backward");

        public bool GetForwardButtonDown() => Input.GetButton("Forward");

        public bool GetLeftButtonDown() => Input.GetButton("Strafe Left");

        public bool GetRighttButtonDown() => Input.GetButton("Strafe Right");

        public bool GetJumpButton() => Input.GetButton("Jump");
        
        public bool GetRunButtonDown() => Input.GetButton("Run");

        public bool GetCrouchButtonDown() => Input.GetButton("Crouch");

        public bool GetShootButton() => Input.GetButtonDown("Shoot");

        public bool GetReloadButton() => Input.GetButtonDown("Reload");

        public bool GetInteractButton() => Input.GetButtonDown("Interact");

        public float GetHorizontalAxis() => Input.GetAxis("Horizontal");

        public float GetVerticalAxis() => Input.GetAxis("Vertical");

        public float GetMouseX() => Input.GetAxis("Mouse X");

        public float GetMouseY() => Input.GetAxis("Mouse Y");

        public bool PlayerIsWalking()
        {
            if (GetHorizontalAxis() != 0 || GetVerticalAxis() != 0)
                return true;

            return false;
        }
    }
}