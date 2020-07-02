using System.Collections;
using UnityEngine;

namespace Scripts.Shooting
{
    public class LaserShot : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private GameObject _hitParticles;

        private void Start()
        {
            StartCoroutine(AutoDestruct());
        }

        void Update()
        {
            transform.position += transform.up * Time.deltaTime * _movementSpeed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject tmp = Instantiate<GameObject>(_hitParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        IEnumerator AutoDestruct()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}