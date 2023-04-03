using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : Singleton<CanvasManager>
{
    
    public void OnStartGameButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

}
