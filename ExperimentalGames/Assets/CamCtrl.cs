using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour {

    public float moveSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.left * moveSpeed);
        }

        if (Input.GetKey(KeyCode.X))
        {
            transform.Translate(Vector3.right * moveSpeed);
        }
    }
}
