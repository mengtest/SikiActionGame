using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour {

    private bool isPress;

    public static float h;
    public static float v;
	void Start () {
	
	}

    void OnPress(bool isPress)
    {
        this.isPress = isPress;
        if (!this.isPress)
        {
            transform.localPosition = Vector2.zero;
            h = 0;
            v = 0;
        }
    }



	// Update is called once per frame
	void Update () {
        if (isPress)
        {
            Vector2 tarPos = UICamera.lastTouchPosition;
            tarPos -= new Vector2(91, 91);
            //移动范围限制
            float dist = Vector2.Distance(Vector2.zero, tarPos);
            if (dist > 73)
            {
                tarPos = tarPos.normalized * 73;
            }
            transform.localPosition = tarPos;
            h = tarPos.x / 73;
            v = tarPos.y / 73;
            
           
        }
	}
}
