using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Deck1Rules : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void D1R()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
