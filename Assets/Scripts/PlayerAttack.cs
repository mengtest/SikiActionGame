using UnityEngine;
using System.Collections;

public class PlayerAttack : ATKAndDamage {

    public float attackA;
    public float attackB;
    public float attackRange;
    public void AttackA()
    {
        GameObject enemy = null;
        float minDist =float.MaxValue;
        foreach (GameObject go in EnemySpawn.Instance.enemys)
        {
            float dist = Vector3.Distance(transform.position, go.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                enemy = go;
            }
        }
        if (enemy != null && minDist <= ATKDist)
        {
            transform.LookAt(enemy.transform.position);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackA);
        }
    }

    public void AttackB()
    {
        GameObject enemy = null;
        float minDist = float.MaxValue;
        foreach (GameObject go in EnemySpawn.Instance.enemys)
        {
            float dist = Vector3.Distance(transform.position, go.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                enemy = go;
            }
        }
        if (enemy != null && minDist <= ATKDist)
        {
            transform.LookAt(enemy.transform.position);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }
    }

    public void AttackGun()
    {

    }


    public void AttackRange()
    {
        foreach (GameObject go in EnemySpawn.Instance.enemys)
        {
            float dist = Vector3.Distance(transform.position, go.transform.position);
            if(dist <= ATKDist) 
            {
                go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
                
            }
        }

    }
}
