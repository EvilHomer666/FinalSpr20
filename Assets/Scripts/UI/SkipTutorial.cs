using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkipTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button8))
        {
            SceneManager.LoadScene("Lev01");
        }
    }
}
