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
        SoundManager.Instance.PlayBtn();
        pauseGame.PauseTheGame = true;
        InstructionsUI.SetActive(true);
    }

    public void CloseInstructions()
    {
        SoundManager.Instance.PlayBtn();
        pauseGame.PauseTheGame = false;
        InstructionsUI.SetActive(false);
    }
}
