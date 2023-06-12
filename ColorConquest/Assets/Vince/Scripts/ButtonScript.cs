using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] MovingPlatform movingPlatform;
    [SerializeField] float rayDistance = 0.5f;
    [SerializeField] LayerMask colorRequired;

    private void Update()
    {
        //fix bug issue where if it jumps fast it will continue to go
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, rayDistance, colorRequired);

        if(hit.collider != null)
        {
            movingPlatform.activatePlatform = true;
        }
        else
        {
            movingPlatform.activatePlatform = false;
        }
    }
}
