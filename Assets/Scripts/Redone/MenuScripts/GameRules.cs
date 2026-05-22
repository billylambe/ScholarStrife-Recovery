using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameRules : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void GRulesPlay()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
