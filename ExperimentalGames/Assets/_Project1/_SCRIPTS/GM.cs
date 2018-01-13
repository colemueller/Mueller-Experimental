using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public bool isPlayerOneTurn = true;
    public GameObject darken;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerOneTurn)
        {
            darken.transform.position = new Vector3(4.5f, 0, 0);
        }
        else
        {
            darken.transform.position = new Vector3(-4.5f, 0, 0);
        }
	}

    public void DoTurn()
    {
        isPlayerOneTurn = !isPlayerOneTurn;
    }
}
