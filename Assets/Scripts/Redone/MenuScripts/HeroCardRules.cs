using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HeroCardRules : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void HeroCardButton()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
