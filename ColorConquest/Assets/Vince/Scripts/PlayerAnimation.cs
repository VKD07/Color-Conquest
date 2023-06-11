using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnim;

    public void EnableUIColor(bool enable)
    {
    }

    public void PlayRunning(bool enable)
    {
        playerAnim.SetBool("Running", enable);
    }

    public void PlayJump()
    {
        playerAnim.SetTrigger("Jump");
    }

    public void SetPlayerColor(string color)
    {
        playerAnim.SetTrigger(color);
    }
}
