using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    public MapLevelSO mapLevelSO;
    [SerializeField] List<GameObject> spawnAreas;

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
        int randomSpawnAreaIndex = Random.Range(0, spawnAreas.Count);
        Transform areaTransform = spawnAreas[randomSpawnAreaIndex].transform;
        float minX = areaTransform.position.x - areaTransform.localScale.x / 2;
        float maxX = areaTransform.position.x + areaTransform.localScale.x / 2;
        float minZ = areaTransform.position.z - areaTransform.localScale.z / 2;
        float maxZ = areaTransform.position.z + areaTransform.localScale.z / 2;
        for (int i = 0; i < mapLevelSO.numbersMonsterPerSpawn; i++)
        {
            int randomIndex = Random.Range(0, mapLevelSO.monsters.Count);
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), 1.0f, Random.Range(minZ, maxZ));
            GameObject monster = Instantiate(mapLevelSO.monsters[randomIndex], spawnPos, Quaternion.identity);
            // monster.GetComponent<MonsterController>().MovingToTarget();

        }
        ActionPhaseManager.GetInstance().UpdateTotalMonsterOnScreen(mapLevelSO.numbersMonsterPerSpawn);
        cooldownPerSpawn.Reset();
    }
}
