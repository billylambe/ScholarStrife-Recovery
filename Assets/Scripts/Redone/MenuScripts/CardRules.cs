using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CardRules : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void Cardrules()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}