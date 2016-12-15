using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject gameControllerObject;

	public GameObject cameraObj;
	public GameObject ship;

	float initY;

	// Use this for initialization
	void Start () {
		initY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameControllerObject.GetComponent<GameController> ().gameState == 2) {
			cameraObj.transform.position = new Vector3 (ship.transform.position.x, initY, ship.transform.position.z);
		}
	}
}
