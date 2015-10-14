using UnityEngine;
using System.Collections;

public class MinMapIcon : MonoBehaviour {
    private GameObject icon;
    private GameObject player;
	// Use this for initialization
	void Start () {
        if (this.tag == Consts.BossTag)
        {
            icon = MinMap.Instance.AddBossIcon();
        }
        else if (this.tag == Consts.MonsterTag)
        {
            icon = MinMap.Instance.AddEnemyIcon();
        }
        player = GameObject.FindWithTag(Consts.PlayerTag);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = transform.position - player.transform.position;
        offset *= 10;
        icon.transform.localPosition = new Vector3(offset.x, offset.z, 0);
	}

    void OnDestroy()
    {
        if (icon != null)
        {
            Destroy(icon);
        }
    }
}
