using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public bool Victorybool;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Victory!");
            Victorybool = true;
        }
    }
}
