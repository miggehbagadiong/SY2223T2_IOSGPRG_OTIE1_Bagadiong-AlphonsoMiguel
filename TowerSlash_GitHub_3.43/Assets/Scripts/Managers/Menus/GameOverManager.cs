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
