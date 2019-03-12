using UnityEngine;
using System.Collections;
using UnityEngine.Accessibility;

public class KyleScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private bool spearHit;
    private Vector3 spearSpeed;
    private bool vision = false;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Spear")
        {
            spearHit = true;
        }
        
    }

    void Update()
    {
        Vector3 targetDir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        if (spearHit == true)
        {
            //GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            //GetComponent<Rigidbody>().isKinematic = true;
            if (vision == true)
            {
                Debug.Log(vision);
                transform.rotation = Quaternion.LookRotation(newDir);
                transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, Time.deltaTime * moveSpeed);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vision = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vision = false;
        }
    }
}
