using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialButton : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void Tutorial()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}

