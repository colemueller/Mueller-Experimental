using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpawner : MonoBehaviour {

	public GameObject block01;
	public GameObject block02;
	public GameObject block03;
	public GameObject block04;
	public GameObject block05;
	public GameObject block06;

	public Transform spawnPad;

	public GameObject[] objList;
	public bool spawnNew = false;

    public Collider hookCol;

	// Use this for initialization
	void Start () {
		objList = new GameObject[6];
		objList [0] = block01;
		objList [1] = block02;
		objList [2] = block03;
		objList [3] = block04;
		objList [4] = block05;
		objList [5] = block06;

		int rand = Random.Range (0, 5);
		GameObject clone = Instantiate(objList[rand], new Vector3(spawnPad.position.x, spawnPad.position.y + 1, spawnPad.position.z), Quaternion.identity) as GameObject;

	}

	public void spawnNewBlock() {
		int rand = Random.Range (0, 5);
		GameObject clone = Instantiate(objList[rand], new Vector3(spawnPad.position.x, spawnPad.position.y + 1, spawnPad.position.z), Quaternion.identity) as GameObject;
        hookCol.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		/*
		if (spawnNew == true) {
			spawnNewBlock ();
			spawnNew = false;
		}*/
		
	}
}
