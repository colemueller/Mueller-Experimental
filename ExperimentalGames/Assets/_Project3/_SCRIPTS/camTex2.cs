using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTex2 : MonoBehaviour {

    public Material mat;
    

    private void Awake()
    {
        int n = Random.Range(1, 4);

        switch (n)
        {
            case 1:
                mat = (Material)Resources.Load("crack_1", typeof(Material));
                break;
            case 2:
                mat = (Material)Resources.Load("crack_2", typeof(Material));
                break;
            case 3:
                mat = (Material)Resources.Load("crack_3", typeof(Material));
                break;
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, mat);
    }

}
