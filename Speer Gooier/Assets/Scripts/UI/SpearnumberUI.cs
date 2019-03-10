using UnityEngine;
using UnityEngine.UI;

public class SpearnumberUI : MonoBehaviour
{
    public int spearNumber;
    public Text spearsText;

    void Update()
    {
        spearNumber = GameObject.Find("speerspawn").GetComponent<ThrowSpear>().spearAmount;
        spearsText.text = "Spears: " + spearNumber.ToString();
    }
} 
