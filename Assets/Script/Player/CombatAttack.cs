using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAttack : MonoBehaviour
{

    public Animator animator;
    public static CombatAttack instance;

    [SerializeField]
    private float attack1Radius, attack2Radius, attack3Radius ;

    [SerializeField]
    private int attack1Damage, attack2Damage, attack3Damage;

    [SerializeField]
    private Transform attack1HitBoxPos;

    [SerializeField]
    private Transform attack2HitBoxPos;

    [SerializeField]
    private Transform attack3HitBoxPos;

    [SerializeField]
    private LayerMask whatIsDamageable;


    public bool isAttacking = false;

    private AttackDetails attackDetails;
    private MovementPlayer MP;
    private PlayerHealth PH;
   
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        MP = GetComponent<MovementPlayer>();
        PH = GetComponent<PlayerHealth>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
        }
    }


    private void CheckAttackHitBox1()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable);


        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;

            foreach(Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
        }

    }

    private void CheckAttackHitBox2()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack2HitBoxPos.position, attack2Radius, whatIsDamageable);


        attackDetails.damageAmount = attack2Damage;
        attackDetails.position = transform.position;

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
        }

    }

    private void CheckAttackHitBox3()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack3HitBoxPos.position, attack3Radius, whatIsDamageable);


        attackDetails.damageAmount = attack3Damage;
        attackDetails.position = transform.position;

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
        }

    }

    private void Damage(AttackDetails attackDetails)
    {
        int direction;

        PH.TakeDamage(attackDetails.damageAmount);

        if(attackDetails.position.x < transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        MP.Knockback(direction);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
        Gizmos.DrawWireSphere(attack2HitBoxPos.position, attack2Radius);
        Gizmos.DrawWireSphere(attack3HitBoxPos.position, attack3Radius);
    }


}
