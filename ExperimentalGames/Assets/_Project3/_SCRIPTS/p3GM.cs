using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p3GM : MonoBehaviour {

    public Material vig;
    private float currentVig;
    private float yVelocity = 0.0F;
    public float smoothTime;
    private bool doSmooth = false;
    private bool fadeIn = false;
    public Text txt;

    // Use this for initialization
    void Start () {
        currentVig = vig.GetFloat("_VigIntensity");
	}
	
	// Update is called once per frame
	void Update () {
        if (doSmooth)
        {
            currentVig = vig.GetFloat("_VigIntensity");
            vig.SetFloat("_VigIntensity", currentVig + 0.2f);
            if(currentVig > 24)
            {
                doSmooth = false;
                fadeIn = true;
            }
        }

        if (fadeIn)
        {
            float currentVis = txt.color.a;
            txt.color = new Color(255, 255, 255, currentVis + 0.01f);

            if(currentVis == 255)
            {
                fadeIn = false;
            }
        }
    }

    public void EndGame()
    {
        doSmooth = true;
    }

    
}
