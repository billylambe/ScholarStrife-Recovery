using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeckView : MonoBehaviour
{

    [SerializeField] private string gameSceneName;
    public void Deck()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
