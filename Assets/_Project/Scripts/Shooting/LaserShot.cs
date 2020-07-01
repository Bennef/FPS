using UnityEngine;

public class LaserShot : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * _movementSpeed;
    }
}
