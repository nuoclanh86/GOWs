using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttribute : MonoBehaviour
{
    public CharScriptableObject charSO;

    protected int maxHealth;
    protected int baseDamage;
    protected int baseArmour;


    protected int curHealth;
    protected int curDamage;
    protected int curArmour;

    protected void Start()
    {
        maxHealth = charSO.charBaseHealth;
        baseDamage = charSO.charBaseDamage;
        baseArmour = charSO.charBaseArmour;

        curHealth = maxHealth;
        curDamage = baseDamage;
        curArmour = baseArmour;
    }

    public int GetCurHealth() { return curHealth; }
    public int GetCurDamage() { return curDamage; }
    public int GetCurArmour() { return curArmour; }

    public void AddAttributeHealth(int val) { maxHealth += val; }
    public void AddAttributeDamage(int val) { baseDamage += val; }
    public void AddAttributeArmour(int val) { baseArmour += val; }

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
