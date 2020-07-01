using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private SphereCollider _interactionCollider;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<DoorPanel>() != null)
        print("int");
    }
}
