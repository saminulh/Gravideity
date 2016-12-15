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

	public GameObject startUI;
	public GameObject pausedUI;

	public GameObject victoryUI;
	public GameObject defeatUI;

	public GameObject planetUI;

	bool runOnce = false;

	int frameCounter = 0;
	int numFrames = 5;

	// Use this for initialization
	void Start () {
		GlobalVariables.gameState = 1;

		//Instantiate(startUI);
		startUI.SetActive (true);

		//Instantiate (pausedUI);
		pausedUI.SetActive (false);

		//Instantiate (victoryUI);
		victoryUI.SetActive (false);

		//Instantiate (defeatUI);
		defeatUI.SetActive (false);

		planetUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (GlobalVariables.gameState == 3) {
			victoryUI.SetActive(true);
			planetUI.SetActive(false);
		}
		else if (GlobalVariables.gameState == 4) {
			defeatUI.SetActive(true);
			planetUI.SetActive(false);
		}

		if (runOnce){
			if (GlobalVariables.gameState == 2){
				//runOnce = false;
				frameCounter --;
				if (frameCounter <= 0){
					GlobalVariables.gameState = 1;
					runOnce = false;
				}
			}
			else{
				GlobalVariables.gameState = 2;
			}
		}

		if (GlobalVariables.numSelected >= 1) {
			planetUI.SetActive (true);
		} 
		else {
			planetUI.SetActive(false);
		}
	}

	void runLevel(){
		if (GlobalVariables.gameState != 3 && GlobalVariables.gameState != 4) {
			startUI.SetActive (false);
			pausedUI.SetActive (true);
			GlobalVariables.gameState = 2;
		}
	}

	void pauseLevel(){
		if (GlobalVariables.gameState != 3 && GlobalVariables.gameState != 4) {
			startUI.SetActive (true);
			pausedUI.SetActive (false);
			GlobalVariables.gameState = 1;
		}
	}

	void restartLevel(){
		Application.LoadLevel ("Level." + (CurrentLevelController.currentLevel));
	}

	void backToLevelSelect(){
		Application.LoadLevel (0);
	}

	void loadNextLevel(){
		Application.LoadLevel ("Level." + (CurrentLevelController.currentLevel + 1));
	}

	void stepThrough(){
		if (GlobalVariables.gameState == 1) {
			runOnce = true;
			frameCounter = numFrames;
		}
	}
}
