using System;
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
    [SerializeField] SpriteRenderer sr;

    [Header("Abilities")]
    [SerializeField] bool enableDoubleJump;
    [SerializeField] bool enableCrouch;
    [SerializeField] bool enableCrawl;
    public KeyCode crouch = KeyCode.DownArrow;
    bool doubleJump;
    public bool moving;
    BoxCollider2D boxCollider;
    Rigidbody2D rb;

    [Header("Player Name")]
    public bool flik;
    public bool flak;
    

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
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
            playerAnim.PlayRunning(true);
            sr.flipX = true;
            moving = true;
        }

        else if (Input.GetKey(right))
        {
            velocity = new Vector3(movementSpeed, velocity.y);
            sr.flipX = false;
            playerAnim.PlayRunning(true);
            moving = true;
        }

        else
        {
            velocity = new Vector3(0, velocity.y);
            playerAnim.PlayRunning(false);
            moving = false;
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
        if (!isGrounded)
        {
            moving = true;
        }
        rbComponent.velocity = velocity;

        //**Insert Crouching below this line**/
        Crouching();
    }

    private void Crouching()
    {
        if (enableCrouch)
        {
            if (Input.GetKey(crouch))
            {
                playerAnim.PlayCrouch(true);
                ReducePlayerHeight(true);
                Crawling();

            }else if (Input.GetKeyUp(crouch))
            {
                ReducePlayerHeight(false);
                playerAnim.PlayCrouch(false);
                playerAnim.PlayCrawl(false);
            }
        }
    }

    private void Crawling()
    {
        if(playerAnim.isRunning)
        {
            playerAnim.PlayCrawl(true);
        }
        else
        {
            playerAnim.PlayCrawl(false);
        }
    }

    void ReducePlayerHeight(bool value)
    {
        if(value)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            boxCollider.size = new Vector2(1f, 0.5f);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            boxCollider.size = new Vector2(1f, 1.3f);
        }
    }

    public bool playerMoving
    {
        get
        {
            return moving;
        }
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
