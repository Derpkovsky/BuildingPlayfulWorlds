using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour
{

    public GameObject spearObject;
    public Rigidbody spear;
    private Transform spearSpawn;
    public bool playerCloseEnough = false;
    public bool vincentHit;
    private string spearState;

    private void Start()
    {
        spearSpawn = GameObject.Find("speerspawn").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector3.Distance(spearObject.transform.position, GameObject.Find("FPSController").GetComponent<Transform>().position) < 4)
        {
            playerCloseEnough = true;
        }
        else
        {
            playerCloseEnough = false;
        }
    }

    //Zorgt dat de speer stilstaat als hij een StickWall raakt
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "stickWall")
        {
            GetComponent<Transform>().SetParent(other.gameObject.transform);
            spear.isKinematic = true;
            
            Debug.Log("InTrigger");
        }
        if (other.gameObject.tag == "Vincent")
        {
            vincentHit = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "stickWall")
        {
            Debug.Log("UitTrigger");
        }
    }
}

