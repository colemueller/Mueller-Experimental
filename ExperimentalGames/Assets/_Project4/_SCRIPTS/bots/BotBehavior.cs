using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBehavior : MonoBehaviour {

    public float moveSpeed;
    public float rayLength = 2;
    public float turnSpeed = 1;

    private Quaternion targetRotation;

    private bool DoTurn = false;
    private bool cast = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cast)
        {
            Vector3 myPosition = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
            Vector3 rayDirection = this.transform.forward;
            RaycastHit hitInfo;

            if (Physics.Raycast(myPosition, rayDirection, out hitInfo, rayLength))
            {
                if (hitInfo.collider.gameObject.tag == "turnObject" || hitInfo.collider.gameObject.tag == "turnBlock")
                {
                    targetRotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
                    DoTurn = true;
                    cast = false;

                }
            }
        }

        if (!DoTurn)
        {
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
        }
        else
        {

            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (turnSpeed * Time.deltaTime));

            transform.rotation = targetRotation;
            if(transform.rotation == targetRotation)
            {
                DoTurn = false;
                cast = true;
            }
        }
        
        
	}


}
