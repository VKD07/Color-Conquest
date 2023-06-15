using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SoundManager.Instance.PlayBtn();
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame()
    {
        SoundManager.Instance.PlayBtn();
        Application.Quit();
    }
}
