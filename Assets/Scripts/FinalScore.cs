using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {


	void Start(){

	}


	public void changeMenuScene(string sceneName){
		if (SceneManager.GetActiveScene ().name == "Game over") {
			SceneManager.LoadScene ("StartMenu");
		} else {
			gameState.goToNextGame ();
		}
	}
}
