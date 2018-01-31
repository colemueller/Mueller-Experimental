using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNewBlockManager : MonoBehaviour {

	

	public blockSpawner bs;
    public Rigidbody MyRigidBody;
    bool CheckVel = false;
	// Use this for initialization
	void Start () {
		
		bs = GameObject.FindGameObjectWithTag ("spawnPlane").GetComponent<blockSpawner> ();
        MyRigidBody = this.GetComponent<Rigidbody>();
	}

    private void Update()
    {
        //Debug.Log(MyRigidBody.velocity);
        if (CheckVel)
        {
            if (MyRigidBody.velocity == new Vector3(0, 0, 0))
            {
                bs.spawnNewBlock();
                CheckVel = false;
                this.tag = "BlockStatic";
                this.GetComponent<spawnNewBlockManager>().enabled = false;
            }
        }
    }

    void OnCollisionEnter (Collision col) {

		if (col.gameObject.tag == "BlockStatic" || col.gameObject.tag == "ground")
        {
            //if (MyRigidBody.velocity == new Vector3(0,0,0))
            //{
            //    bs.spawnNewBlock();
            //}
            //Debug.Log(MyRigidBody.velocity);
            CheckVel = true;
        }
	}
}
