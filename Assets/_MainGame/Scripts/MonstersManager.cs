using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    public MapLevelSO mapLevelSO;
    // [SerializeField] List<GameObject> spawnAreas;
    [SerializeField] float maxDistanceSpawn = 30.0f;
    [SerializeField] float minDistanceSpawn = 3.0f;
    [HideInInspector] public List<GameObject> monstersSpawnedList;

    Timer cooldownPerSpawn;

    private static MonstersManager _instance;

    public static MonstersManager GetInstance()
    {
        return _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        cooldownPerSpawn = new Timer();
        cooldownPerSpawn.SetDuration(mapLevelSO.cooldownPerSpawn);

        monstersSpawnedList = new List<GameObject>();

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
        Vector3 playerPos = Vector3.zero;
        if (ActionPhaseManager.GetInstance().GetMainPlayer())
            playerPos = ActionPhaseManager.GetInstance().GetMainPlayer().transform.position;
        float minX = playerPos.x - maxDistanceSpawn;
        float maxX = playerPos.x + maxDistanceSpawn;
        float minZ = playerPos.z - maxDistanceSpawn;
        float maxZ = playerPos.z + maxDistanceSpawn;

        Vector3 spawnPos = Vector3.zero;
        for (int i = 0; i < mapLevelSO.numbersMonsterPerSpawn; i++)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
            if (Vector3.Distance(spawnPos, playerPos) < minDistanceSpawn)
            {
                spawnPos += ((spawnPos - playerPos).normalized * minDistanceSpawn);
            }

            bool createdMonster = false;
            if (monstersSpawnedList.Count > 0)
            {
                foreach (GameObject m in monstersSpawnedList)
                {
                    if (m.activeInHierarchy == false)
                    {
                        RebornDeadMonster(m, spawnPos);
                        createdMonster = true;
                    }
                }
            }
            if (createdMonster == false)
            {
                int randomIndex = Random.Range(0, mapLevelSO.monsters.Count);
                GameObject go = Instantiate(mapLevelSO.monsters[randomIndex], spawnPos, Quaternion.identity);
                monstersSpawnedList.Add(go);
            }
        }
        ActionPhaseManager.GetInstance().UpdateTotalMonsterOnScreen(mapLevelSO.numbersMonsterPerSpawn);
        cooldownPerSpawn.Reset();
    }

    void RebornDeadMonster(GameObject monster, Vector3 pos)
    {
        monster.SetActive(true);
        monster.transform.position = pos;
        monster.GetComponent<MonsterController>().RebornMonster();
        monster.GetComponent<MonsterAttribute>().RebornMonster();
    }
    // void SpawnMonster()
    // {
    //     int randomSpawnAreaIndex = Random.Range(0, spawnAreas.Count);
    //     Transform areaTransform = spawnAreas[randomSpawnAreaIndex].transform;
    //     float minX = areaTransform.position.x - areaTransform.localScale.x / 2;
    //     float maxX = areaTransform.position.x + areaTransform.localScale.x / 2;
    //     float minZ = areaTransform.position.z - areaTransform.localScale.z / 2;
    //     float maxZ = areaTransform.position.z + areaTransform.localScale.z / 2;

    //     Vector3 playerPos = Vector3.zero;
    //     if (ActionPhaseManager.GetInstance().GetMainPlayer())
    //         playerPos = ActionPhaseManager.GetInstance().GetMainPlayer().transform.position;
    //     int count, COUNTNUM = 5;
    //     float minDistance = Mathf.Infinity, curDistance;
    //     Vector3 spawnPos = Vector3.zero;
    //     Vector3 nearestSpawnPos = spawnPos;
    //     for (int i = 0; i < mapLevelSO.numbersMonsterPerSpawn; i++)
    //     {
    //         int randomIndex = Random.Range(0, mapLevelSO.monsters.Count);
    //         spawnPos = new Vector3(Random.Range(minX, maxX), 1.0f, Random.Range(minZ, maxZ));
    //         //random "count" times and take a pos nearest with player
    //         count = COUNTNUM;
    //         while (count > 0)
    //         {
    //             curDistance = Vector3.Distance(spawnPos, playerPos);
    //             if (minDistance > curDistance)
    //             {
    //                 nearestSpawnPos = spawnPos;
    //                 minDistance = curDistance;
    //                 Debug.Log("nearestSpawnPos : " + nearestSpawnPos);
    //             }
    //             count--;
    //         }
    //         GameObject monster = Instantiate(mapLevelSO.monsters[randomIndex], spawnPos, Quaternion.identity);
    //         // monster.GetComponent<MonsterController>().MovingToTarget();

    //     }
    //     ActionPhaseManager.GetInstance().UpdateTotalMonsterOnScreen(mapLevelSO.numbersMonsterPerSpawn);
    //     cooldownPerSpawn.Reset();
    // }
}
