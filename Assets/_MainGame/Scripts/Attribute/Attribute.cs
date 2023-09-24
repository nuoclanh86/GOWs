using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int curHealth;
    [SerializeField] int baseDamage;
    int curDamage;
    [SerializeField] int baseArmour;
    int curArmour;

    void Start()
    {
        curHealth = maxHealth;
    }

    public int GetCurHealth() { return curHealth; }
    public int GetCurDamage() { return curDamage; }
    public int GetCurArmour() { return curArmour; }

    public void Hit(int attDmg)
    {
        curHealth -= (attDmg - curArmour);
    }

    public void RestoreHP(int amount)
    {
        if (curHealth < maxHealth)
        {
            curHealth += amount;
            if (curHealth > maxHealth)
                curHealth = maxHealth;
        }
    }
}
