using UnityEngine;
using UnityEngine.UI;

public class VictoryUI : MonoBehaviour
{
    public Text VictoryText;

    void Update()
    {
        if (GameObject.Find("Exit").GetComponent<VictoryTrigger>().Victorybool == true)
        {
            VictoryText.text = "Level Cleared!";
            Debug.Log("Level Cleared");
        }
        else
        {
            VictoryText.text = "";
        }

        if (GameObject.FindGameObjectWithTag("Spear").GetComponent<SpearCollision>().vincentHit == true)
        {
            VictoryText.text = "auw!";
        }
        else
        {
            VictoryText.text = "";
        }
    }
}
