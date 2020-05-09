using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Require button component
[RequireComponent(typeof(Button))]

public class StartClickSound : MonoBehaviour
{
    [SerializeField] AudioClip startSound;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = startSound;
        source.playOnAwake = false;

        // Add on click
        button.onClick.AddListener(() => PlaySound());
    }

    void PlaySound()
    {
        source.PlayOneShot(startSound);
    }
}
