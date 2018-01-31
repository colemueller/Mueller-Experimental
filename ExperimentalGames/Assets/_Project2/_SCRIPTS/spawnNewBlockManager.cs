using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNewBlockManager : MonoBehaviour {

	public GameObject groundPlane;

	public blockSpawner bs;

	// Use this for initialization
	void Start () {
		groundPlane = GameObject.FindGameObjectWithTag ("ground");
		bs = GameObject.FindGameObjectWithTag ("spawnPlane").GetComponent<blockSpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "block") {
			bs.spawnNewBlock ();
		}
	}
}
