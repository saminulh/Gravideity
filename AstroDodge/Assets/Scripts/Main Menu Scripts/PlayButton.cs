using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour {

	public GameObject MainMenuScreen;
	public GameObject GameUIScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Script Enabled!");
		//GlobalVariables.isPlaying = true;
		//GlobalVariables.isDead = false;
	}

	void Play () {
		Debug.Log ("Hit Play!");
		GlobalVariables.isPlaying = true;
		GlobalVariables.isDead = false;
		GlobalVariables.currentScreen = 2;

		MainMenuScreen.SetActive (false);
		GameUIScreen.SetActive (true);
	}
}
