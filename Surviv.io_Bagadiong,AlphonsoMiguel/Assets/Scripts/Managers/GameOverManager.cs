using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public void OnTryAgainButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
    
}
