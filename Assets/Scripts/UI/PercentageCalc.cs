using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageCalc : MonoBehaviour
{
    private Text percetageText;

    // Start is called before the first frame update
    void Start()
    {
        percetageText = GetComponent<Text>();
    }

public void textUpdate(float value)
    {
        //percetageText.text = Mathf.RoundToInt(value * 50) + "%";

        percetageText.text = $"Shields: {Mathf.RoundToInt(value * 25) + "%"}";
    }
}
