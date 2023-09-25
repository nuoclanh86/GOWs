using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Assests/NewItem")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public int itemAddHealth;
    public int itemAddDamage;
    public int itemAddArmour;
}
