using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public Animator animator;
    private bool isAttacking = false;
    int indexAtk;
    private float waitTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            StartCoroutine("resetAtk");
        }
    }

    public void attacking()
    {
        if (!isAttacking)
        {
            animator.SetInteger("indexAtk", indexAtk++);
        }

        isAttacking = true;

    }

    IEnumerator resetAtk()
    {

        //fungsi buat wait time
        yield return new WaitForSeconds(waitTime);
        isAttacking = false;
        animator.SetInteger("indexAtk", 0);

    }
}
