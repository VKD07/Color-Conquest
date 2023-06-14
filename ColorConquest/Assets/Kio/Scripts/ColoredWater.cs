using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredWater : MonoBehaviour
{
    public bool flik;
    public bool flak;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var playerMovement = collision.gameObject.GetComponent<PlayerMovementScript>();

            if (flak == true && playerMovement.flak == false)
            {
                Destroy(collision.gameObject);
            }

            if (flik == true && playerMovement.flik == false)
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
