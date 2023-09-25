using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    public AttributeScriptableObject attributeSO;
    protected int health;
    protected int damage;
    protected int armour;

    protected virtual void Start()
    {
        health = attributeSO.healthAttribute;
        damage = attributeSO.damageAttribute;
        armour = attributeSO.armourAttribute;
    }

    public int GetHealth() { return health; }
    public int GetDamage() { return damage; }
    public int GetArmour() { return armour; }
}
