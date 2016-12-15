using UnityEngine;
using System.Collections;

public class CameraAndGroundController : MonoBehaviour {

	public float speedZ;
	public GameObject ship;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVariables.isPlaying == true) {
			transform.Translate (0, 0, speedZ);
		}

		if (transform.position.z - ship.transform.position.z > 10) {
			transform.Translate (0, 0, - transform.position.z);
			transform.Translate (0, 0, -10);
			Debug.Log ("Re-adjusted Camera!");
		}
	}
}
