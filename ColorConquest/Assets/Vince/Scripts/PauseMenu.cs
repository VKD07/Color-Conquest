using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    PauseGame pauseGame;
    [SerializeField] GameObject InstructionsUI; 
    void Start() 
    {
        pauseGame = GetComponent<PauseGame>();
    }

   public void OpenInstructions()
    {
        pauseGame.PauseTheGame = true;
        InstructionsUI.SetActive(true);
    }

    public void CloseInstructions()
    {
        pauseGame.PauseTheGame = false;
        InstructionsUI.SetActive(false);
    }
}
