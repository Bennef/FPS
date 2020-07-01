using UnityEngine;

public class LaserShot : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private GameObject _hitParticles;
    private AudioSource _aSrc;

    void Update()
    {
        _aSrc = GetComponent<AudioSource>();
        transform.position += transform.up * Time.deltaTime * _movementSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _aSrc.Play();
        //Instantiate(_hitParticles, collision.GetContact);
    }
}
