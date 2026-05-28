using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Deck2Rules : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void D2R()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
