using UnityEngine;

namespace Scripts.Environment
{
    public class RedBarrel : MonoBehaviour
    {
        [SerializeField] private GameObject _explosion;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Laser Shot"))
                Explode();
        }

        void Explode()
        {
            GameObject tmp = Instantiate<GameObject>(_explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}