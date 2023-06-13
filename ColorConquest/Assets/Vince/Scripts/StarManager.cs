using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] float starsRequired;
    [SerializeField] float currentStars;
    [SerializeField] MovingPlatform movingPlatform;

    private void Update()
    {
        ActivatePlatform();
    }

    private void ActivatePlatform()
    {
        if (currentStars >= starsRequired && movingPlatform != null)
        {
            movingPlatform.activatePlatform = true;
        }
    }

    public void AddCurrentStars(float numStar)
    {
        currentStars += numStar;
    }
}
