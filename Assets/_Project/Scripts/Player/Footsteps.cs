using UnityEngine;

namespace Scripts.Player
{
    public class Footsteps : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _footsteps;

        private AudioSource _aSrc;
        private AudioClip _footstepClipToPlay;

        void Start() => _aSrc = GetComponent<AudioSource>();

        void PlayFootstepSound()
        {
            print("s");
            int index = Random.Range(0, _footsteps.Length);
            _footstepClipToPlay = _footsteps[index];
            _aSrc.clip = _footstepClipToPlay;
            _aSrc.Play();
        }
    }
}