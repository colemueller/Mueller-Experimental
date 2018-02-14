using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

	public GameObject leftLeg;
	public GameObject rightLeg;
	public float speed;
	public float speedRamp;
	public float forwardInterval;

	private int screenSizeX;
	private float camStartY;
	private float camStartX;
	private bool movingLeft;
	private bool prevDirection;
	private bool fell;
	private bool forwardMove;
	private float startingSpeed;

	// Use this for initialization
	void Start () {
		screenSizeX = Screen.width;
		fell = false;
		camStartY = this.transform.position.y;
		camStartX = this.transform.position.x;
		forwardMove = false;
		startingSpeed = speed;

	}

	void reset() {
		this.transform.position = new Vector3 (camStartX, camStartY, this.transform.position.z);
		this.transform.rotation = new Quaternion (0, 0, 0, 1);
		fell = false;
		speed = startingSpeed;
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
				if (forwardMove) {
					this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + forwardInterval);
					forwardMove = false;
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
				if (forwardMove) {
					this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + forwardInterval);
					forwardMove = false;
				}
				this.transform.RotateAround (rightLeg.transform.position, (Vector3.forward * -1), speed);
			}

		}

		//Can't add speed if you've fallen
		if (!fell) {
			//Add to speed everytime you change directions
			if (prevDirection != movingLeft) {
				speed += speedRamp;

				forwardMove = true;
				prevDirection = movingLeft;
			}
		} else {
			if (Input.GetKey (KeyCode.Space) && fell == true) {
				reset ();
			}
		}
		
	}
}
