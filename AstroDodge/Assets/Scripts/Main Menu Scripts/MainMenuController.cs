using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public GameObject mainMenuUI;

	// Use this for initialization
	void Start () {
		GlobalVariables.isPlaying = false;
		GlobalVariables.isDead = true;
		GlobalVariables.currentScreen = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVariables.currentScreen == 1) {
			mainMenuUI.SetActive (true);
			GlobalVariables.isDead = false;
		} 
		else {
			mainMenuUI.SetActive (false);
		}
	}
}
