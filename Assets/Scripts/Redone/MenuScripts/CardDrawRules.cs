using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CardDrawRules : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void CDraw()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
