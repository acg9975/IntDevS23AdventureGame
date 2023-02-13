using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    float horizontalMove;
    public float speed;
    Rigidbody2D myBody;

    bool grounded = false;
    public float castDist = 0.2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;
    public float jumpLimit = 2f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for movement in update, do physics in fixed update
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        //left and right
        horizontalMove = Input.GetAxis("Horizontal");
    }

    private void playerJump()
    {
        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump = false;
        }

        //this checks if the velocity on the y
        //if it is increasing, then decrease gravity to allow for larger jumps
        //if it is decreasing or less than 0, then use the fall gravity rate
            //gravityfall = when player is falling
            //gravityscale = when player is in the air
        if (myBody.velocity.y > 0)
        {
            //gravity scale is used when player is going upwards 
            myBody.gravityScale = gravityScale;
        }
        else if (myBody.velocity.y < 0)
        {
            //used when player is falling
            myBody.gravityScale = gravityFall;
        }
    }

    private void playerMove()
    {
        //set the movespeed - we dont need to use deltatime in fixed update
        //we then add the velocity to it. 
        float moveSpeed = horizontalMove * speed;
        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0);
    }

    private void checkGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);

        if (hit.collider != null && hit.transform.name == "Ground")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);
    }

    private void FixedUpdate()
    {
        //fixed update goes at a constant rate and is particularly useful for physics movement
        playerMove();
        playerJump();
        checkGrounded();
    }
}
