using UnityEngine;
using System.Collections;

public class GlobalVariablesController : MonoBehaviour {

	public GameObject mainMenuScreen;
	public GameObject playMenuScreen;
	public GameObject settingsMenuScreen;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playMenu(){
		mainMenuScreen.SetActive (false);
		playMenuScreen.SetActive (true);
		settingsMenuScreen.SetActive (false);
	}

	void settingsMenu() {
		mainMenuScreen.SetActive (false);
		playMenuScreen.SetActive (false);
		settingsMenuScreen.SetActive (true);
	}
}
