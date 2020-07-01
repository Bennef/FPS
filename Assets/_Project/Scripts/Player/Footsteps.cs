using UnityEngine;

namespace Scripts.Player
{
    public class Footsteps : MonoBehaviour
    {
        [SerializeField] private AudioSource _aSrc;
        CharacterController _characterController;
        
        void Start() => _characterController = FindObjectOfType<CharacterController>();

        void Update()
        {
            if (_characterController.isGrounded && _characterController.velocity.magnitude > 2f && !_aSrc.isPlaying)
                _aSrc.Play(); // random clip of footsteps
        }
    }
}