using Scripts.Inputs;
using UnityEngine;

namespace Scripts.Shooting
{        
    public class Gun : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private AudioSource _aSrc;
        private ParticleSystem _muzzleFlash;
        [SerializeField] private Transform _laserOrigin;
        [SerializeField] private GameObject _laserShot;

        void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
            _aSrc = GetComponent<AudioSource>();
            _muzzleFlash = GetComponentInChildren<ParticleSystem>();
        }

        void Update()
        {
            if (_inputHandler.GetShootButton())
                Shoot();
        }

        private void Shoot()
        {
            _aSrc.Play();
            Instantiate(_laserShot, _laserOrigin.position, _laserOrigin.rotation * Quaternion.Euler(90, 0, 0));
            _muzzleFlash.Play();
        }
    }
}