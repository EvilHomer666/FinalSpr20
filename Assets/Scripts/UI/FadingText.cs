using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingText : MonoBehaviour
{
    private Text fadingText;
    private float waitTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        fadingText = GetComponent<Text>();
        StartCoroutine("FadeIn");
    }

    // Custom methods for blinking text



    //public void StartFadeIn()
    //{
    //    StopCoroutine("Fade");
    //    StartCoroutine("Fade");
    //}

    //public void StartFadeOut()
    //{
    //    StopCoroutine("Fade");

    //}

    //IEnumerator Fade()
    //{
    //    while (true)
    //    {
    //        // Switch to turn on and off the RGB and alpha elements of the text making it "fade in"
    //        switch (fadingText.color.a.ToString())
    //        {
    //            // Turn on
    //            case "0":
    //                fadingText.color = new Color(fadingText.color.r, fadingText.color.g, fadingText.color.b, 1);
    //                yield return new WaitForSeconds(waitTime);
    //                break;

    //            // Turn off
    //            case "1":
    //                fadingText.color = new Color(fadingText.color.r, fadingText.color.g, fadingText.color.b, 0);
    //                yield return new WaitForSeconds(waitTime);
    //                break;
    //        }
    //    }
    //}

    IEnumerator FadeOut()
    {
        fadingText.color = new Color(fadingText.color.r, fadingText.color.g, fadingText.color.b, 0);
        yield return new WaitForSeconds(waitTime);
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(waitTime);
        fadingText.color.a.ToString();
        fadingText.color = new Color(fadingText.color.r, fadingText.color.g, fadingText.color.b, 1);

    }
}
