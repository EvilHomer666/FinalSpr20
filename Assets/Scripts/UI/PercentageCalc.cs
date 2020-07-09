using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageCalc : MonoBehaviour
{
    private Text percetageText;

    // Awake is called before Update and the first frame update
    void Awake()
    {
        percetageText = GetComponent<Text>();
    }

    public void textUpdate(float value)
    {
        percetageText.text = $"Shields: {Mathf.RoundToInt(value * 25) + "%"}";
    }
}
