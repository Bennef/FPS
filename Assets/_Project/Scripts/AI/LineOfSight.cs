using UnityEngine;

namespace Scripts.AI
{
    public class LineOfSight : MonoBehaviour
    {
        [SerializeField] private bool canSeePlayer;

        public bool CanSeePlayer { get; set; }

        void Update() => CheckForPLayer();

        void CheckForPLayer()
        {
            Vector3 DirectionRay = transform.TransformDirection(Vector3.forward * 100);
            Debug.DrawRay(transform.position, DirectionRay, Color.blue);
            RaycastHit Hit;
            if (Physics.Raycast(transform.position, DirectionRay, out Hit))
            {
                if (Hit.collider.CompareTag("Player"))
                {
                    CanSeePlayer = true;
                }
                else
                {
                    CanSeePlayer = false;
                }
            }
        }
    }
}