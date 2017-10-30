using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoveDial : MonoBehaviour {

	private Camera myCam;
	private Vector3 screenPos;
	private float   angleOffset;

	public Scoretracker gameController;

	void Start () {
		myCam=Camera.main;
	}

	void Update () { 
		//This fires only on the frame the button is clicked
		if(Input.GetMouseButtonDown(0)) {
			screenPos = myCam.WorldToScreenPoint (transform.position);
			Vector3 v3 = Input.mousePosition - screenPos;
			angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(v3.y, v3.x))  * Mathf.Rad2Deg;
		}
		//This fires while the button is pressed down
		if(Input.GetMouseButton(0)) {
			Vector3 v3 = Input.mousePosition - screenPos;
			float angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0,0,angle+angleOffset);  
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "GasOn") {
			gameController.AddScore(1);
			gameState.goToNextGame ();
		}
	}

}
	



	/*float rotateSpeed = 90;
	float maxRotation = 200; 



	float x;
	float y;

	// Update is called once per frame
	void Update () {

		Vector3 forward = Camera.main.transform.TransformDirection (Vector3.forward);

		Plane playerPlane = new Plane (-forward, transform.position);

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 

		float hitDist = 0.0f;

		if (Input.GetMouseButton(0)) {
			if (playerPlane.Raycast (ray, hitDist)){
				transform aimPoint
			}



			/*x = Input.GetAxis ("Mouse X");
			y = Input.GetAxis ("Mouse Y");
			float speed = 10;
			transform.rotation *= Quaternion.AngleAxis (x * speed, Vector3.forward);
			transform.rotation *= Quaternion.AngleAxis (y * speed, Vector3.forward); 
		}	
	} */