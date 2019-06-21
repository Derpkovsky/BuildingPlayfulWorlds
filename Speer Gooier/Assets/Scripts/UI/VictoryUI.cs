using UnityEngine;
using UnityEngine.UI;

public class VictoryUI : MonoBehaviour
{
    public Text VictoryText;
    private VictoryTrigger victoryTrigger;

    void Start()
    {
        victoryTrigger = GameObject.Find("Exit").GetComponent<VictoryTrigger>();
    }

    void Update()
    {
        if (victoryTrigger.Victorybool)
        {
            VictoryText.text = "Thank you for delivering the package!" +
                               "You've helped us so much";
            
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
