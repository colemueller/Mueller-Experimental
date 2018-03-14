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
    //private CharacterJoint cj;
    
	private Rigidbody myRB;
	private bool tracking;
	private Vector3 camDefaultPos;
    public float hookTimer = 3f;
    GameObject switchTagBack;
    string tagToSet;

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
            Debug.Log("RELEASE");
            tagToSet = heldObj.tag;
			heldObj.tag = "BlockStatic";
            
			Destroy(hj);
            switchTagBack = heldObj;
            //craneHookCol.enabled = false;

            StartCoroutine(HookOn(hookTimer));

			holding = false;
			tracking = true;
		}

		
	}

    IEnumerator HookOn(float time)
    {
        yield return new WaitForSeconds(time);
        //craneHookCol.enabled = true;
        switchTagBack.tag = tagToSet;
    }

	void OnCollisionEnter (Collision col) {
		if ((col.gameObject.tag == "block"  || col.gameObject.tag == "turnBlock") && GetComponent<HingeJoint>() == null) {

			hj = gameObject.AddComponent<HingeJoint>();

            hj.anchor = new Vector3(0.09f, -0.44f, 0);
            hj.useSpring = true;
            
            JointSpring j_spring = new JointSpring();
            j_spring.spring = 500;
           
            hj.spring= j_spring;
            //fj.twistLimitSpring = j_spring;
            //j_spring.spring = 900;
            //cj.swingLimitSpring = j_spring;
            hj.connectedBody = col.rigidbody;
			

			heldObj = col.gameObject;
			myRB = col.rigidbody;
			//Collider spawnCol = spawnPlatform.GetComponent<Collider>();
			//spawnCol.enabled = false;
			holding = true;

		}
	}
}
