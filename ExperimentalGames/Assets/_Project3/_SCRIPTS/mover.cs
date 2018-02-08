using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

	public GameObject leftLeg;
	public GameObject rightLeg;

	private int screenSizeX;

	// Use this for initialization
	void Start () {
		leftLeg.transform.rotation = new Quaternion (0,0,0,0);
		rightLeg.transform.rotation = new Quaternion (0,0,0,0);
		screenSizeX = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		float screenMid = screenSizeX / 2;

		if (Input.mousePosition.x <= screenMid) {
			this.transform.RotateAround (rightLeg.transform.position, Vector3.forward, 0f);
			if (this.transform.rotation == new Quaternion (0,0,0,1)) {
				this.transform.RotateAround (leftLeg.transform.position, Vector3.forward, 5f);
			}

		} else if (Input.mousePosition.x >= screenMid) {
			this.transform.RotateAround (leftLeg.transform.position, Vector3.forward, 0f);
			if (this.transform.rotation == new Quaternion (0, 0, 0, 1)) {
				this.transform.RotateAround (rightLeg.transform.position, Vector3.forward, -5f);
			}

		}
		
		
	}
}
