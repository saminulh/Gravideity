using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreUI : MonoBehaviour {

	public GameObject HighscoreScreen;
	public Text highscoreText;
	public int highscore;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVariables.currentScreen == 3) {
			HighscoreScreen.SetActive (true);
		}
		else {
			HighscoreScreen.SetActive(false);
		}
		highscoreText.text = "Highscore: " + highscore;
	}
}
