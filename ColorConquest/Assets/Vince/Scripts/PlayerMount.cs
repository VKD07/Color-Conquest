using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMount : MonoBehaviour
{
    [SerializeField] Transform mountPos;
    [SerializeField] GameObject playerMounted;
    [SerializeField] float rayCastLength = 0.2f;

    // Update is called once per frame
    void LateUpdate()
    {
        DetectPlayerFromHead();
        UpdateMountedPlayerPosition();
    }

    private void DetectPlayerFromHead()
    {
        RaycastHit2D hit = Physics2D.Raycast(mountPos.position, mountPos.up, rayCastLength);
        if (hit.collider != null)
        {
            if (playerMounted == null && hit.collider.gameObject.CompareTag("Player"))
            {
                playerMounted = hit.collider.gameObject;
            }
        }
        else if (playerMounted != null && playerMounted.GetComponent<PlayerMovementScript>().playerMoving)
        {
            playerMounted = null;
        }
    }

    private void UpdateMountedPlayerPosition()
    {
        if (playerMounted != null && playerMounted.GetComponent<PlayerMovementScript>().playerMoving)
        {
            return;
        }else if(playerMounted != null && !playerMounted.GetComponent<PlayerMovementScript>().playerMoving)
        {
            playerMounted.transform.position = mountPos.position;
        }
    }
}
