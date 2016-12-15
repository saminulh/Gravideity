using UnityEngine;
using System.Collections;

public class SettingsMenuController : MonoBehaviour {

	public GameObject mainMenuScreen;
	public GameObject settingsMenuScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void backToMenu() {
		mainMenuScreen.SetActive (true);
		settingsMenuScreen.SetActive (false);
	}
}
