using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	public Text levelText;

	// Use this for initialization
	void Start () {
		//levelText.text = "Level: " + (CurrentLevelController.currentLevel + 2);
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentLevelController.currentLevel != 0) {
			levelText.text = "Level: " + (CurrentLevelController.currentLevel);
		}
	}
}
