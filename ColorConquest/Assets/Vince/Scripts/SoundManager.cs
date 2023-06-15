using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip mainMusic;
    [SerializeField] AudioClip pickUpSfx;
    [SerializeField] AudioClip gameOverSfx;
    [SerializeField] AudioClip jumpSfx;
    [SerializeField] AudioClip pressBtnSfx;
    [SerializeField] AudioClip winSfx;
    bool gameOverPlayed;
    bool winIsPlayed;

    private static SoundManager instance;

    public static SoundManager Instance
    {
        get { return instance; }
    }

    public bool WinSfxIsPlayed
    {
        set
        {
            winIsPlayed = value;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMainMusic();
    }

    public void PlayMainMusic()
    {
        audioSource.Stop();
        audioSource.clip = mainMusic;
        audioSource.Play();
        StartCoroutine(enableGameOverSFX(1));
    }

    public void PlayPickUP()
    {
        audioSource.PlayOneShot(pickUpSfx);
    }

    public void PlayGameOver()
    {
        if (!gameOverPlayed)
        {
            gameOverPlayed = true;
            audioSource.Stop();
            audioSource.clip = gameOverSfx;
            audioSource.Play();
        }
    }

    public void PlayJumpSfx()
    {
        audioSource.PlayOneShot(jumpSfx);
    }

    public void PlayBtn()
    {
        audioSource.PlayOneShot(pressBtnSfx);
    }

    public void WinSfx()
    {
        if (!winIsPlayed)
        {
            winIsPlayed = true;
            audioSource.PlayOneShot(winSfx);
            StartCoroutine(EnableWinIsPlayed(2));
        }
    }

    IEnumerator enableGameOverSFX(float time)
    {
        yield return new WaitForSeconds(time);

        gameOverPlayed = false;
    }

    IEnumerator EnableWinIsPlayed(float time)
    {
        yield return new WaitForSeconds(time);
        SoundManager.Instance.WinSfxIsPlayed = false;
    }
}
