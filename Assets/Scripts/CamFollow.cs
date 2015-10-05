using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    public float moveSpeed = 2;

    private Vector3 detaDist = new Vector3(0f, 4.5f, -4.5f);
    private Transform playerTrans;

    private GameObject player;
	// Use this for initialization
	void Start () {
        playerTrans = GameObject.FindWithTag(Consts.PlayerTag).transform;
	}
	
	// Update is called once per frame
	void Update () {
	    //Camera Position
        Vector3 targetPos = playerTrans.position + detaDist;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed*Time.deltaTime);

        ////Rotation
        Quaternion tarRotation = Quaternion.LookRotation(playerTrans.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, tarRotation, moveSpeed * Time.deltaTime);
       
        //Debug.Log(player.name);
        //Debug.Log(player.transform.position);
	}
}
