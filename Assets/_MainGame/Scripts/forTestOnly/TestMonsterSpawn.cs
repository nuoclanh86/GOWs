using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonsterSpawn : MonoBehaviour
{
    public List<GameObject> listMonsters;
    public int numberMonstersPerRow;
    public float distanceBetweenMonsters;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosCenter = this.transform.position;
        Vector3 spawnPos = spawnPosCenter;
        int randomIndex = 0;
        for (int i = 0; i < numberMonstersPerRow; i++)
        {
            for (int j = 0; j < numberMonstersPerRow; j++)
            {
                randomIndex = Random.Range(0, listMonsters.Count);
                spawnPos.x = spawnPosCenter.x + (i * distanceBetweenMonsters);
                spawnPos.z = spawnPosCenter.z + (j * distanceBetweenMonsters);
                GameObject go = Instantiate(listMonsters[randomIndex], spawnPos, Quaternion.identity);
                go.GetComponent<MonsterAttribute>().enabled = false;
            }
        }
    }
}
