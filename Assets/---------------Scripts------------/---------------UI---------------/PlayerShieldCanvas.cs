using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShieldCanvas : MonoBehaviour
{
    [SerializeField] CanvasGroup playerCanvasAlpha;
    [SerializeField] GameObject meshRenderer;
    //private float displayTime = 500.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerCanvasAlpha.alpha = 1;
        meshRenderer.SetActive(true);
    }

    public void shieldUpdate()
    {
        //StartCoroutine(DisplayPercentageInormation());
    }

    // Percentage UI indicator
    //IEnumerator DisplayPercentageInormation()
    //{
    //    playerCanvasAlpha.alpha = 1;
    //    meshRenderer.SetActive(true);
    //    yield return new WaitForSeconds(displayTime);
    //    playerCanvasAlpha.alpha = 0;
    //    meshRenderer.SetActive(false);
    //}
}
