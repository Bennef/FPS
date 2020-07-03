using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField] private bool canSeePlayer;
    private Transform _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        CheckForPLayer();
    }

    void CheckForPLayer()
    {
        Vector3 DirectionRay = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, DirectionRay, Color.blue);
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, DirectionRay, out Hit))
        {
            if (Hit.collider.CompareTag("Player"))
            {
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
    }
}