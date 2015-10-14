using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    private CharacterController cc;
    private Animator animator;

    private bool isAttackB;
    void Start()
    {

        SettingController.Instance.SetPlayerConfigInfo();
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Debug.Log("+++++++++++++++++++++:  " + animator);
        AddAttackListener();
    }

    private void AddAttackListener()
    {
        EventDelegate attackAEvent = new EventDelegate(this.Attack_A);
        GameObject go = GameObject.Find("Attack-Normal");
        go.GetComponent<UIButton>().onClick.Add(attackAEvent);

        EventDelegate attackArrangeEvent = new EventDelegate(this.Attack_Arrange);
        go = GameObject.Find("Attack-Arrange");
        go.GetComponent<UIButton>().onClick.Add(attackArrangeEvent);


        go = GameObject.Find("Attack");
        go = go.transform.Find("Big-Attack").gameObject;
        go.GetComponent<UIButton>().onClick.Add(attackAEvent);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (JoyStick.h != 0 || JoyStick.v != 0)
        {
            h = JoyStick.h;
            v = JoyStick.v;
        }
        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun")||
                animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerStand"))
            {
                // animator.SetBool(3, false);
                animator.SetBool("Wall", false);
                Vector3 tarVect = new Vector3(h, 0, v);
                transform.LookAt(tarVect + transform.position);
                cc.SimpleMove(transform.forward * speed);
            }
          
        }
        else
        {
            animator.SetBool("Wall", true);
        }
    }


    public void Attack_A()
    {
        //print("isAttackB : " + isAttackB);
        //print("nimator.GetAnimatorTransitionInfo(0)  : " + animator.GetAnimatorTransitionInfo(0).IsName("AttackA"));
        if (isAttackB && animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA"))
        {
            animator.SetTrigger("AttackB");
        }
        else
        {
            animator.SetTrigger("AttackA");
        }
    }


    public void Attack_Arrange()
    {
        animator.SetTrigger("AttackRange");
    }


    public void AttackB_Dect_Start()
    {
        isAttackB = true;
    }


    public void AttackB_Dect_End()
    {
        isAttackB = false;
    }
}
