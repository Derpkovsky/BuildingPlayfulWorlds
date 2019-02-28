using UnityEngine;
using UnityEngine.UI;

public class VictoryUI : MonoBehaviour
{
    public Text VictoryText;

    void Update()
    {
        if(GameObject.Find("Victory Trigger").GetComponent<VictoryTrigger>().Victorybool == true)
        {
            VictoryText.text = "Level Cleared!";
            Debug.Log("Level Cleared");
        }
        if (GameObject.FindGameObjectWithTag("Spear").GetComponent<SpearCollision>().VincentHit == true)
        {
            VictoryText.text = "auw!";
        }
    }
}
