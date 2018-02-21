using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThis : MonoBehaviour {

    
    public float moveSpeed = 5;
    public float distance = 2;
    public float rotSpeed;

	// Update is called once per frame
	void Update () {

        
        transform.position = new Vector3(Mathf.Sin(Time.time * moveSpeed) * distance, transform.position.y, transform.position.z);
        transform.Rotate(Vector3.right, rotSpeed);
        transform.Rotate(Vector3.forward, rotSpeed);

    }
}
