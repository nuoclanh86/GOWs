using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttribute", menuName = "Assests/NewAttribute")]
public class AttributeScriptableObject : ScriptableObject
{
    public string nameAttribute;
    public int healthAttribute;
    public int damageAttribute;
    public int armourAttribute;
    public float movementSpeedAttribute;
}
