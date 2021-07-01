using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    // The worlds most simple life bar slider script O_O - a bit buggy right now.
    public Slider slider;
    public void SetMaxLife(float life)
    {
        slider.maxValue = life;
        slider.value = life;
    }

    public void SetLife(float life)
    {
        slider.value = life;
    }

}
