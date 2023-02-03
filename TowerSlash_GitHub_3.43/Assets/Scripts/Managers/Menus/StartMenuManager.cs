using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
