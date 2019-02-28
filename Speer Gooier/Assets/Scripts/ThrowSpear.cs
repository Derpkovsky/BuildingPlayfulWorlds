using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ThrowSpear : MonoBehaviour
{
    public float throwSpeed;
    public float recallSpeed;
    public int spearAmount;
    public float jumpThreshold;
    public float boostJump;

    public Rigidbody spear;
    public Transform player;
    public Transform spearspawn;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;

    private bool leftDown = false;
    private bool Rdown;
    private float jumpTimer;



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

        if (Input.GetKey(KeyCode.M) && GameObject.FindGameObjectWithTag("Spear").GetComponent<SpearCollision>().playerCloseEnough == true)
        {
            jumpTimer += 1 * Time.deltaTime;
            Debug.Log(jumpTimer);
        }

        if (Input.GetKeyUp(KeyCode.M) && jumpTimer >= jumpThreshold)
        {
            fpscontroller.m_Jump = true;
            fpscontroller.m_JumpSpeed = boostJump;
            jumpTimer = 0f;
        }
    }


    // lerpt de speerpositie naar de spelerpositie
    void RecallSpear()
    {
        Debug.Log("in functie");
        float actualRecallSpeed = 1 / recallSpeed;
        while (actualRecallSpeed < 1)
        {
            actualRecallSpeed += Time.deltaTime * actualRecallSpeed;
            GameObject.FindGameObjectWithTag("Spear").GetComponent<Transform>().position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Spear").GetComponent<Transform>().position, spearspawn.position, recallSpeed * Time.deltaTime);
            GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.FindGameObjectWithTag("Spear").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            if ()
            {
                GameObject.FindGameObjectWithTag("Spear").GetComponent<Collider>().enabled = false;
            }
        }
    }


    // spawnt de Spear prefab, geeft hem snelheid en verminderd het aantal gooibare speren
    void SpearThrow()
    {
        Rigidbody spearObject = (Rigidbody)Instantiate(spear, spearspawn.position, transform.rotation);
        spearObject.velocity = transform.forward * throwSpeed;
        spearAmount -= 1;
    }
}


