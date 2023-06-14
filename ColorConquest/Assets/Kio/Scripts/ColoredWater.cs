using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredWater : MonoBehaviour
{
    [SerializeField] GameObject flikGameOver;
    [SerializeField] GameObject flakGameOver;
    public bool flik;
    public bool flak;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var playerMovement = collision.gameObject.GetComponent<PlayerMovementScript>();

            if (flak == true && playerMovement.flak == false)
            {
                flakGameOver.SetActive(true);
            }

            if (flik == true && playerMovement.flik == false)
            {
                flikGameOver.SetActive(true);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
