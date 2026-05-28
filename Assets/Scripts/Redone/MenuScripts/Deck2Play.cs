using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Deck2Play : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void D2P()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}

