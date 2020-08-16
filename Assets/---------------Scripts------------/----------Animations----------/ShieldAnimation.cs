using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimation : MonoBehaviour
{
    private Animator shieldAnimation;
    public bool shieldHit;

    // Start is called before the first frame update
    void Start()
    {
        // Reference the Animator
        shieldAnimation = GetComponent<Animator>();
        shieldHit = false;
    }

    public void PlayShieldAnimation()
    {
        if(shieldHit == true)
        {
            shieldAnimation.SetTrigger("ShieldActivated");
        }
    }
}
