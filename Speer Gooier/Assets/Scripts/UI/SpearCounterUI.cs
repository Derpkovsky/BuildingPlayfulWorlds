using UnityEngine;
using UnityEngine.UI;

public class SpearCounterUI : MonoBehaviour
{
    public int spearAmount;
    public Text spearText;

    void Update()
    {
        spearAmount = GameObject.Find("speerspawn").GetComponent<ThrowSpear>().spearAmount;
        spearText.text = "spears:" + spearAmount.ToString();
    }
}