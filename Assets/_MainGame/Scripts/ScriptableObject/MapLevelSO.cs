using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapLevelSO", menuName = "Assests/MapLevelSO")]
public class MapLevelSO : ScriptableObject
{
    public List<GameObject> monsters;
    public float cooldownPerSpawn;
    public int numbersMonsterPerSpawn;

    //distance from spawn pos to monster
    [Tooltip("Distance from spawnpos to mainplayer.")]
    public float maxDistanceSpawn = 30.0f;
    [Tooltip("Distance from spawnpos to mainplayer.")]
    public float minDistanceSpawn = 3.0f;

    //cheat
    public int cheatHPPlayer = 0;
}
