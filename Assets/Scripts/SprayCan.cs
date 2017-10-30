using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SprayCan : MonoBehaviour {

	public AudioClip spraycan;
	private AudioSource source;

	public Scoretracker gameController;

	Transform startY;

	bool isDown = false;
	bool isUp = false;

	int curShakeCount = 0; 
	int tarShakeCount = 3;
	float shakeDist = 1;

	Vector3 shakeStartPos; 
	Vector3 lastMousePos;

	//float y;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();

		Vector3 goodMouse = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1);
		shakeStartPos = transform.position;
		//y = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		lastMousePos = Camera.main.ScreenToWorldPoint(goodMouse);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 goodMouse = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1);

		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(goodMouse);

		transform.position = worldMousePos;

		float deltaY = worldMousePos.y - lastMousePos.y;

		lastMousePos = worldMousePos;



		if (deltaY < 0) {
			//Registers if the can is shaking down
			if(isUp){
				if (Mathf.Abs(transform.position.y - shakeStartPos.y) >= shakeDist) {
					curShakeCount++;
					shakeStartPos = transform.position;
					source.PlayOneShot (spraycan);
					//Debug.Log ("Can shooken");
				}
			}
			isDown = true;
			isUp = false;
			//Debug.Log ("down");
		} else if (deltaY > 0) {
			//Registers if the can is shaking up
			if(isDown){
				if (Mathf.Abs(transform.position.y - shakeStartPos.y) >= shakeDist) {
					curShakeCount++;
					shakeStartPos = transform.position;
					//Debug.Log ("Can shooken");
					source.PlayOneShot (spraycan, 0.5f);
				}
			}
			isUp = true;
			isDown = false;
			//Debug.Log ("up");
		} else {
			//Registers if the can isn't shaking
			isUp = false;
			isDown = false;
			//Debug.Log("n");
		}

		Score ();

	}


	void Score(){
		if (curShakeCount == tarShakeCount) {
			gameController.AddScore (1);
			gameState.goToNextGame (); 

		}
	}



}
