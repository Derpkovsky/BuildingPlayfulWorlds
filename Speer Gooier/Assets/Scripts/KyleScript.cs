using UnityEngine;
using System.Collections;

public class KyleScript : MonoBehaviour
{
    Rigidbody[] rigRigidbodies;
    Collider[] rigColliders;

    private void Start()
    {
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();
        rigColliders = GetComponentsInChildren<Collider>();
    }

    private void Update()
    {
        foreach (Rigidbody rb in rigRigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Spear")
        {
            foreach (Rigidbody rb in rigRigidbodies)
            {
                rb.isKinematic = false;
            }

        }
    }
}
