using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    public MapLevelSO mapLevelSO;

    Timer cooldownPerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cooldownPerSpawn = new Timer();
        cooldownPerSpawn.SetDuration(mapLevelSO.cooldownPerSpawn);
        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownPerSpawn.IsDone())
        {
            SpawnMonster();
        }
        else
        {
            cooldownPerSpawn.Update(Time.deltaTime);
        }
    }

    void SpawnMonster()
    {
        for (int i = 0; i < mapLevelSO.numbersMonsterPerSpawn; i++)
        {
            int randomIndex = Random.Range(0, mapLevelSO.monsters.Count);
            Vector3 spawnPos = Vector3.zero;
            GameObject monster = Instantiate(mapLevelSO.monsters[randomIndex], spawnPos, Quaternion.identity);
            // monster.GetComponent<MonsterController>().MovingToTarget();
        }
        cooldownPerSpawn.Reset();
    }
}
