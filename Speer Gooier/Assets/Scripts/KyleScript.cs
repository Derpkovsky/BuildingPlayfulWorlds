using UnityEngine;
using System.Collections;

public class KyleScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody target;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float moveSpeedCounter = 1 / moveSpeed;
        while (moveSpeedCounter < 1)
        {
            moveSpeedCounter += moveSpeedCounter * Time.deltaTime;
            target.transform.position = Vector3.Lerp(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);

        }
    }
}
