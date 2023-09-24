using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int curHealth;
    [SerializeField] protected int baseDamage;
    protected int curDamage;
    [SerializeField] protected int baseArmour;
    protected int curArmour;

    void Start()
    {
        curHealth = maxHealth;
        curDamage = baseDamage;
        curArmour = baseArmour;
    }

    public int GetCurHealth() { return curHealth; }
    public int GetCurDamage() { return curDamage; }
    public int GetCurArmour() { return curArmour; }

    public void WasHit(int attDmg)
    {
        Debug.Log("this : " + this.name + " was hit " + attDmg);
        curHealth -= (attDmg - curArmour);
        UpdateHPBar();
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

    protected virtual void UpdateHPBar()
    {

    }
}
