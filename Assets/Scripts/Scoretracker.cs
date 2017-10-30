using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scoretracker : MonoBehaviour { 

	public GUIText scoreText; 
	public GUIText timeText;
	public static int score = 1;
	float timeLimit;



	void Start(){
		if (timeLimit <= .75f) {
			timeLimit = 3f - (score * .05f);
		} else {
			timeLimit = .75f;
		}
		modeSelect ();
			//timeLimit = 3f - (score - .1f);
		//updateTime ();

	}

	void Update(){
		updateScore ();
		updateTime ();

	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		//updateScore ();


	}

	void updateScore(){
		if (SceneManager.GetActiveScene ().name == "StartMenu") {
			score = 0;
		}
		if (SceneManager.GetActiveScene ().name != "StartMenu") {
			if (SceneManager.GetActiveScene ().name == "Game over") {
				scoreText.text = "FINAL SCORE: " + score;
			} else {
				scoreText.text = "Score: " + score;
			}
		}
	}

	void updateTime(){

		
			timeLimit = 3f - (score * .05f);

		//newTimeLimit = timeLimit  - Time.timeSinceLevelLoad;
		if ((SceneManager.GetActiveScene ().name != "Game over") || (SceneManager.GetActiveScene ().name != "Game over")) {
			timeText.text = "Time: " + (timeLimit - Time.timeSinceLevelLoad);
		}

		//if (timeLimit == 0) {
		//	SceneManager.LoadScene ("Game over");
		//}
	}

	public void modeSelect(){
		StartCoroutine ("Wait");
	}

	IEnumerator Wait(){
		if ((SceneManager.GetActiveScene ().name != "Game over")) {
			yield return new WaitForSeconds (timeLimit);
			if ((SceneManager.GetActiveScene ().name != "StartMenu")) {
				SceneManager.LoadScene ("Game over");
			}
		}
	}


}

//(timeLimit / (score + 1) - Time.timeSinceLevelLoad)