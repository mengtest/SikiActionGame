using UnityEngine;
using System.Collections;

public class ATKAndDamage : MonoBehaviour {


    public float hp;
    public float ATKDist;
    protected Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }
        if (hp > 0)
        {
            if(this.tag != Consts.PlayerTag)
            animator.SetTrigger("Damage");
        }
        else
        {
            animator.SetTrigger("Death");
            EnemySpawn.Instance.enemys.Remove(gameObject);
            Destroy(gameObject, 2);
        }

        if (this.tag == Consts.BossTag)
        {
            Instantiate(Resources.Load("HitBoss"), transform.position+Vector3.up*0.8f, transform.rotation);
        }
        else if (this.tag == Consts.MonsterTag)
        {
            Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up * 0.8f, transform.rotation);
        }
    }
}
