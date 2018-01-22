using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class LaunchArcRenderer : MonoBehaviour {

	LineRenderer lr;

	public float v;  //Velocity
	public float angle;  //Angle of launch
	public int resolution = 10;  //Resolution of the arc

	public float g;  //Force of gravity on the y axis

    public Transform projectile;
    public float projectileSpeed = 1;
    float step;
    bool doMove = false;
    Vector3[] temp;
    int i = 1;

    public FireControls fireScript;

	float xOffset;
	float newX;
	float yOffset;

    float radianAngle;  //For converting degrees to radians

	void Awake(){
		lr = GetComponent<LineRenderer> ();
		g = Mathf.Abs (Physics2D.gravity.y);
        projectile.gameObject.SetActive(false);
    }

	void OnValidate() {
		//check that lr is not null and that the game is playing
		if (lr != null && Application.isPlaying) {
			RenderArc ();
		}
	}

	// Use this for initialization
	void Start () {
		RenderArc ();
	}

	//Populates the lineRenderer with the appropiate settings
	public void RenderArc() {
		lr.SetVertexCount (resolution + 1);
		lr.SetPositions (CalcArcArray ());
	}

	//Creates an array of vertor 3 positions for the arc
	Vector3[] CalcArcArray() {
		Vector3[] arcArray = new Vector3[resolution + 1];

		radianAngle = Mathf.Deg2Rad * angle;
		float maxDist = (v * v * Mathf.Sin (2 * radianAngle)) / g;

		for (int i = 0; i <= resolution; i++) {
			float t = (float)i / (float)resolution;
			arcArray [i] = CalcArcPoint (t, maxDist);
		}

		return arcArray;

	}

	//Calculates the height and distance of each vertex in the arc
	Vector3 CalcArcPoint(float t, float maxDist){
		float x = t * maxDist;
		float y = x * Mathf.Tan (radianAngle) - ((g * x * x) / (2 * v * v * Mathf.Cos (radianAngle) * Mathf.Cos (radianAngle)));

		return new Vector3 (x, y);
	}

	public void Fire(int player)
    {
		temp = CalcArcArray();
        projectile.localPosition = temp[0];
        doMove = true;
		xOffset = projectile.position.x - fireScript.mainCam.transform.position.x;
		yOffset = projectile.position.y - fireScript.mainCam.transform.position.y;
        projectile.gameObject.SetActive(true);

    }

    void Update()
    {
        if (doMove)
        {
			step = projectileSpeed * Time.deltaTime;

            if (i <= resolution)
            {
                if (projectile.localPosition != temp[i])
                {
                    projectile.localPosition = Vector3.MoveTowards(projectile.localPosition, temp[i], step);

					if (projectile.position.x - xOffset >= -9f && projectile.position.x - xOffset <= 9f) {
						newX = projectile.position.x - xOffset;
						fireScript.mainCam.transform.position = new Vector3 (newX, fireScript.mainCam.transform.position.y, fireScript.mainCam.transform.position.z);
					}
					if (projectile.position.y - yOffset >= -.001f) {
						fireScript.mainCam.transform.position = new Vector3 (newX, projectile.position.y - yOffset, fireScript.mainCam.transform.position.z);
					}
				}
                else
                {
                    i++;
                }
            }
            else
            {
                doMove = false;
                i = 1;
                projectile.gameObject.SetActive(false);
                fireScript.SwitchPlayer();
            }
        }
    }



}
