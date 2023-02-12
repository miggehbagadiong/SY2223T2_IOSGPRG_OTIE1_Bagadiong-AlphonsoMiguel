using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Player player;

    private void Update()
    {
        UiManager.Instance.scoreTxt.text = ScoreManager.Instance.GetPlayerScore().ToString();
        UiManager.Instance.killsTxt.text = ScoreManager.Instance.GetKillScore().ToString();
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void GoToGameOverScreen()
    {
        SceneManager.LoadScene("Game Over");
    }

}
