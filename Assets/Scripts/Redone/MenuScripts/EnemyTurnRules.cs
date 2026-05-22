using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyTurnRules : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void ETurnRulesPlay()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
