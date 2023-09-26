using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapLevelSO", menuName = "Assests/MapLevelSO")]
public class MapLevelSO : ScriptableObject
{
    public List<GameObject> monsters;
    public float cooldownPerSpawn;
    public int numbersMonsterPerSpawn;
}
