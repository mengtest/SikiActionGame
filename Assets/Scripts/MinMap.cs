using UnityEngine;
using System.Collections;

public class MinMap : MonoBehaviour {
    public GameObject EnemyIcon;
    public GameObject BossIcon;
    public static MinMap Instance;


    void Start()
    {
        Instance = this;
    }

    public GameObject AddBossIcon()
    {
        return AddIcon(BossIcon);
    }

    public GameObject AddEnemyIcon()
    {
        return AddIcon(EnemyIcon);
    }

    private GameObject AddIcon(GameObject icon)
    {
        GameObject go = NGUITools.AddChild(gameObject,icon);
        return go;
    }
}
