using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttribute : Attribute
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter other : " + other.name);
        if (other.tag == "Player")
        {
            PlayerAttribute pA = other.GetComponent<PlayerAttribute>();
            pA.WasHit(this.curDamage);
        }
    }
}