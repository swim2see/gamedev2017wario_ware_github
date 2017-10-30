using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chain : MonoBehaviour {

	public Animation anim;

	public AudioClip chain;
	private AudioSource source;

	Vector2 pos;

	public Scoretracker gameController; 

	float x;
	float y;


	void Start (){
		anim = GetComponent<Animation> ();
		source = GetComponent<AudioSource> ();

		if (Scoretracker.score >= 10) {
			x = Random.Range (0,9);
			y = 10;
		} else {
			x = 0;
			y = 10;
		}
		

		pos = new Vector2 (x, y);
		transform.position = pos;
	}

	void Update(){
		Score ();
	}
		

	void OnMouseDown()
	{
		x = Input.mousePosition.x;
		source.PlayOneShot (chain);
		anim.Stop();

		//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(x, Input.mousePosition.y));

	}

	void OnMouseDrag()
	{
		y = Input.mousePosition.y;
		Vector2 curScreenPoint = new Vector2(x, y);

		Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		Vector3 fixedPosition = new Vector3 (curPosition.x, curPosition.y + (GetComponent<SpriteRenderer> ().bounds.size.y / 2.5f), 1);
		transform.position = fixedPosition;


}
	void Score(){
		if (transform.position.y <= 4) {
			Debug.Log ("help");
			gameController.AddScore (1);
			gameState.goToNextGame ();
		}
	}
}