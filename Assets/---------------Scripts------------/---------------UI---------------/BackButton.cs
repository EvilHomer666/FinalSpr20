using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    private TitleScreenMenu mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = FindObjectOfType<TitleScreenMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            mainMenu.ShowMainMenu();
        }
    }
}
