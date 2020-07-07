using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    // the worlds most simple shield bar slider script O_O - a bit buggy right now.
    public Slider slider;
    public void SetMaxShield(int shield)
    {
        slider.maxValue = shield;
        slider.value = shield;
    }

    public void SetLife(int shield)
    {
        slider.value = shield;
    }
}
