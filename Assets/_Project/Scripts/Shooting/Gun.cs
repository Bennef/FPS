using Scripts.Inputs;
using UnityEngine;

namespace Scripts.Shooting
{        
    public class Gun : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private AudioSource _aSrc;
        [SerializeField] private Transform _laserOrigin;
        [SerializeField] private GameObject _laserShot;

        void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
            _aSrc = GetComponent<AudioSource>();
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
        }
    }
}