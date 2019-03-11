using UnityEngine;
using System.Collections;

public class KyleScript : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;


    void Update()
    {
            target.localPosition = Vector3.MoveTowards(transform.localPosition, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, Time.deltaTime * moveSpeed);
    }
}
