using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    private float knockbackStartTime;

    [SerializeField]
    private float knockbackDuration;

    [SerializeField]
    private Vector2 knockbackSpeed;


    public float moveSpeed;
    public float jumpForce;
    public bool ButtonLeft;
    public bool ButtonRight;
    private bool canJump;
    private bool facingRight = true;   
    private bool knockback;


    

    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ButtonLeft = false;
        ButtonRight = false;
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckKnockback();
    }

    private void FixedUpdate()
    {
        float move;
        Vector3 characterScale = transform.localScale;

        if (ButtonLeft && !knockback)
        {
            move = -moveSpeed * Time.deltaTime;
            characterScale.x = -1;
            facingRight = false;
        }
        else if (ButtonRight && !knockback)
        {
            move = moveSpeed * Time.deltaTime;
            characterScale.x = 1;
            facingRight = true;
        }
        else
        {
            move = 0;
        }

            rb.velocity = new Vector2(move, rb.velocity.y); //gerakin player sumbu x
            transform.localScale = characterScale; //player dapat menghadap kiri kanan
            animator.SetFloat("Speed",Mathf.Abs(move));

        AnimJumpandFall();
        if (canJump)
        {
            animator.SetFloat("Speed", Mathf.Abs(move)); //animasi jalan
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

   

    }

    public void jump()
    {
        if (canJump)
        {
           
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce)); //lompat sumbu y
            
        }

    }

    

    public void ButtonLeftDown()
    {
        ButtonLeft = true;
    }

    public void ButtonLeftUp()
    {
        ButtonLeft = false;
    }

    public void ButtonRightDown()
    {
        ButtonRight = true;
    }

    public void ButtonRightUp()
    {
        ButtonRight = false;
    }

    public void AnimJumpandFall()
    {
        animator.SetFloat("Jumping", rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
            
           
        }
    }

    public void Knockback(int direction)
    {
        knockback = true;
        knockbackStartTime = Time.time;
        rb.velocity = new Vector2(knockbackSpeed.x * direction, knockbackSpeed.y);
    }

    private void CheckKnockback()
    {
        if(Time.time >= knockbackStartTime + knockbackDuration && knockback)
        {
            knockback = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }

}

