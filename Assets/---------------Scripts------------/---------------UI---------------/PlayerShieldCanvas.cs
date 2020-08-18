using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldCanvas : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroupAlpha;
    [SerializeField] GameObject pointerGameObject;
    public bool displayUI;
    private bool hideUIBrake;

    // Start is called before the first frame update
    void Start()
    {
        displayUI = false;
        hideUIBrake = false;
    }

    void Update()
    {
        if (displayUI == true)
        {
            DisplayFloatingUI();
            hideUIBrake = false;
        }
        else if (hideUIBrake == false) // << Add condition to not let coroutine run more than once per call
        {
            StartCoroutine(HideFloatingUI());
            hideUIBrake = true;
        }
    }

    private void DisplayFloatingUI()
    {
        canvasGroupAlpha.alpha = 1;
        pointerGameObject.SetActive(true);
    }

    IEnumerator HideFloatingUI()
    {
        yield return new WaitForSeconds(3.0f);
        canvasGroupAlpha.alpha = 0;
        pointerGameObject.SetActive(false);
    }
}
