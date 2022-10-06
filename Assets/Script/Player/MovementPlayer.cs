using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    //public static MovementPlayer instance;

    //movement and jump
    public float moveSpeed;
    public float jumpForce;
    public bool ButtonLeft;
    public bool ButtonRight;
    private bool canJump;
    private bool facingRight = true;
    //public bool isAttacking = false;

    //invunerable
    private Renderer renderPlayer;
    private Color c;
    public float invulnerableTime;

    public bool isHitCheck = false;
    [SerializeField] private float knockback;

    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ButtonLeft = false;
        ButtonRight = false;
        canJump = false;

        renderPlayer = GetComponent<Renderer>();
        c = renderPlayer.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float move;
        Vector3 characterScale = transform.localScale;

        if (ButtonLeft)
        {
            move = -moveSpeed * Time.deltaTime;
            characterScale.x = -1;
            facingRight = false;
        }
        else if (ButtonRight)
        {
            move = moveSpeed * Time.deltaTime;
            characterScale.x = 1;
            facingRight = true;
        }
        else
        {
            move = 0;
        }

        if (isHitCheck)
        {
            if (facingRight)
            {
                rb.velocity = new Vector2(-knockback, knockback);
                //rb.AddForce(new Vector2(-knockback, knockback));
                StartCoroutine("Invulnerable");
            }
            else
            {
                rb.velocity = new Vector2(knockback, knockback);
                //rb.AddForce(new Vector2(knockback, knockback));
                StartCoroutine("Invulnerable");
            }
            isHitCheck = false;
        }

        rb.velocity = new Vector2(move, rb.velocity.y); //gerakin player sumbu x
        transform.localScale = characterScale; //player dapat menghadap kiri kanan
        animator.SetFloat("Speed", Mathf.Abs(move));

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

    //public void Attack()
    //{
    //    if(!isAttacking)
    //    {
    //        isAttacking = true;
    //    }
    //}

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

    IEnumerator Invulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        c.a = 0.5f;
        renderPlayer.material.color = c;

        //fungsi buat wait time
        yield return new WaitForSeconds(invulnerableTime);

        Physics2D.IgnoreLayerCollision(8, 9, false);
        c.a = 1f;
        renderPlayer.material.color = c;
    }

    public void isHitTrue (bool isHit)
    {
        isHitCheck = isHit;
    }

}

