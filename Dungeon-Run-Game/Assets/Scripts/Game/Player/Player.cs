using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]public float Speed = 1;
    [SerializeField] public float jumpPower = 500;
    Rigidbody2D rb;
    float horizontalValue;

    const float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] bool isGrounded;
    bool facingRight = true;
    bool jump;
    bool isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!CanMove())
        {
            return;
        }

        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        
    }
    private void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    bool CanMove()
    {
        bool can = true;
        if (FindObjectOfType<InteractionSystem>().isExamining)
        {
            can = false;
            
        }
        if (isDead)
        {
            can = false;
        }
        return can;
    }
    void GroundCheck()
    {
        isGrounded = false;

        //check if Player collide with ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    void Move(float dir, bool jumpFlag)
    {

        //JUMPING
        if (isGrounded && jumpFlag)
        {
            isGrounded = false;
            jumpFlag = false;
            //add Jump Force
            rb.AddForce(new Vector2(0f, jumpPower));
        }

        //set value of x using dir and speed
        float xVal = dir * Speed * 100 * Time.fixedDeltaTime;
        //Creating the Vector2 for the velocity
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        //Set the player's velocity
        rb.velocity = targetVelocity;

        //Player Look direction
        //if look right and move left, flip the player spirit
        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        //if look levt and move right, flip the player spirit
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

    }

    public void Die()
    {
        isDead = true;    
    }

}
