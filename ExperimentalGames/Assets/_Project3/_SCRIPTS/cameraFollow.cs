using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public GameObject tripod;

	private float offset;

	// Use this for initialization
	void Start () {
		offset = tripod.transform.position.z - this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, tripod.transform.position.z - offset);
	}
}
