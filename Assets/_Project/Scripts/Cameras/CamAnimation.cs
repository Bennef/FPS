using UnityEngine;
using Scripts.Inputs;

namespace Scripts.Cameras
{
    public class CamAnimation : MonoBehaviour
    {
        [SerializeField] private Animation _anim; //Empty GameObject's animation component
        [SerializeField] private AudioClip[] _footsteps;

        public bool left;
        public bool right;

        private CharacterController playerController;
        private InputHandler _inputHandler;
        private AudioSource _aSrc;
        private AudioClip _footstepClipToPlay;

        void Start()
        {
            playerController = FindObjectOfType<CharacterController>();
            _inputHandler = FindObjectOfType<InputHandler>();
            _aSrc = GetComponent<AudioSource>();
            left = true;
            right = false;
        }

        void Update()
        {
            if (_inputHandler.GetRunButtonDown())
            {
                _aSrc.volume = 0.8f;
                _anim["walkLeft"].speed = 1.5f;
                _anim["walkRight"].speed = 1.5f;
            }
            else
            {
                _aSrc.volume = 0.4f;
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
                    {  //Waits until no animation is playing to play the next
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

        void PlayFootstepSound() 
        {
            int index = Random.Range(0, _footsteps.Length);
            _footstepClipToPlay = _footsteps[index];
            _aSrc.clip = _footstepClipToPlay;
            _aSrc.Play();
        }
    }
}