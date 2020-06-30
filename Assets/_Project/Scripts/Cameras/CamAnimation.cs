using UnityEngine;
using Scripts.Inputs;

namespace Scripts.Cameras
{
    public class CamAnimation : MonoBehaviour
    {
        [SerializeField] private Animation _anim; //Empty GameObject's animation component

        public bool left;
        public bool right;

        private CharacterController playerController;
        private InputHandler _inputHandler;

        void Start()
        {
            playerController = FindObjectOfType<CharacterController>();
            _inputHandler = FindObjectOfType<InputHandler>();
            left = true;
            right = false;
        }

        void Update()
        {
            if (_inputHandler.GetRunButtonDown())
            {
                _anim["walkLeft"].speed = 2f;
                _anim["walkRight"].speed = 2f;
            }
            else
            {
                _anim["walkLeft"].speed = 1f;
                _anim["walkRight"].speed = 1f;
            }
            CameraAnimations();
        }

        void CameraAnimations()
        {
            if (playerController.isGrounded == true && _inputHandler.PlayerIsWalking())
            {
                if (left == true)
                {
                    if (!_anim.isPlaying)
                    {//Waits until no animation is playing to play the next
                        _anim.Play("walkLeft");
                        left = false;
                        right = true;
                    }
                }
                if (right == true)
                {
                    if (!_anim.isPlaying)
                    {
                        _anim.Play("walkRight");
                        right = false;
                        left = true;
                    }
                }
            }
        }
    }
}