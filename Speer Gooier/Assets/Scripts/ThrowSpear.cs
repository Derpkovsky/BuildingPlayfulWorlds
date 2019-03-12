using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ThrowSpear : MonoBehaviour
{
    public float throwSpeed;
    public float recallSpeed;
    public int spearAmount;
    public float jumpCounter;
    public float boostJump;

    public GameObject spear;
    public Transform player;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;

    private bool leftDown = false;
    private bool Rdown;
    private float jumpTimer;

    void Start()
    {
        GameObject spearObject = (GameObject)Instantiate(spear, transform.position, transform.rotation);
        SpearHold();
    }


    void Update()
    {
        // flipt boolean als de muis omhoog gaat
        if (Input.GetKeyUp(KeyCode.Mouse0))
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


        //JUMPSHIT
        if (Input.GetKey(KeyCode.M) && GameObject.FindGameObjectWithTag("Spear").GetComponent<SpearCollision>().playerCloseEnough == true)
        {
            jumpTimer += 1 * Time.deltaTime;
            Debug.Log(jumpTimer);
        }
        if (Input.GetKeyUp(KeyCode.M) && jumpTimer >= jumpCounter)
        {
            fpscontroller.m_JumpSpeed = boostJump;
            fpscontroller.m_Jump = true;
            jumpTimer = 0f;
        }
    }


    // lerpt de speerpositie naar de spelerpositie
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
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Spear").transform.position, transform.position) < 0.4)
            {
                SpearHold();
            }
        }
    }

    // unparent de speer van de player, zet hem niet meer op kinematic en geeft force
    void SpearThrow()
    {
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("Spear").transform.parent = null;
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;
        GameObject.FindGameObjectWithTag("Spear").GetComponent<Collider>().enabled = true;
        spearAmount -= 1;
    }

    // houdt de speer vast door hem te parenten van de speler en de posities aan elkaar gelijk te stellen
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