using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    bool win;

    public bool DoorOpened
    {
        get
        {
            return win;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerKeyHandler>() != null)
            {
                PlayerKeyHandler playerKey = collision.gameObject.GetComponent<PlayerKeyHandler>();

                if (playerKey.Key > 0)
                {
                    win = true;
                }
            }
        }
    }
}
