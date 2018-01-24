using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControls : MonoBehaviour {

    private LaunchArcRenderer arcRender_1;
    private LaunchArcRenderer arcRender_2;

    public GameObject catapult_1;
    public GameObject catapult_2;

	public Camera mainCam;
	public float camSpeed;

    private bool canFire_1 = true;
    private bool canFire_2 = false;

	public bool moveTo_1 = true;
	public bool moveTo_2 = false;

    public GameObject darken;
    public bool DoAnything = true;
    bool isPlayerOne = true;

	public Animator p1_anim;
    public Animator p2_anim;

    // Use this for initialization
    void Start () {
        arcRender_1 = catapult_1.transform.GetChild(1).GetChild(0).GetComponent<LaunchArcRenderer>();
        arcRender_2 = catapult_2.transform.GetChild(1).GetChild(0).GetComponent<LaunchArcRenderer>();

		Vector3 moveTo = new Vector3 (-9, 0, -10);
		while (mainCam.transform.localPosition != moveTo) {
			mainCam.transform.localPosition = Vector3.MoveTowards (mainCam.transform.localPosition, moveTo, camSpeed * Time.deltaTime);
		}
    }
	
	// Update is called once per frame
	void Update () {
        if (DoAnything)
        {
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
                    Fire(1);
                    p1_anim.Play("throw");
                    DoAnything = false;
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
                    Fire(2);
                    p2_anim.Play("throw");
                    DoAnything = false;
                }


                arcRender_2.RenderArc();
            }
        }

		if (moveTo_1 == true) {
			Vector3 moveTo = new Vector3 (-9, 0, -10);
			mainCam.transform.position = Vector3.MoveTowards (mainCam.transform.position, moveTo, Time.deltaTime * camSpeed);
			if (mainCam.transform.position.x <= moveTo.x) {
				moveTo_1 = false;
			}
		} 
		else if (moveTo_2 == true) {
			Vector3 moveTo = new Vector3 (9, 0, -10);
			mainCam.transform.position = Vector3.MoveTowards (mainCam.transform.position, moveTo, Time.deltaTime * camSpeed);
			if (mainCam.transform.position.x >= moveTo.x) {
				moveTo_2 = false;
			}
		}
    }

    void Fire(int playerNum)
    {
        

        if (playerNum == 1)
        {
			arcRender_1.Fire(playerNum);

            
        }
        else
        {
            arcRender_2.Fire(playerNum);

            
        }
    }

    public void SwitchPlayer()
    {
        if (isPlayerOne)
        {
			moveTo_2 = true;
			arcRender_1.angle = 45f;
            canFire_2 = true;
            catapult_2.SetActive(true);
            catapult_1.SetActive(false);
            arcRender_2.v = 5f;
        }
        else
        {
			moveTo_1 = true;
			arcRender_2.angle = 45f;
            canFire_1 = true;
            catapult_2.SetActive(false);
            catapult_1.SetActive(true);
            arcRender_1.v = 5f;
        }

        isPlayerOne = !isPlayerOne;
        DoAnything = true;
    }
}
