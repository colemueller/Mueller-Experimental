using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

	public GameObject leftLeg;
	public GameObject rightLeg;
	public float speed;

	private int screenSizeX;
	private bool movingLeft;
	private bool prevDirection;
	private bool fell;

	// Use this for initialization
	void Start () {
		screenSizeX = Screen.width;
		fell = false;

	}
	
	// Update is called once per frame
	void Update () {
		//Find the middle of current screen size
		float screenMid = screenSizeX / 2;

		//If mouse is on screen left
		if (Input.mousePosition.x < screenMid) {
			movingLeft = true;

			//Rotate from the right pivot until left pivot is on the ground
			if (this.transform.rotation.z < -.01f) {
				this.transform.RotateAround (rightLeg.transform.position, Vector3.forward, speed);
			} else {
				//If you fall
				if (this.transform.rotation.z >= .75f) {
					fell = true;
					speed = 0;
				}
				this.transform.RotateAround (leftLeg.transform.position, Vector3.forward, speed);
			}
		
		//Else, the mouse is on screen right
		} else {
			movingLeft = false;

			//Rotate from the left pivot until the right pivot is on the ground
			if (this.transform.rotation.z > .01f) {
				this.transform.RotateAround (leftLeg.transform.position, (Vector3.forward * -1), speed);
			} else {
				//If you fall
				if (this.transform.rotation.z <= -.75f) {
					fell = true;
					speed = 0;
				}
				this.transform.RotateAround (rightLeg.transform.position, (Vector3.forward * -1), speed);
			}

		}

		//Can't add speed if you've fallen
		if (!fell) {
			//Add to speed everytime you change directions
			if (prevDirection != movingLeft) {
				speed += .25f;
				prevDirection = movingLeft;
			}
		}
		
		
	}
}
