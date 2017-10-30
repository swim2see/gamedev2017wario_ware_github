using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lightswitchbutton : MonoBehaviour {

	public AudioClip button;
	private AudioSource source;

	float x;
	float y;
	Vector2 pos;
	public Scoretracker gameController;

	void Start () {
		source = GetComponent <AudioSource>();

		if (Scoretracker.score >= 10) {
			x = Random.Range (-9, 9);
			y = Random.Range(-4,4);
			pos = new Vector2 (x, y);
		} else {
			pos = new Vector2 (x, y);
		}
		transform.position = pos;

	}


	void OnMouseDown(){
		gameController.AddScore (1);
		gameState.goToNextGame ();
		source.PlayOneShot (button, 1.5f);
	}
}
