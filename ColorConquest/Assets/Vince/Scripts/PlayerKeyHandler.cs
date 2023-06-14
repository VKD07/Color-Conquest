using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyHandler : MonoBehaviour
{
    [SerializeField] float numOfKey;
    [SerializeField] GameObject playerKey;
    public float Key
    {
        get
        {
            return numOfKey;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Key")
        {
            numOfKey += 1;
            playerKey.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
