using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameplayMenu : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void GLoop()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}

