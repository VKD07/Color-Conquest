using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Keyboard Bindings")]
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    [Header("Movement Settings")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpPower = 20f;
    public bool isGrounded;

    [Header("Animation")]
    [SerializeField] PlayerAnimation playerAnim;

    [Header("Abilities")]
    [SerializeField] bool enableDoubleJump;
    [SerializeField] bool enableCrouch;
    [SerializeField] bool enableCrawl;
    bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var velocity = GetComponent<Rigidbody2D>().velocity;
        var rbComponent = GetComponent<Rigidbody2D>();

        //Movement
        if (Input.GetKey(left))
        {
            velocity = new Vector2(-movementSpeed, velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.PlayRunning(true);
        }

        else if (Input.GetKey(right))
        {
            velocity = new Vector3(movementSpeed, velocity.y);
            transform.rotation = Quaternion.identity;
            playerAnim.PlayRunning(true);
        }

        else
        {
            velocity = new Vector3(0, velocity.y);
            playerAnim.PlayRunning(false);
        }

        if (isGrounded && !Input.GetKeyDown(jump))
        {
            doubleJump = false;
        }

        //Jumping
        if (Input.GetKeyDown(jump))
        {
            //if flik
            if (enableDoubleJump)
            {
                if (isGrounded || doubleJump)
                {
                    playerAnim.PlayJump();
                    velocity = new Vector3(velocity.x, jumpPower);
                    doubleJump = !doubleJump;
                }
            }
            // if flak
            else
            {
                if (isGrounded)
                {
                    playerAnim.PlayJump();
                    velocity = new Vector3(velocity.x, jumpPower);
                }
            }
        }

        rbComponent.velocity = velocity;

        //**Insert Crouching below this line**
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            doubleJump = true;
            isGrounded = false;
        }
    }
}
