using UnityEngine;
using System.Collections;

public class PlayMenuController : MonoBehaviour {

	public GameObject mainMenuScreen;
	public GameObject playMenuScreen;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void backToMenu(){
		mainMenuScreen.SetActive (true);
		playMenuScreen.SetActive (false);
	}

	public void playLevel(int level){
		Application.LoadLevel ("Level." + level);
	}
}
