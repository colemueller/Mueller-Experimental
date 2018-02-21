using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSwitch : MonoBehaviour {

    public Transform followPos;
    public Transform parentPos;

    public bool isFollow = true;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DoSwitch();
        }
		
	}

    void DoSwitch()
    {
        if (isFollow)
        {
            this.transform.SetParent(parentPos);
        }
        else
        {
            this.transform.SetParent(followPos);
        }

        this.transform.localPosition = Vector3.zero;
        this.transform.localEulerAngles = Vector3.zero;

        isFollow = !isFollow;
    }
}
