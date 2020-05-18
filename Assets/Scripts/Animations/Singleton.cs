using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This singleton provided in class by Michael Hadley for educational purposes.
// Generic that inherit from MonoBehaviour ensures that we can use the Unity API.
// Where T is MonoBehaviour (inherits from MonoBejaviour) ensures T to singleton<T>.

// So here we use a generic for our singleton in order to make our logic simpler. 
// "T" in this case, will replace the specific type "ScoreManager"

// Use sparingly! Singleton introduces a global variable that is accessible publicly.
public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    // Singleton pattern! to only allow read of an instance but not write
    static public T Instance { get; private set; }

    // This we do this next step in awake as opposed to start
    private void Awake()
    {
        // here we check for duplicate score before passing our live score into the next level
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this as T; // <<<<<<<<< Cast the new generic type!
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

}
