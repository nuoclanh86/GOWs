using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttribute : MonoBehaviour
{
    public ItemScriptableObject itemSO;

    protected int addHealth;
    protected int addDamage;
    protected int addArmour;

    protected void Start()
    {
        addHealth = itemSO.itemAddHealth;
        addDamage = itemSO.itemAddDamage;
        addArmour = itemSO.itemAddArmour;
    }

    public int GetValHealth() { return addHealth; }
    public int GetValDamage() { return addDamage; }
    public int GetValArmour() { return addArmour; }

    public void AddItemAttributeToChar(ref CharAttribute charAttribute)
    {
        charAttribute.AddAttributeHealth(this.addHealth);
        charAttribute.AddAttributeDamage(this.addDamage);
        charAttribute.AddAttributeArmour(this.addArmour);
    }

}
