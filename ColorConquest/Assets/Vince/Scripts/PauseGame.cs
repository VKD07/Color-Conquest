using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    bool pauseGame;

    

    private void Update()
    {
        StopTheTime();
    }

    private void StopTheTime()
    {
        if (pauseGame)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public bool PauseTheGame
    {
        set
        {
            pauseGame = value;
        }
    }
}
