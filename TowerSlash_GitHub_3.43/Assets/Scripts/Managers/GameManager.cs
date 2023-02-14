using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Player player;

    public bool isGameActive = true;

    public float longDashTime = 5f;

    private void Start()
    {
        CanvasManager.Instance.StartCharacterSelection();

    }

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

    public void OnStartGameButtonPressed()
    {
        CanvasManager.Instance.StartGame();
    }

    public void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }

    public void SetGameActiveBool(bool isActive)
    {
        this.isGameActive = isActive;    
    }

    public bool GetGameActiveBool()
    {
        return this.isGameActive;
    }

    public void OnDashButtonPressed()
    {
        ProgressBar.Instance.DashButton.SetActive(false);
        ScoreManager.Instance.killScore = 0;
        StartCoroutine(Dash.Instance.LongDash(longDashTime));
    }

}
