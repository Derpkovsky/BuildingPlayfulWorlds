using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public List<GameObject> Stones;
    public Transform StoneHand;
    public float throwSpeed = 5f;

    private GameObject closestStone;
    private bool stoneClose = false;
    private int stonesHolding;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        if (stoneClose && Input.GetKeyDown(KeyCode.E))
        {
            SetStone();
        }

        if (stonesHolding > 0 && Input.GetMouseButtonDown(1))
        {
            ThrowStone();
            if (Stones != null)
            {
                closestStone = Stones[0];
            }
            else
            {
                closestStone = new GameObject("Empty");
            }
        }
    }

    private void SetStone()
    {
        stonesHolding += 1;
        closestStone.transform.SetParent(StoneHand);
        closestStone.transform.position = StoneHand.transform.position + new Vector3(Random.Range(-0.15f, 0.1f), Random.Range(-0.1f, 0.17f), Random.Range(-.2f, .2f));
        closestStone.transform.rotation = Random.rotation;
        closestStone.GetComponent<Rigidbody>().isKinematic = true;
        closestStone.GetComponent<Collider>().enabled = false;
        Stones.Add(closestStone);
    }

    private void ThrowStone()
    {
        stonesHolding -= 1;
        closestStone.transform.SetParent(null);
        closestStone.GetComponent<Collider>().enabled = true;
        closestStone.GetComponent<Rigidbody>().isKinematic = false;
        closestStone.GetComponent<Rigidbody>().velocity = player.transform.forward * throwSpeed;
        Stones.Remove(closestStone);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stone")
        {
            stoneClose = true;
            closestStone = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "stone")
        {
            stoneClose = false;
        }
    }
}
