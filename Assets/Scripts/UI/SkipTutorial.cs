using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkipTutorial : MonoBehaviour
{
    [SerializeField] GameObject skipTutorial;
    // Start is called before the first frame update
    public void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Lev01");
        }
    }
}
