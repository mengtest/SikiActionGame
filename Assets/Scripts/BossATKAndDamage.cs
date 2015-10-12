using UnityEngine;
using System.Collections;

public class BossATKAndDamage : ATKAndDamage {
    private GameObject player;
    public float attack01;
    public float attack02;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(Consts.PlayerTag);
	}

    public void Attack01()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < ATKDist)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(attack01);
        }
    }

    public void Attack02()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < ATKDist)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(attack02);
        }
    }
}
