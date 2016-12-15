using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {

	public GameObject scoreUI;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVariables.currentScreen == 2) {
			scoreUI.SetActive (true);
		} 
		else {
			scoreUI.SetActive (false);
		}
	}
}
