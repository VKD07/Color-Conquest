using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerKeyHandler>() != null)
            {
                PlayerKeyHandler playerKey = collision.gameObject.GetComponent<PlayerKeyHandler>();
                
                if(playerKey.Key > 0)
                {
                    //do something here if the player got the key
                    print("Success");
                }
            }
        }
    }
}
