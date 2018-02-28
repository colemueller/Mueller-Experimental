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
 
            crane.transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
		} 

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {

            crane.transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));

		}

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {

            crane.transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftArrow))
        {

            crane.transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));

        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {

            crane.transform.Translate(Vector3.up * ((moveSpeed * 2) * Time.deltaTime));

        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift))
        {

            crane.transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));

        }
    }
}
