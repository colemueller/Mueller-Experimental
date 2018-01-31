using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverController : MonoBehaviour {

	public GameObject crane;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		crane.transform.localPosition = new Vector3 (0f,0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			if (crane.transform.localPosition.x < 13.5f) {
				crane.transform.position = new Vector3 (crane.transform.position.x + moveSpeed, crane.transform.position.y, crane.transform.position.z);
			}
		} 
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			if (crane.transform.localPosition.x > -1f) {
				crane.transform.position = new Vector3 (crane.transform.position.x - moveSpeed, crane.transform.position.y, crane.transform.position.z);
			}
		}
	}
}
