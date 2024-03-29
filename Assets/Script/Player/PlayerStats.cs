using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;

    public int[] toLevelUp;

    public int[] hpLevel;
    public int[] atkLevel;
    public int[] defLevel;

    public int currentHp;
    public int currentAtk;
    public int currentDef;

    private PlayerHealth thePlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        currentHp = hpLevel[currentLevel];
        currentAtk = atkLevel[currentLevel];
        currentDef = defLevel[currentLevel];

        GetComponent<PlayerHealth>().setMaxHealthPlayer(currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentExp >= toLevelUp[currentLevel])
        {
            levelUp();
        }
    }

    public void addExp(int expToAdd)
    {
        currentExp += expToAdd;
    }

    public void levelUp()
    {
        currentLevel++;
        currentHp = hpLevel[currentLevel];
        currentAtk = atkLevel[currentLevel];
        currentDef = defLevel[currentLevel];

        thePlayerHealth.maxHealth = currentHp;
    }

    public void setMaxHP(int hp)
    {
        currentHp = hp;
    }
}
