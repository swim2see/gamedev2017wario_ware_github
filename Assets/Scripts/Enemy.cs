using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	bool motion;

	Vector3 pos;

	public Scoretracker gameController;

	// Use this for initialization
	void Start () {
		if (Scoretracker.score >= 10) {
			motion = true;
		} else {
			motion = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (motion == true) {
			transform.Translate ((Vector3.right * 5) * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Bullet") {
			gameController.AddScore (1);
			gameState.goToNextGame (); 
		}
	}
}
