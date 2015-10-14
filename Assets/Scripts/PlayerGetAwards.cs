using UnityEngine;
using System.Collections;

public class PlayerGetAwards : MonoBehaviour {

    private GameObject Player;
    public GameObject[] weapons;

    void Start()
    {
        Player = GameObject.FindWithTag(Consts.PlayerTag);
    }
    public void GetAwards(AwardsType type)
    {
        string tag = string.Empty;
        if (type == AwardsType.Gun)
        {
            tag = Consts.Gun;
        }
        else if (type == AwardsType.Rapier)
        {
            tag = Consts.Rapier;
        }
        else
        {
            tag = Consts.Sword;
        }
        foreach (GameObject go in weapons)
        {
            if (go.tag == tag)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }
}
