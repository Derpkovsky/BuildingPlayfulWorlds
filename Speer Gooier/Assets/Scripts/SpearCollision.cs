using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpearCollision : MonoBehaviour
{

    public GameObject spearObject;
    public Rigidbody spear;
    public bool playerCloseEnough = false;
    public bool vincentHit;

    private Vector3 scale;

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

        //Debug.Log(transform.localScale);
    }

    

    //Zorgt dat de speer stilstaat als hij een StickWall raakt
    private void OnCollisionEnter(Collision other)
    {
        if ( other.gameObject.tag == "target")
        {
            spear.isKinematic = true;
            GetComponent<Transform>().SetParent(other.gameObject.transform);
            //transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowSpear>().spearRotation;
        }

        if (other.gameObject.tag == "stickWall")
        {
            spear.isKinematic = true;
            transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowSpear>().spearRotation;
        }
        if (other.gameObject.tag == "Vincent")
        {
            vincentHit = true;
        }
    }
}

