using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private EventSystem eventSystem;
    private TitleScreenMenu mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = FindObjectOfType<TitleScreenMenu>();
        GameObject eventSystemObject = GameObject.FindWithTag("EventSystem");
        eventSystem = eventSystemObject.GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            mainMenu.ShowMainMenu();
            UpdateSelection();
        }
    }

    // Reset first menu option back to Start TO DO make less messy
    private void UpdateSelection()
    {
        //EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
    }
}
