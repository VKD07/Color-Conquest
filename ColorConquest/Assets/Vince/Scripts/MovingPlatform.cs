using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float distanceToMove;
    [SerializeField] float timeToReach;
    [SerializeField] bool useVerticalMovement;
    [SerializeField] bool destinationReached;
    [SerializeField] public bool activatePlatform;
    Rigidbody2D rb;

    float currentTime;
    bool moving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Direction();
    }

    void Direction()
    {
        if (useVerticalMovement)
        {
            Move(distanceToMove, 0);
        }
        else
        {
            Move(0, distanceToMove);
        }
    }

    void Move(float xDistance, float yDistance)
    {
        if (currentTime < timeToReach && activatePlatform)
        {
            moving = true;
            currentTime += Time.deltaTime;
            rb.velocity = new Vector2(2 * xDistance / timeToReach, 2 * yDistance / timeToReach);
        }
        else if (currentTime >= timeToReach && moving)
        {
            destinationReached = true;
            currentTime = 0;
            moving = false;
            rb.velocity = Vector2.zero;
        }

        if (!activatePlatform && destinationReached)
        {
            if (currentTime > 0 && !activatePlatform)
            {
                destinationReached = false;
                currentTime -= Time.deltaTime;
                rb.velocity = new Vector2(-2 * xDistance / timeToReach, -2 * yDistance / timeToReach);
            }
            else
            {
                destinationReached = false;
                rb.velocity = Vector2.zero;
            }
        }
    }
}
