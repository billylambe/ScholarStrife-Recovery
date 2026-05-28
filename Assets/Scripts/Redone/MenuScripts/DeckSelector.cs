using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeckSelector : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void DS()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}

