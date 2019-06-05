﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ThrowSpear : MonoBehaviour
{
    public float throwSpeed;
    public float recallSpeed;
    public float jumpThreshold;
    public float boostJumpForce;
    public Quaternion spearRotation;
    public GameObject spear;

    private int spearAmount;
    private bool leftDown;
    private bool Rdown;
    private float jumpTimer;

    void Start()
    {
        GameObject spearObject = (GameObject)Instantiate(spear, transform.position, transform.rotation);
        SpearHold();
    }


    void Update()
    {
        // ACTION TRIGGERS
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {leftDown = true;}
        else
        {leftDown = false;}
        if (leftDown == true && spearAmount > 0)
        {
            SpearThrow();
        }

        if (Input.GetKey("r"))  
        {
            RecallSpear();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        if (Input.GetKeyUp("q") && GameObject.FindGameObjectWithTag("Spear").GetComponent<SpearCollision>().playerCloseEnough == true)
        {
            SpearHold();
        }

        GameObject.FindGameObjectWithTag("Spear").transform.rotation = ;

        //BOOSTJUMP
        if (Input.GetKeyDown(KeyCode.M) && GameObject.FindGameObjectWithTag("Spear").transform.parent != transform && GameObject.FindGameObjectWithTag("Spear").GetComponent<SpearCollision>().playerCloseEnough == true)
        {
            jumpTimer += 1 * Time.deltaTime;
            Debug.Log(jumpTimer);
            if (Input.GetKeyUp(KeyCode.M) && jumpTimer >= jumpThreshold)    
            {
                GameObject.Find("FPSController").GetComponent<Rigidbody>().AddForce(transform.up * boostJumpForce);
                jumpTimer = 0;
            }
        }
    }




    // ROEPT SPEER TERUG
    //(unparent, position lerp, rotate lerp, freeposition + rotation, bij player: hold)
    void RecallSpear()
    {
        float recallSpeedCounter = 1 / recallSpeed;
        while (recallSpeedCounter < 1)
        {
            recallSpeedCounter += Time.deltaTime * recallSpeedCounter;
            GameObject.FindGameObjectWithTag("Spear").transform.parent = null;
            GameObject.FindGameObjectWithTag("Spear").transform.position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Spear").transform.position, transform.position, recallSpeed * Time.deltaTime);
            GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GameObject.FindGameObjectWithTag("Spear").transform.rotation = Quaternion.Lerp(GameObject.FindGameObjectWithTag("Spear").transform.rotation, transform.rotation, recallSpeed * Time.deltaTime);
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Spear").transform.position, transform.position) < 0.7)
            {
                SpearHold();
            }
        }
    }

    // GOOIT DE SPEER
    // (kinematic uit, unparent, geef velocity, zet collider aan, -1 speer)
    void SpearThrow()
    {
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("Spear").transform.parent = null;
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Collider>().enabled = true;
        spearAmount -= 1;
        spearRotation = transform.rotation;
    }

    // HOUDT DE SPEER VAST
    // (setParent, zet transform en rotatie gelijk, kinematic aan, collider uit, +1 speer, freezeposition uit)
    public void SpearHold()
    {
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Transform>().SetParent(transform);
        GameObject.FindGameObjectWithTag("Spear").transform.position = transform.position;
        GameObject.FindGameObjectWithTag("Spear").transform.rotation = transform.rotation;
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Collider>().enabled = false;
        spearAmount += 1;
        if (GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezePosition  || GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezeRotation)
        {
            GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}