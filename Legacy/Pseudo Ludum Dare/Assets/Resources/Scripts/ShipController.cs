using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipController : MonoBehaviour {

	public GameObject gameControllerObject;

	public GameObject ship;
	public GameObject shipMesh;

	public float shipMass;
	public Vector3 initialVelocity;

	Vector3 shipVelocity;
	Vector3 shipAcceleration;
	
	//Destination is win point
	public GameObject destination;
	public List<GameObject> planetsList;

	public int simSpeed;

	[System.Serializable]
	public class WarpPairs{
		public GameObject warpIn;
		public GameObject warpOut;
	}

	public List <WarpPairs> warpPairsList;



	// Use this for initialization
	void Start () {
		//Set the initial ship velocity from editor
		shipVelocity = initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {

		if (gameControllerObject.GetComponent<GameController>().gameState == 2) {

			//Reset acceleration from previous frame - recalculate
			shipAcceleration.x = 0;
			shipAcceleration.z = 0;

			for (int i = 0; i < planetsList.Count; i++) {
		
				//Calculate force exterted
				float force;
				force = (float)0.0006 * shipMass * planetsList [i].GetComponent<Planet>().size / (Mathf.Pow (ship.transform.position.x - planetsList [i].transform.position.x, 2) + Mathf.Pow (ship.transform.position.z - planetsList [i].transform.position.z, 2));

				//Calculate direction of force
				Vector3 heading = planetsList [i].transform.position - ship.transform.position;

				//Calculate angle of force - to split into components
				float angle = (Mathf.Atan2 (heading.z, heading.x));

				shipAcceleration.x += Mathf.Cos (angle) * force;
				shipAcceleration.z += Mathf.Sin (angle) * force;

				//Loss Condition - if ship is too close to a planet - use planet size field
				if (ship.transform.position.x - planetsList [i].transform.position.x < (planetsList[i].GetComponent<Planet>().size / 2) && planetsList [i].transform.position.x - ship.transform.position.x < (planetsList[i].GetComponent<Planet>().size / 2)&&
				    ship.transform.position.z - planetsList [i].transform.position.z < (planetsList[i].GetComponent<Planet>().size / 2) && planetsList [i].transform.position.z - ship.transform.position.z < (planetsList[i].GetComponent<Planet>().size / 2)) {

					//TODO: Proper loss state

					gameControllerObject.GetComponent<GameController>().gameState = 4;

					Debug.Log ("Loss!");
				}
			}

			shipVelocity += shipAcceleration;


			//Make ship mesh face the direction it is travelling in
			if (shipVelocity != Vector3.zero)
				shipMesh.transform.rotation = Quaternion.LookRotation (-shipVelocity);
			else
				shipMesh.transform.rotation = Quaternion.LookRotation (Vector3.zero);

			//Move ship after movement has been calculated
			ship.transform.Translate (shipVelocity * simSpeed);

			//Wormholes
			for (int i = 0; i < warpPairsList.Count; i++) {

				if (ship.transform.position.x - warpPairsList [i].warpIn.transform.position.x < 10 && warpPairsList [i].warpIn.transform.position.x - ship.transform.position.x < 10 &&
					ship.transform.position.z - warpPairsList [i].warpIn.transform.position.z < 10 && warpPairsList [i].warpIn.transform.position.z - ship.transform.position.z < 10) {
					Debug.Log ("Warping!");
					ship.transform.Translate (warpPairsList [i].warpOut.transform.position - ship.transform.transform.position);
				}
			}


			//Victory Condition
			if (ship.transform.position.x - destination.transform.position.x < 10 && destination.transform.position.x - ship.transform.position.x < 10 &&
				ship.transform.position.z - destination.transform.position.z < 10 && destination.transform.position.z - ship.transform.position.z < 10) {

				//TODO: Proper victory condition

				gameControllerObject.GetComponent<GameController>().gameState = 3;

				Debug.Log ("Victory!");
			}
		}
	}	
	
	void OnCollisionEnter(Collision col){
		Debug.Log ("Collision!");
	}
}
