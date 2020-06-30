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

        public bool GetShootButtonDown() => Input.GetButton("Shopt");

        public bool GetReloadButtonDown() => Input.GetButtonDown("Reload");

        public bool GetInteractButtonDown() => Input.GetButtonDown("Interact");

        internal float getHorizontalAxis() => Input.GetAxis("Horizontal");

        internal float getVerticalAxis() => Input.GetAxis("Vertical");
    }
}