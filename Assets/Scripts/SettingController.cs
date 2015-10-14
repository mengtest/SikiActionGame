using UnityEngine;
using System.Collections;

public class SettingController : MonoBehaviour {

    public Mesh[] handMeshs;
    private int handMeshIndex = 0;
    public SkinnedMeshRenderer playerHandMesh;


    public Mesh[] headMeshs;
    private int headMeshIndex = 0;
    public SkinnedMeshRenderer playerheadMesh;

    public  Color Purple;
    public Color White ;
    [HideInInspector]
    public Color[] colors;
    private int colorIndex;


    public static SettingController Instance;
    public void Start()
    {
        Instance = this;
        colors = new Color[]{ Color.blue, Color.cyan, Color.green, Purple, Color.red, White };
        DontDestroyOnLoad(gameObject);
    }

    public void OnHandChange()
    {
        playerHandMesh.sharedMesh = handMeshs[++handMeshIndex % handMeshs.Length];
    }

    public void OnHeadChange()
    {
        playerheadMesh.sharedMesh = headMeshs[++headMeshIndex % headMeshs.Length];
    }

    public void OnBlueColor()
    {
        this.OnColorChange(Color.blue);
        colorIndex = 0;
    }

    public void OnPurpleColor()
    {
        this.OnColorChange(Purple);
        colorIndex = 3;
    }

    public void OnCyanColor()
    {
        this.OnColorChange(Color.cyan);
        colorIndex = 1;

    }

    public void OnGreenColor()
    {
        this.OnColorChange(Color.green);
        colorIndex = 2;

    }

    public void OnRedColor()
    {
        this.OnColorChange(Color.red);
        colorIndex = 4;

    }

    public void OnWhite()
    {
        this.OnColorChange(White);
        colorIndex = 5;
    }

    public void OnColorChange(Color c)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Hero") as GameObject;
        int childCount = player.gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject go = player.gameObject.transform.GetChild(i).gameObject;
            if (go.name == "b_Bip")
            {
                continue;
            }
            go.renderer.material.color = c;
        }
    }

    private void SaveInfo()
    {
        PlayerPrefs.SetInt("handMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("headMeshIndex", headMeshIndex);
        PlayerPrefs.SetInt("colorIndex", colorIndex);
    }



    public void  SetPlayerConfigInfo()
    {
        GameObject player = GameObject.FindWithTag(Consts.PlayerTag);
        int childCount = player.gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject go = player.gameObject.transform.GetChild(i).gameObject;
            if (go.name == "b_Bip")
            {
                continue;
            }
            go.renderer.material.color = colors[colorIndex];
        }

        //head mesh
        SkinnedMeshRenderer playerHeadMesh = player.transform.FindChild("AHead").renderer as SkinnedMeshRenderer;
        playerHeadMesh.sharedMesh = headMeshs[headMeshIndex];

        SkinnedMeshRenderer playerHandMesh = player.transform.FindChild("DHand").renderer as SkinnedMeshRenderer;
        playerHandMesh.sharedMesh = handMeshs[handMeshIndex];
    }

    public void OnPlayStart()
    {
        SaveInfo();
        Application.LoadLevel(1);
    }
}
