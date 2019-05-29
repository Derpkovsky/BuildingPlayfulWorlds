using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdLeft : MonoBehaviour
{
    private bool playerCloseToStone;
    private bool rightDown;
    private int stoneAmount;
    private ArrayList stonesHolding;
    private ArrayList stonesOnGround;

    public float throwSpeed;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            rightDown = true;
        }
        else
        {
            rightDown = false; 
        }

        if (rightDown == true && stoneAmount > 0)
        {
            stoneThrow();
        }

        if (Vector3.Distance(transform.position, GameObject.Find("FPSController").GetComponent<Transform>().position) < 0.5)
        {
            playerCloseToStone = true;
        }
        else
        {
            playerCloseToStone = false;
        }

        if (Input.GetKeyUp("e") && playerCloseToStone == true)
        {
            stoneHold();
        }
    }

    void stoneThrow()
    {
        GameObject.FindGameObjectWithTag("stone").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("stone").transform.parent = null;
        GameObject.FindGameObjectWithTag("stone").GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;
        GameObject.FindGameObjectWithTag("stone").GetComponent<Collider>().enabled = true;
        stoneAmount -= 1;
    }


    public void stoneHold()
    {
        GameObject.FindGameObjectWithTag("stone").GetComponent<Transform>().SetParent(transform);
        GameObject.FindGameObjectWithTag("stone").transform.position = transform.position;
        GameObject.FindGameObjectWithTag("stone").transform.rotation = transform.rotation;
        GameObject.FindGameObjectWithTag("stone").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("stone").GetComponent<Collider>().enabled = false;
        stoneAmount += 1;
    }
}