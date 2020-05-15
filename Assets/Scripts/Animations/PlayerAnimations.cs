using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator flyInAnimation;
    private float animationLapse = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Reference the Animator
        flyInAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine("PlayFlyInAnimation");
    }

    IEnumerator PlayFlyInAnimation()
    {
        while(true)
        {
            // Wait for a second before applying root motion to the player object
            yield return new WaitForSeconds(animationLapse);
            flyInAnimation.applyRootMotion = true;
        }
    }

    private void FlyInAnimation()
    {
        // For use with Unity originated animation event
    }
}
