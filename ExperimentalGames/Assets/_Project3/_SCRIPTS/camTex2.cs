using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTex2 : MonoBehaviour {

    public Material mat;
    public float scaleX;
    public float scaleY;
    public p3GM script;
    

    private void Awake()
    {
        script = GameObject.Find("GM").GetComponent<p3GM>();
        int n = camTex.n;
       
        switch (n)
        {
            case 1:
                mat = (Material)Resources.Load("crack_1", typeof(Material));
                //script.EndGame();
                break;
            case 2:
                mat = (Material)Resources.Load("crack_2", typeof(Material));
                break;
            case 3:
                mat = (Material)Resources.Load("crack_3", typeof(Material));
                break;
            case 4:
                mat = (Material)Resources.Load("crack_4", typeof(Material));
                break;
            case 5:
                mat = (Material)Resources.Load("crack_5", typeof(Material));
                break;
            case 6:
                mat = (Material)Resources.Load("crack_6", typeof(Material));
                break;
            case 7:
                mat = (Material)Resources.Load("crack_7", typeof(Material));
                break;
            case 8:
                mat = (Material)Resources.Load("crack_8", typeof(Material));
                break;
            case 9:
                mat = (Material)Resources.Load("crack_8", typeof(Material));
                script.EndGame();
                break;
        }

        camTex.n += 1;
    }

    void Update()
    {
        
        //mat.SetTextureScale("_VigTex", new Vector2(scaleX, scaleY));
       // mat.SetTextureOffset("_VigTex", new Vector2(scaleX, scaleY));

    }

        void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, mat);
    }

}
