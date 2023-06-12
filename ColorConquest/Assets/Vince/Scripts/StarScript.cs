using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    StarManager starManager;
    void Start()
    {
        starManager = FindFirstObjectByType<StarManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            starManager.AddCurrentStars(1);
            Destroy(gameObject);
        }
    }
}
