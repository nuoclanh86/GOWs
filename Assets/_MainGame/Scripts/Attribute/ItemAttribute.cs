using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttribute : Attribute
{  
    public void AddItemAttributeToChar(ref CharAttribute charAttribute)
    {
        charAttribute.AddAttributeHealth(this.health);
        charAttribute.AddAttributeDamage(this.damage);
        charAttribute.AddAttributeArmour(this.armour);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter other : " + other.name);
        if (other.tag == "Monster")
        {
            CharAttribute cA = other.GetComponent<CharAttribute>();
            cA.WasHit(this.damage);
        }
    }

}
