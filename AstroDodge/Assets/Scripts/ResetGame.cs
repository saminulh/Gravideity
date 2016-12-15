using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour {
	
	void ResetPosition(){
		transform.Translate (-transform.position.x, (float)(-transform.position.y + (0.5)), -transform.position.z);
	}

	void Update() {
		if (GlobalVariables.isDead == true && GlobalVariables.isPlaying == true) {
			ResetPosition();
			GlobalVariables.isDead = false;
		}
	}
}
