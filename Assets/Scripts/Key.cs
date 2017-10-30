using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour {

	public AudioClip key;
	private AudioSource source;

	public string level; 
	public Scoretracker gameController; 

	private bool isPressed = false;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Pressed ();
	}

	void OnMouseDown(){
		isPressed = true;
	}

	void OnMouseUp(){
		isPressed = false;
	}

	void Pressed() {
		if (isPressed) {
			Vector2 MousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			Vector2 objPosition = Camera.main.ScreenToWorldPoint (MousePosition);
			transform.position = objPosition; 
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Keyhole") {
			gameController.AddScore (1);
			gameState.goToNextGame ();

			source.PlayOneShot (key);
		}
	}


	/*IEnumerator Wait(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("Game over");
	}*/
}


