using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode crouch;

    [SerializeField] float movementSpeed = 5f;

    [SerializeField] float jumpPower = 20f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerAnimation playerAnim;

    //vince Added code
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var velocity = GetComponent<Rigidbody2D>().velocity;
        var rbComponent = GetComponent<Rigidbody2D>();


        if (Input.GetKey(left))
        {
            velocity = new Vector2(-movementSpeed, velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            print("moving left");
            playerAnim.PlayRunning(true);
        }

        else if (Input.GetKey(right))
        {
            velocity = new Vector3(movementSpeed, velocity.y);
            transform.rotation = Quaternion.identity;
            print("moving right");
            playerAnim.PlayRunning(true);
        }

        else
        {
            playerAnim.PlayRunning(false);
            velocity = new Vector3(0, velocity.y);
        }



        rbComponent.velocity = velocity;
    }

    void Jump()
    {

        if (Input.GetKeyDown(jump))
        {
            if (isGrounded)
            {
                playerAnim.PlayJump();
              //  velocity = new Vector3(velocity.x, jumpPower);
            }
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
            isGrounded = false;
        }
    }

}
