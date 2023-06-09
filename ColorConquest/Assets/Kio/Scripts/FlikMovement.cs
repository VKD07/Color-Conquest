using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlikMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    [SerializeField] float movementSpeed = 5f;

    [SerializeField] float jumpPower = 20f;

    public bool isGrounded;
    bool doubleJump;

    [SerializeField] Rigidbody2D rb;

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
        }

        else if (Input.GetKey(right))
        {
            velocity = new Vector3(movementSpeed, velocity.y);
            transform.rotation = Quaternion.identity;
            print("moving right");
        }

        else
        {
            velocity = new Vector3(0, velocity.y);
        }

        if (isGrounded && !Input.GetKeyDown(jump))
        {
            doubleJump = false;
        }

        if (Input.GetKeyDown(jump))
        {
            if (isGrounded|| doubleJump)
            {
                velocity = new Vector3(velocity.x, jumpPower);
                doubleJump = !doubleJump;
            }

            print("jumping");
        }

        rbComponent.velocity = velocity;
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
