using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public bool isPlayerOneTurn = true;
    public GameObject darken;
	public GameObject p2LaunchSource;
	public Camera mainCam;
	public float camSpeed;

	public GameObject p1;
	public GameObject p2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerOneTurn)
        {
			mainCam.transform.localPosition = Vector3.MoveTowards (mainCam.transform.localPosition, new Vector3(-9, 0, -10), camSpeed);
			//darken.transform.position = new Vector3(4.5f, 0, 0);
        }
        else
        {
			mainCam.transform.localPosition = Vector3.MoveTowards (mainCam.transform.localPosition, new Vector3(9, 0, -10), camSpeed);
            //darken.transform.position = new Vector3(-4.5f, 0, 0);
        }
	}

    public void DoTurn()
    {
        isPlayerOneTurn = !isPlayerOneTurn;
    }
}
