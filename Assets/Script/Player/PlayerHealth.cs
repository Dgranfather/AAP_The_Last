using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    public int iMaxhP;
    public int iCurrentHp;

    [SerializeField]
    private GameObject
        particleBody,
        particleBlood;

    // Start is called before the first frame update
    void Start()
    {
      
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {

        healthBar.SetMaxHealthText(maxHealth);
        healthBar.SetCurrentHealthText(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetValue(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(particleBody, transform.position, particleBody.transform.rotation);
        Instantiate(particleBlood, transform.position, particleBlood.transform.rotation);
        Destroy(gameObject);
    }

    public void setMaxHealthPlayer(int health)
    {

        iMaxhP = health;
        maxHealth = iMaxhP;
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }
}
