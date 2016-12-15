using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	/*
	 *
	 * 0 - RESERVED
	 * 1 - Setting up level
	 * 2 - Level in progress
	 * 3 - Victory
	 * 4 - Defeat
	 * 
	 */
	public int gameState;
	public int currentLevel;

	public GameObject startUI;
	public GameObject pausedUI;

	public GameObject victoryUI;
	public GameObject defeatUI;

	// Use this for initialization
	void Start () {
		gameState = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (gameState == 3) {
			victoryUI.SetActive(true);
		}
		else if (gameState == 4) {
			defeatUI.SetActive(true);
		}


	}

	void runLevel(){
		if (gameState != 3 && gameState != 4) {
			startUI.SetActive (false);
			pausedUI.SetActive (true);
			gameState = 2;
		}
	}

	void pauseLevel(){
		if (gameState != 3 && gameState != 4) {
			startUI.SetActive (true);
			pausedUI.SetActive (false);
			gameState = 1;
		}
	}

	void restartLevel(){
		Application.LoadLevel (currentLevel);
	}

	void backToLevelSelect(){
		Application.LoadLevel (0);
	}
}
