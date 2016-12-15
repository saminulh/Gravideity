using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	public GameObject planet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		planet.transform.rotation = Quaternion.LookRotation(new Vector3(0, 20 * Time.realtimeSinceStartup, 0));
	}
}
