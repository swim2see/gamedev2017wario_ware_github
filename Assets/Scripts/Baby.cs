using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Baby : MonoBehaviour {

	public AudioClip baby;
	private AudioSource source;

	float x;
	float y = 3;
	Vector2 pos;

	public Scoretracker gameController; 

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		//source.pitch = 1f;
		source.PlayOneShot (baby, 0.1f);

		if (Scoretracker.score >= 10) {
			x = Random.Range (-9, 9);
			y = 2;
			pos = new Vector2 (x, y);
		} else {
			pos = new Vector2 (x, y);
		}
		transform.position = pos;

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		gameController.AddScore (1);
		gameState.goToNextGame ();
	}

}
