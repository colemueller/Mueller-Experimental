using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTex : MonoBehaviour {

    public Material mat;

    public static int n;

    private void Awake()
    {
        n = 1;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, mat);
    }

}
