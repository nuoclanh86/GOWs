using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChar", menuName = "Assests/NewChar")]
public class CharScriptableObject : ScriptableObject
{
    public string charName;
    public int charBaseHealth;
    public int charBaseDamage;
    public int charBaseArmour;
}
