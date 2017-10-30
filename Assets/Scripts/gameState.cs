using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameState  {
	public static Stack<int> scenesToGoTo = new Stack<int>();

	public static int numLevels = 7;

	public static void resetScenes(){
		List<int> levels = new List<int> ();
		for (int i = 0; i <= numLevels; i++) {
			levels.Add (i);
		}
		for (int j = 0; j < numLevels; j++) {
			int idx = Random.Range (1, levels.Count);
			scenesToGoTo.Push (levels [idx]);
			levels.RemoveAt (idx);
		}
	}

	public static void goToNextGame(){
		int nextScene = scenesToGoTo.Pop ();

		if (scenesToGoTo.Count == 0) {
			resetScenes ();
		}
		SceneManager.LoadScene (nextScene);
	}
}
