using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivity : MonoBehaviour
{
    [SerializeField] Renderer shieldRenderer;
    [SerializeField] GameObject shieldMeshRenderer;
    private float shieldOnHit = 200.0f;
    private float cooldownTime = 0.25f;
    private float shieldStable = 1.0f;
    public bool shieldIsActive;
    public bool shieldDown;

    // Start is called before the first frame update
    void Start()
    {
        shieldRenderer = GetComponent<Renderer>();        
        shieldIsActive = false;
        shieldMeshRenderer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldIsActive == true)
        {
            shieldMeshRenderer.SetActive(true);
            StartCoroutine(ShieldIsActive());
        }               
    }

    // Shield activity indicator
    private IEnumerator ShieldIsActive()
    {
        Debug.Log("Shield is Active!");
        shieldRenderer.material.SetFloat("_Fresnel", shieldOnHit);
        yield return new WaitForSeconds(cooldownTime);
        shieldIsActive = false;
        shieldRenderer.material.SetFloat("_Fresnel", shieldStable); //  TO DO subtract incremental to simulate fadeout
    }
}
