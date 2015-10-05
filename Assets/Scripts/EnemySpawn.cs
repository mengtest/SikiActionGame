using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

    public Transform[] spawnPos;
    public GameObject monsterGO;
    public GameObject bossGO;

    public List<GameObject> enemys;

    public static EnemySpawn Instance;
    public void Start()
    {
        SpawnEnemys(1);
        Instance = this;
    }


    public void SpawnEnemys(int level)
    {
        if (level <= 0)
        {
            level = 1;
        }
        int MonsterCount = 8 * level;
        int bossCount = (int)Mathf.Pow(2,level);
        StartCoroutine(SpawnEnemys(MonsterCount, bossCount));
    }

    IEnumerator SpawnEnemys(int MonsterCount , int bossCount)
    {
        while (MonsterCount > 0 || bossCount > 0)
        {
            int count = MonsterCount >= 4 ? 4 : MonsterCount;
            for (int i = 0; i < count; i++)
            {
                GameObject go = Instantiate(monsterGO) as GameObject;
                go.transform.position = spawnPos[i].position;
                enemys.Add(go);
            }
            MonsterCount -= count;

            yield return new WaitForSeconds(2);

            count = MonsterCount >= 2 ? 2 : bossCount;
            for (int i = 0; i < count; i++)
            {
                GameObject go = Instantiate(bossGO) as GameObject;
                go.transform.position = spawnPos[i].position;
                enemys.Add(go);
            }
            bossCount -= count;
            yield return new WaitForSeconds(2);
        }
        yield break;
    }


}
