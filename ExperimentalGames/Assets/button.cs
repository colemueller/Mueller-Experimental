using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

    public Transform lift;
    public Transform bottom;
    public Transform top;
    public float liftSpeed;

    bool goUp = false;
    bool goDown = false;

    public float startUpTime;
    public float startDownTime;
    bool canTouch = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (goUp)
        {
            canTouch = false;
            lift.Translate(Vector3.up * liftSpeed);

            if(lift.position.y >= top.position.y)
            {
                goUp = false;
                StartCoroutine(StartDown(startDownTime));
            }
        }

        if (goDown)
        {
            canTouch = false;
            lift.Translate(Vector3.down * liftSpeed);

            if (lift.position.y <= bottom.position.y)
            {
                goDown = false;
                canTouch = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bot" && canTouch)
        {
            StartCoroutine(StartUp(startUpTime));
        }
    }

    IEnumerator StartDown(float time)
    {
        yield return new WaitForSeconds(time);
        goDown = true;
    }
    IEnumerator StartUp(float time)
    {
        yield return new WaitForSeconds(time);
        goUp = true;
    }
}
