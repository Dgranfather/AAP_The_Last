using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAttack : MonoBehaviour
{

    public Animator animator;
    public static CombatAttack instance;

    [SerializeField]
    private float attack1Radius, attack1Damage, attack2Radius, attack2Damage, attack3Radius, attack3Damage;

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

    public GameObject atkEffect;
    public GameObject atkPos;

    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
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
            GameObject instanceAtk = (GameObject)Instantiate(atkEffect, atkPos.transform.position, Quaternion.identity);
            Destroy(instanceAtk, 2f);
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


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
        Gizmos.DrawWireSphere(attack2HitBoxPos.position, attack2Radius);
        Gizmos.DrawWireSphere(attack3HitBoxPos.position, attack3Radius);
    }


}
