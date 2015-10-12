using UnityEngine;
using System.Collections;

public class MonsterATKAndDamage : ATKAndDamage {

    private GameObject player;
    public float normalAttack = 10f;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(Consts.PlayerTag);
	}

    public void MonAttack()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= ATKDist)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);

        }
    }
}
