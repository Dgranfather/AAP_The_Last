using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int enemyDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            //collision.GetComponent<MovementPlayer>().isHitTrue(true);
        }
    }

}
