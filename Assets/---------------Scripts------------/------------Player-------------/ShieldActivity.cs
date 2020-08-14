using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivity : MonoBehaviour
{
    [SerializeField] Renderer shieldFXRenderer; // FX renderer
    private DetectPlayerCollisions playerCollisions;
    private float hitCoolDownTime = 0.25f;

    // Rendering values on hit/active
    private float shieldOnHit = 200.0f;
    private float shieldOpacityOnHit = 2.0f;

    // Values subtracted on cool down
    private float shieldStableCoolDown = 0.1f;
    private float shieldOpacityStableCoolDown = 0.001f;

    public bool shieldHit;

    // Start is called before the first frame update
    void Start()
    {
        shieldFXRenderer = GetComponent<Renderer>();
        playerCollisions = GetComponent<DetectPlayerCollisions>();
        shieldHit = false;      
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHit == true)
        {            
            StartCoroutine(ShieldHit());
        }
    }
 
    // Shield activity indicator
    private IEnumerator ShieldHit()
    {
        Debug.Log("Shield is Active!");
        shieldFXRenderer.material.SetFloat("_Fresnel", shieldOnHit);
        shieldFXRenderer.material.SetFloat("_FresnelWidth", shieldOpacityOnHit);        
        yield return new WaitForSeconds(hitCoolDownTime);
        StartCoroutine(FadeShield());
        shieldHit = false;
    }

    //Health regeneration over time
    IEnumerator FadeShield()
    {
        while (true)
        {
            if (shieldOnHit <= 200 && shieldOpacityOnHit <= 2.0f)
            {
                shieldFXRenderer.material.SetFloat("_Fresnel", shieldOnHit -= shieldStableCoolDown); //  TO DO subtract decremental to simulate fadeout
                shieldFXRenderer.material.SetFloat("_FresnelWidth", shieldOpacityOnHit -= shieldOpacityStableCoolDown); //  TO DO subtract decremental to simulate fadeout
                yield return new WaitForSeconds(0.025f);
            }
            else
            {
                yield return null;
            }
        }
    }
}
