using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject[] gameOverUI;
    [SerializeField] GameObject[] players;
    PauseGame pauseGame;

    private void Start()
    {
        pauseGame = GetComponent<PauseGame>();
    }
    void Update()
    {
        CheckIfPlayerHasDied();
    }

    private void CheckIfPlayerHasDied()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length < 2)
        {
            ChooseGameOverScreen(players[0].name);
            print(players[0].name);
        }
    }

    void ChooseGameOverScreen(string name)
    {
        if (name.Contains("Flik"))
        {
            gameOverUI[0].SetActive(true);
        }
        else if(name.Contains("Flak"))
        {
            gameOverUI[1].SetActive(true);
        }
        pauseGame.PauseTheGame = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
