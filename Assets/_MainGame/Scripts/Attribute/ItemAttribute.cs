using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttribute : Attribute
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter other : " + other.name + " by " + this.name);
        if (other.tag == "Monster")
        {
            CharAttribute cA = other.GetComponent<CharAttribute>();
            cA.WasHit(this.damage);
        }
    }

}
