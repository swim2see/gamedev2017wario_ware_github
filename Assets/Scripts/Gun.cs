using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	private List<GameObject> Projectiles = new List<GameObject> ();

	public AudioClip gun;
	private AudioSource source;

	public GameObject projectilePrefab;

	private float projectileVel;

	Vector3 pos;

	float y = Screen.height / 4;


	// Use this for initialization
	void Start () {
		projectileVel = 18;
		source = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		pos = new Vector3 (Input.mousePosition.x, y, 1);

		transform.position = Camera.main.ScreenToWorldPoint (pos);

		if (Input.GetMouseButtonDown (0)) {
			source.PlayOneShot (gun);
			GameObject bullet = (GameObject)Instantiate (projectilePrefab, transform.position, Quaternion.identity);
			Projectiles.Add (bullet);
		}

		for (int i = 0; i < Projectiles.Count; i++) {
			GameObject goBullet = Projectiles [i];
			if (goBullet != null) {
				goBullet.transform.Translate(new Vector2(0,1) * Time.deltaTime * projectileVel);

				Vector2 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);

				if (bulletScreenPos.y >= Screen.height) {
					DestroyObject (goBullet);
					Projectiles.Remove (goBullet);
				}
			}
		}
	}
}
