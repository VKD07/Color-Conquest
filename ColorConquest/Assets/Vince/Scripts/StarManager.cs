using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] float starsRequired;
    [SerializeField] float currentStars;
    [SerializeField] GameObject platformToDestroy;

    private void Update()
    {
        DestroyPlatform();
    }

    private void DestroyPlatform()
    {
        if (currentStars >= starsRequired && platformToDestroy != null)
        {
            Destroy(platformToDestroy);
        }
    }

    public void AddCurrentStars(float numStar)
    {
        currentStars += numStar;
    }
}
