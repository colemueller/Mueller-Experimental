using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabbingController : MonoBehaviour {

	public GameObject craneHook;
	public Collider craneHookCol;
	//public float releaseMass;
	//public GameObject spawnPlatform;

	//public Camera cam;

	private bool holding;
	private GameObject heldObj;
	private HingeJoint hj;
	private Rigidbody myRB;
	private bool tracking;
	private Vector3 camDefaultPos;

	//public Text trackerText;
    
	// Use this for initialization
	void Start () {
		holding = false;
		//camDefaultPos = cam.transform.position;
		//trackerText = GameObject.FindGameObjectWithTag ("trackerText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && holding == true) {
            
			//heldObj.tag = "BlockStatic";
			Destroy (hj);
			//craneHookCol.enabled = false;
			//Rigidbody rbody = heldObj.GetComponent<Rigidbody> ();
			//rbody.detectCollisions = true;
			//rbody.mass = releaseMass;

			holding = false;
			tracking = true;
		}

		
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "block" && GetComponent<HingeJoint>() == null) {

			hj = gameObject.AddComponent<HingeJoint>();
            
            hj.anchor = new Vector3(0, -0.5f, 0);
            hj.useSpring = true;
            JointSpring j_spring = new JointSpring();
            j_spring.spring = 100;
            hj.spring = j_spring;
			hj.connectedBody = col.rigidbody;
			//col.rigidbody.mass = .0001f;
			//col.rigidbody.freezeRotation = true;
			//col.rigidbody.velocity = new Vector3 (0,0,0);
			//col.rigidbody.detectCollisions = false;

			heldObj = col.gameObject;
			myRB = col.rigidbody;
			//Collider spawnCol = spawnPlatform.GetComponent<Collider>();
			//spawnCol.enabled = false;
			holding = true;

		}
	}
}
