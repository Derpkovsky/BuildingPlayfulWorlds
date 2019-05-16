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

        scale = transform.localScale;
    }

    //Zorgt dat de speer stilstaat als hij een StickWall raakt
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "stickWall" || other.gameObject.tag == "target")
        {
            GetComponent<Transform>().SetParent(other.gameObject.transform);
            GetComponent<Transform>().localScale = scale ;
            spear.isKinematic = true;
        }
        if (other.gameObject.tag == "Vincent")
        {
            vincentHit = true;
        }
    }
}

