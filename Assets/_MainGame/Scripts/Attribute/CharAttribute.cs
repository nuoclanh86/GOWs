using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttribute : Attribute
{
    protected int curHealth;
    protected int curDamage;
    protected int curArmour;
    
    protected float movementSpeed;

    protected override void Start()
    {
        base.Start();
        movementSpeed = attributeSO.movementSpeedAttribute;

        curHealth = health;
        curDamage = damage;
        curArmour = armour;
    }

    public int GetCurHealth() { return curHealth; }
    public int GetCurDamage() { return curDamage; }
    public int GetCurArmour() { return curArmour; }
    public float GetMovementSpeed() { return movementSpeed; }

    public void AddAttributeHealth(int val) { health += val; }
    public void AddAttributeDamage(int val) { damage += val; }
    public void AddAttributeArmour(int val) { armour += val; }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter other : " + other.name);
        if (other.tag == "Player" || other.tag == "Monster")
        {
            CharAttribute cA = other.GetComponent<CharAttribute>();
            cA.WasHit(this.curDamage);
        }
    }

    public void WasHit(int attDmg)
    {
        Debug.Log("[GOWs] " + this.name + " was hit " + attDmg);
        curHealth -= (attDmg - curArmour);
        UpdateHPBar();
    }

    public void RestoreHP(int amount)
    {
        if (curHealth < health)
        {
            curHealth += amount;
            if (curHealth > health)
                curHealth = health;
        }
    }

    protected virtual void UpdateHPBar()
    {

    }

    protected virtual void TriggerCharacterDead()
    {

    }
}
