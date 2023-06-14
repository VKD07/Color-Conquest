using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] float starsRequired;
    [SerializeField] float currentStars;
    [SerializeField] GameObject [] platformsToDestroy;

    private void Update()
    {
        DestroyPlatform();
    }

    private void DestroyPlatform()
    {
        platformsToDestroy = GameObject.FindGameObjectsWithTag("RainBow");
        for (int i = 0; i < platformsToDestroy.Length; i++)
        {
            if (currentStars >= starsRequired && platformsToDestroy.Length > 0)
            {
                Destroy(platformsToDestroy[i]);
            }
        }
    }

    public void AddCurrentStars(float numStar)
    {
        currentStars += numStar;
    }
}
