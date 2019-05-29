using UnityEngine;
using System.Collections;
using UnityEngine.Accessibility;

public class KyleScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float stunTime = 2.0f;


    private float oldMoveSpeed;
    private float oldStunTime;
    private float spearSpeed;
    private Vector3 spearImpact;

    private bool spearHit;
    private bool vision = false;
    private bool stunTimer;


    void Start()
    {
        spearSpeed = GameObject.Find("speerspawn").GetComponent<ThrowSpear>().throwSpeed;
    }


    void Update()
    {
        Vector3 targetDir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        if (spearHit == true)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            hitImpact();
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = true;
            if (vision == true)
            {
                transform.rotation = Quaternion.LookRotation(newDir);
                transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, Time.deltaTime * moveSpeed);
            }
        }

        if (stunTimer == true)
        {
            oldStunTime = stunTime;
            stunTime -= Time.deltaTime;
            if (stunTime <= 0)
            {
                stunTimerEnd();
            }
        }
    }

    void stunTimerEnd()
    {
        moveSpeed = oldMoveSpeed;
        stunTime = oldStunTime;
    }

    void hitImpact()
    {
        spearImpact = GameObject.Find("speerspawn").GetComponent<ThrowSpear>().spearRotation.eulerAngles;
        gameObject.GetComponent<Rigidbody>().AddForce(spearImpact);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Spear")
        {
            spearHit = true;
        }

        if (other.gameObject.tag == "stone")
        {
            oldMoveSpeed = moveSpeed;
            moveSpeed = 0;
            stunTimer = true;
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
