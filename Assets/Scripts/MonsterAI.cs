using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

    private Transform transPlayer;
    private CharacterController cc;
    private Animator animator;

    public float attackTime = 3;
    private float _attackTime;
    public float minDistWithPlayer = 3;
    public float speed = 1.5f;
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        transPlayer = GameObject.FindWithTag("Hero").transform;
        _attackTime = attackTime;
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(transPlayer);

        float dist = Vector3.Distance(transform.position, transPlayer.position);
        if (dist > minDistWithPlayer)
        {
            _attackTime = attackTime;
            animator.SetTrigger("MonRun");
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.SimpleMove(transform.forward * speed);
            }
        }
        else
        {
            //attack
            _attackTime += Time.deltaTime;
            if (_attackTime > attackTime)
            {
                _attackTime = 0;
                animator.SetTrigger("MonAttack");
               
            }
        }
    }
}
