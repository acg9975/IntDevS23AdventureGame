using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class improvedController : MonoBehaviour
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

    Animator anim;
    SpriteRenderer sr;

    //add sprinting

    bool hasJumped = false;


    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for movement in update, do physics in fixed update
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
            StartCoroutine(hasJumpedTimer());
        }

        //left and right
        horizontalMove = Input.GetAxis("Horizontal");

        //change animator
        if (horizontalMove > 0.1f)
        {
            anim.SetBool("walking", true);
            sr.flipX = true;
        }
        else if (horizontalMove < -0.1f )
        {
            sr.flipX = false;
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    private void playerJump()
    {
        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump = false;
        }
        
        


        if (myBody.velocity.y > 0 && hasJumped)
        {
            myBody.gravityScale = gravityScale;
            //gravity scale is used when player is going upwards 
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

        //myBody.velocity += new Vector2(moveSpeed / 10, myBody.velocity.y / 12);
        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0);



    }

    private void checkGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);

        if (hit.collider != null && hit.transform.CompareTag("Ground"))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        //Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);
    }

    private void FixedUpdate()
    {
        //fixed update goes at a constant rate and is particularly useful for physics movement
        playerMove();
        playerJump();
        checkGrounded();
    }

    IEnumerator hasJumpedTimer()
    {

        hasJumped = true;
        yield return new WaitForSeconds(0.5f);
        hasJumped = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("winArea"))
        {
            StartCoroutine(winTime());
        }
        if (other.gameObject.CompareTag("lossArea"))
        {
            StartCoroutine(lossTime());
        }
    }

    IEnumerator winTime()
    {
        GameObject.FindGameObjectWithTag("winArea").GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator lossTime()
    {

            CinemachineVirtualCamera PlayerFollowCam = GameObject.Find("PlayerFollowCam").GetComponent<CinemachineVirtualCamera>();
            PlayerFollowCam.m_Follow = GameObject.Find("LossArea").transform;
            sr.rendererPriority = -50;
            myBody.gravityScale = 0.25f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

       

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}


