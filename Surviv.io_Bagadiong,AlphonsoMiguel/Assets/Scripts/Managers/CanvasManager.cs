using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : Singleton<CanvasManager>
{
    [Header("Menu Canvas")]
    public GameObject startCanvas;
    public GameObject gameOverCanvas;

    private void Awake() 
    {
        OpenStartMenuCanvas();
    }

    void OpenStartMenuCanvas()
    {
        startCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    public void OpenGameOverCanvas()
    {
        startCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void OnStartGameButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnTryAgainButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

}
