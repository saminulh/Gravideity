using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public Transform Ship;
	public Text scoreText;

	public GameObject BasicObstacle;
	public GameObject BasicObstacle2;
	
	public float minZ;
	public float maxZ;

	public float spawnInterval;
	private float spawnTimer;

	public static List<GameObject> obstaclesList = new List<GameObject>();


	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		GlobalVariables.isDead = false;
		//GlobalVariables.isPlaying = true;
	}

	// Update is called once per frame
	void Update () {

		if (GlobalVariables.isPlaying == true) {
		//Spawn blocks
		spawnTimer += Time.deltaTime;
		if (spawnTimer >= spawnInterval)
		{
			spawnTimer -= spawnInterval;

			float spawnedObstacle;

			spawnedObstacle = Random.Range(0, 10);

			//Spawn an obstacle
			if (spawnedObstacle <1)
			{
				GameObject obstacle2 = (GameObject) Instantiate (BasicObstacle2, new Vector3 (Random.Range(-11, 11), Random.Range(0, 9), Ship.position.z + Random.Range(minZ, maxZ)), Quaternion.identity);
				obstaclesList.Add(obstacle2);
			}
			else 
			{
				GameObject obstacle =  (GameObject) Instantiate (BasicObstacle, new Vector3 (Random.Range(-11, 11), Random.Range(0, 9), Ship.position.z + Random.Range(minZ, maxZ)), Quaternion.identity);
				obstaclesList.Add(obstacle);
			}
		}

		//Clear unneeded blocks
		for (int i = 0; i < obstaclesList.Count; i++) 
		{
			if ((obstaclesList[i].transform.position.z < Ship.position.z - 1))
			{
				Destroy(obstaclesList[i]);
				obstaclesList.Remove(obstaclesList[i]);
			}
		}

		if (Ship.position.z < 1) {
			for (int i = 0; i < obstaclesList.Count; i++) 
			{
				Destroy(obstaclesList[i]);
				obstaclesList.Remove(obstaclesList[i]);
			}
		}

		//Handle score
		GlobalVariables.score = (int)(Ship.position.z / 5);
		scoreText.text = "Score: " + GlobalVariables.score.ToString();
		}
	}
}