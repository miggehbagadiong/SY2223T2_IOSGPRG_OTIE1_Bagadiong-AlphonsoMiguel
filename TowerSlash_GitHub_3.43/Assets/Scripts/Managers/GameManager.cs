using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
