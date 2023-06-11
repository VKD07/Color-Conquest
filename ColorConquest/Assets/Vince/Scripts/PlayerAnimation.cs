using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] PlayerMovement playerMovement;

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
        if (color == "red")
        {
            playerAnim.SetTrigger("DTR");
        }
        else if (color == "yellow")
        {
            playerAnim.SetBool("DTY", true);
        }
        else if (color == "orange")
        {
            playerAnim.SetTrigger("DTO");
        }
        else if (color == "Default")
        {
            playerAnim.SetTrigger("RTD");
        }
    }
}
