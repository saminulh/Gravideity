using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipController : MonoBehaviour {

	public GameObject ship;

	public float shipMass;

	public Vector3 shipVelocity;
	public Vector3 shipVelocityOld;
	public Vector3 shipAccelerationOld;
	public Vector3 shipAcceleration;

	public int simSpeed;

	public List<GameObject> planetsList;


	List<Gizmos> gizmosList;

	// Use this for initialization
	void Start () {

		simSpeed = 1000;

		shipVelocity = new Vector3 ((float)0.01, 0, (float)0.01);
		shipAcceleration = new Vector3 ((float)0.0001, 0, (float)0.0001);
		shipAccelerationOld = new Vector3 ((float)0.3, 0, (float)0.1);
		shipVelocityOld = new Vector3 ((float)-0.35, 0, (float)-0.35);
	}
	
	// Update is called once per frame
	void Update () {


		/*
		//Calculate gravity exerted by the planets
		for (int i = 0; i < planetsList.Count; i++) {
		
			shipAcceleration.x += (float)0.006 * (shipMass * planetsList[i].transform.localScale.x) / (Mathf.Pow(ship.transform.position.x - planetsList[i].transform.position.x, 2) + Mathf.Pow(ship.transform.position.z - planetsList[i].transform.position.z, 2));
			shipAcceleration.z += (float)0.006 * (shipMass * planetsList[i].transform.localScale.x) / (Mathf.Pow(ship.transform.position.x - planetsList[i].transform.position.x, 2) + Mathf.Pow(ship.transform.position.z - planetsList[i].transform.position.z, 2));
		
			Debug.Log("Ship X: " + ship.transform.position.x);
			Debug.Log("Planet X: " + planetsList[i].transform.position.x);

			Debug.Log("Ship Z: " + ship.transform.position.z);
			Debug.Log("Planet Z: " + planetsList[i].transform.position.z);

			Debug.Log("Delta Distance: " + Mathf.Sqrt(Mathf.Pow(ship.transform.position.x - planetsList[i].transform.position.x, 2) + Mathf.Pow(ship.transform.position.z - planetsList[i].transform.position.z, 2)));

		}

		//Recalculate acceleration based on velocity
		shipVelocity.x += shipAcceleration.x;
		shipVelocity.z += shipAcceleration.z;

		shipAccelerationOld = shipAcceleration;
		*/




		shipVelocity.x = 0;
		shipVelocity.z = 0;

		shipAcceleration.x = 0;
		shipAcceleration.z = 0;

		for (int i = 0; i < planetsList.Count; i++) {
		
			//Calculate force exterted
			float force;
			force = (float)0.0006 * shipMass * planetsList[i].transform.localScale.x * 2 / (Mathf.Pow(ship.transform.position.x - planetsList[i].transform.position.x, 2) + Mathf.Pow(ship.transform.position.z - planetsList[i].transform.position.z, 2));
		
			Debug.Log(force);

			//Calculate direction of force
			Vector3 heading = planetsList[i].transform.position - ship.transform.position;
			Debug.Log(heading);

			//shipVelocity += heading * force;
			shipAcceleration.x += heading.x * force * simSpeed;
			shipAcceleration.z += heading.z * force * simSpeed;

			Debug.Log(shipVelocity);
		}


		shipVelocity += shipAcceleration;
		shipVelocity += shipAccelerationOld;



		ship.transform.Translate (shipVelocity);
	}


	void OnDrawGizmos() {

		Gizmos.color = new Color (1, 1, 1, 1);
		Gizmos.DrawCube(ship.transform.position, new Vector3 (1, 1, 1));

	}
}
