using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinHandler : MonoBehaviour
{
    [SerializeField] ExitDoor exitDoor;
    [SerializeField] GameObject winScreenUi;
    PauseGame pauseGame;
    private void Start()
    {
        pauseGame = GetComponent<PauseGame>();
    }
    // Update is called once per frame
    void Update()
    {
        DetermineSuccess();
    }

    private void DetermineSuccess()
    {
        exitDoor = FindObjectOfType<ExitDoor>();
        if (exitDoor != null )
        {
            if(exitDoor.DoorOpened)
            {
                pauseGame.PauseTheGame = true;
                winScreenUi.SetActive(true);
            }
        }
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex != 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
