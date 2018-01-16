using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControls : MonoBehaviour {

    private LaunchArcRenderer arcRender_1;
    private LaunchArcRenderer arcRender_2;

    public GameObject catapult_1;
    public GameObject catapult_2;

    private bool canFire_1 = true;
    private bool canFire_2 = false;

    public GameObject darken;

    // Use this for initialization
    void Start () {
        arcRender_1 = catapult_1.transform.GetChild(1).GetChild(0).GetComponent<LaunchArcRenderer>();
        arcRender_2 = catapult_2.transform.GetChild(1).GetChild(0).GetComponent<LaunchArcRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (canFire_1)
        {
            
            //Charge velocity
            if (Input.GetKey(KeyCode.Space))
            {
                arcRender_1.v += 0.05f;
            }
            else
            {
                //Increase Angle
                if (Input.GetKey(KeyCode.A))
                {
                    arcRender_1.angle += 0.3f;
                }
                //Decrease Angle
                else if (Input.GetKey(KeyCode.D))
                {
                    arcRender_1.angle -= 0.3f;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                canFire_1 = false;
                StartCoroutine(Fire(1));
            }


            arcRender_1.RenderArc();
        }
        if (canFire_2)
        {

            //Charge velocity
            if (Input.GetKey(KeyCode.Space))
            {
                arcRender_2.v += 0.05f;
            }
            else
            {
                //Increase Angle
                if (Input.GetKey(KeyCode.A))
                {
                    arcRender_2.angle += 0.3f;
                }
                //Decrease Angle
                else if (Input.GetKey(KeyCode.D))
                {
                    arcRender_2.angle -= 0.3f;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                canFire_2 = false;
                StartCoroutine(Fire(2));
            }


            arcRender_2.RenderArc();
        }
    }

    IEnumerator Fire(int playerNum)
    {
        yield return new WaitForSeconds(1f);

        if (playerNum == 1)
        {
            darken.transform.position = new Vector3(-4.5f, 0, 0);
            canFire_2 = true;
            catapult_2.SetActive(true);
            catapult_1.SetActive(false);
            arcRender_2.v = 5f;
        }
        else
        {
            darken.transform.position = new Vector3(4.5f, 0, 0);
            canFire_1 = true;
            catapult_2.SetActive(false);
            catapult_1.SetActive(true);
            arcRender_1.v = 5f;
        }
    }
}
