using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawnNewBlockManager : MonoBehaviour {

	//public Text trackerText;

	public blockSpawner bs;
    public Rigidbody MyRigidBody;
    bool CheckVel = false;
	private GameObject currentlyHeld;
    private ParticleSystem particleSys;
    ParticleSystem.EmissionModule mod;
    // Use this for initialization
    void Start () {
        particleSys = this.GetComponent<ParticleSystem>();
        mod = particleSys.emission;
        mod.enabled = false;
		bs = GameObject.FindGameObjectWithTag ("spawnPlane").GetComponent<blockSpawner> ();
        MyRigidBody = this.GetComponent<Rigidbody>();
		//trackerText = GameObject.FindGameObjectWithTag ("trackerText").GetComponent<Text> ();
	}

    private void Update()
    {
        //Debug.Log(MyRigidBody.velocity);
        if (CheckVel)
        {
            if (MyRigidBody.velocity == new Vector3(0, 0, 0))
            {
				Collider spawnCol = bs.gameObject.GetComponent<Collider>();
				spawnCol.enabled = true;
                bs.spawnNewBlock();
                CheckVel = false;
                //this.tag = "BlockStatic";
                this.GetComponent<spawnNewBlockManager>().enabled = false;
            }
			//trackerText.text = Mathf.Abs(Mathf.Ceil(currentlyHeld.transform.position.x)).ToString();
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
            mod.enabled = true;
            particleSys.Play();
            CheckVel = true;
			currentlyHeld = MyRigidBody.gameObject;
        }
        
	}
}
