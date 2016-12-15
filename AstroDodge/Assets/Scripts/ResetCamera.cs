using UnityEngine;
using System.Collections;

public class ResetCamera : MonoBehaviour {
	
	void ResetPosition(){
		transform.Translate (-transform.position.x, -transform.position.y + 3, -(transform.position.z));
		transform.Translate (0, 0, -10);
		Debug.Log ("Reset Camera!");
	}
	
	void Update() {
		/*if (GlobalVariables.isDead == true && GlobalVariables.isPlaying == true) {
			ResetPosition();
		}*/ 
	}
}
