using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbingController : MonoBehaviour {

	public GameObject craneHook;
	public Collider craneHookCol;
	public float releaseMass;

	private bool holding;
	private GameObject heldObj;
	private HingeJoint hj;

    
	// Use this for initialization
	void Start () {
		holding = false;
        
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && holding==true) {
            //Debug.Log("LET GO BITCH");
            
			Destroy (hj);
            craneHookCol.enabled = false;
			//Rigidbody rbody = heldObj.GetComponent<Rigidbody> ();
			//rbody.detectCollisions = true;
			//rbody.mass = releaseMass;

			holding = false;
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "block") {

			hj = gameObject.AddComponent<HingeJoint>();
			hj.connectedBody = col.rigidbody;
			//col.rigidbody.mass = .0001f;
			//col.rigidbody.freezeRotation = true;
			//col.rigidbody.velocity = new Vector3 (0,0,0);
			//col.rigidbody.detectCollisions = false;

			heldObj = col.gameObject;
			holding = true;
		}
	}
}
