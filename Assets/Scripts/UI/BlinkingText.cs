using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    private Text blinkingText;
    private float waitTime = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        blinkingText = GetComponent<Text>();
        StartBlinking();
    }

    // Custom methods for blinking text
    private void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    private void StopBlinking()
    {
        StopCoroutine("Blink");
    }

    // Update is called once per frame
    IEnumerator Blink()
    {
        while (true)
        {
            // Switch to turn on and off the RGB elements of the text making it "blink"
            switch(blinkingText.color.a.ToString())
            {
                case "0":
                    blinkingText.color = new Color(blinkingText.color.r, blinkingText.color.g, blinkingText.color.b, 1);
                    yield return new WaitForSeconds(waitTime);
                    break;
                case "1":
                    blinkingText.color = new Color(blinkingText.color.r, blinkingText.color.g, blinkingText.color.b, 0);
                    yield return new WaitForSeconds(waitTime);
                    break;
            }
        }
    }
}
