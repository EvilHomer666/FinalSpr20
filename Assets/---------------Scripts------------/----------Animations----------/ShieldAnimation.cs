using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimation : MonoBehaviour
{
    private Animator shieldAnimation;
    public MeshRenderer shieldMeshRenderer;
    public bool shieldHit;

    // Start is called before the first frame update
    void Start()
    {
        shieldMeshRenderer.enabled = false;
        shieldHit = false;
    }

    public void PlayShieldAnimation()
    {
        if (shieldHit == true)
        {
            shieldMeshRenderer.enabled = true;
            shieldAnimation.SetTrigger("ShieldActivated");
        }
    }
}
