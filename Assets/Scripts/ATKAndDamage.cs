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
            animator.SetTrigger("Damage");
            if (this.tag == Consts.BossTag)
            {
                Instantiate(Resources.Load("HitBoss"), transform.position, transform.rotation);
            }
            else if (this.tag == Consts.MonsterTag)
            {
                Instantiate(Resources.Load("HitMonster"), transform.position, transform.rotation);
            }
        }
        else
        {
            animator.SetTrigger("Death");
        }
    }
}
