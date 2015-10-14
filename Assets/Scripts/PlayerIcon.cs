using UnityEngine;
using System.Collections;

public class PlayerIcon : MonoBehaviour {

    private Transform playerTrans;
	// Use this for initialization
	void Start () {
        playerTrans = GameObject.FindWithTag(Consts.PlayerTag).transform;
	}
	
	// Update is called once per frame
	void Update () {
        float y = playerTrans.localEulerAngles.y;
        gameObject.transform.localEulerAngles = new Vector3(0, 0, -y);
	}
}
