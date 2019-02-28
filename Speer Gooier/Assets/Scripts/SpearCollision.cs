using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour
{

    public GameObject spearObject;
    public Rigidbody spear;
    public GameObject playerLocation;
    public bool playerCloseEnough = false;
    public int spearAmount;
    public bool VincentHit;

    //Zorgt dat de speer stilstaat als hij een TestWall raakt
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "stickWall")
        {
            spear.isKinematic = true;
        }
        if (collisionInfo.collider.tag == "Vincent")
        {
            //TODO: Game Over
            Debug.Log("auw!");
            VincentHit = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("q") && playerCloseEnough == true)
        {
            Destroy(spearObject);
            GameObject.Find("speerspawn").GetComponent<ThrowSpear>().spearAmount += 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerLocation = other.gameObject;
            playerCloseEnough = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCloseEnough = false;
            playerLocation = null;
        }
    }
}

