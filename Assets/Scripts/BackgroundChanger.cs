using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Scoretracker.score >= 30) {
			GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
