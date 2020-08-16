using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivity : MonoBehaviour
{
    [SerializeField] Renderer shieldFXRenderer; // FX renderer
    private DetectPlayerCollisions playerCollisions;
    private float flashShieldTime = 0.25f;

    // Rendering values Set to renderer on collision
    private float shieldOnHit = 200.0f; // << Sets Fresnel Intensity value on hit
    private float shieldOpacityOnHit = 2.0f; // << Sets Fresnel Width value on hit

    // Values subtracted from renderer during cool-down and Set coroutine
    private float shieldStableCoolDown = 0.1f;
    private float shieldOpacityStableCoolDown = 0.001f;

    // Value stop limits
    private float shieldFadeLimit = 1.5f;
    private float shieldOpacityFadeLimit = 0.5f;

    // Value stop new non-collision set
    private float shieldStable = 1.0f;
    private float shieldOpacityStable = 0.0f;

    public bool shieldHit; // << Condition called from DetectPlayerCollisions script

    // Start is called before the first frame update
    void Start()
    {
        playerCollisions = GetComponent<DetectPlayerCollisions>();
        shieldHit = false;      
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHit == true)
        {
            StartCoroutine(ShieldHit());

            shieldHit = false;
        }
    }

    // Shield activity indicator
    private IEnumerator ShieldHit()
    {
        Debug.Log("Shield is Activated!");

        shieldFXRenderer.material.SetFloat("_Fresnel", shieldOnHit);
        shieldFXRenderer.material.SetFloat("_FresnelWidth", shieldOpacityOnHit);
        yield return new WaitForSeconds(flashShieldTime);
        StartCoroutine(FadeShield());
        shieldFXRenderer.material.SetFloat("_Fresnel", shieldStable);
        shieldFXRenderer.material.SetFloat("_FresnelWidth", shieldOpacityStable);

    }

    //Health regeneration over time
    IEnumerator FadeShield()
    {
        while (true)
        {
            if (shieldFXRenderer.material.GetFloat("_Fresnel") >= shieldFadeLimit)
            {
                shieldFXRenderer.material.SetFloat("_Fresnel", shieldOnHit -= shieldStableCoolDown); 
                shieldFXRenderer.material.SetFloat("_FresnelWidth", shieldOpacityOnHit -= shieldOpacityStableCoolDown);
                yield return new WaitForSeconds(0.005f);
            }
            else
            {
                yield return null;
            }
        }
    }
}
