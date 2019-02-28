using UnityEngine;
using UnityEngine.UI;

public class SpearnumberUI : MonoBehaviour
{ 
    public int spearAmount;
    public Text spearsText;

    void Update()
    {
        spearAmount = GameObject.Find("speerspawn").GetComponent<ThrowSpear>().spearAmount;
        spearsText.text = "Spears: " + spearAmount.ToString();
    }
}
