using UnityEngine;
using System.Collections;
using System.IO;

public class ShipController : MonoBehaviour {

	public float speedZ;
	private Vector3 movement;

	private string scoreFilePath;

	// Use this for initialization
	void Start () {
		scoreFilePath = Application.persistentDataPath + "/highscores.txt";
	}
	
	// Update is called once per frame
	void Update () {
		movement = Vector3.zero;


		if (transform.position.x >= -10 && transform.position.x <= 10) 
		{
			movement.x = (float)0.5 * Input.acceleration.x;
		}
		else if (transform.position.x > 10) 
		{
			movement.x = (float)-0.3;
		}
		else if (transform.position.x < -10) 
		{
			movement.x = (float)0.3;
		}

		/*if (transform.position.x > 10 || transform.position.x < -10) 
		{
			movement.x = 0;
		}*/


		if (transform.position.y >= 0.4 && transform.position.y <= 8) 
		{
			/*if ((transform.position.y < 1 && (transform.position.y - Input.acceleration.z) >= 0.41) || 
			    (transform.position.y > 7 && (transform.position.y - Input.acceleration.z) <= 7.9))*/
			movement.y = -Input.acceleration.z * (float)0.5;
		} 
		else if (transform.position.y < 0.4) 
		{
			movement.y = (float)0.3;
		} 
		else if (transform.position.y > 8) 
		{
			movement.y = (float)-0.3;
		}
		
		/*if (transform.position.y > 8 || transform.position.y < 0.4) 
		{
			movement.y = 0;
		}*/

		if (GlobalVariables.isPlaying == true) {
			movement.z = speedZ;
		}

		transform.Translate (movement);
	}

	void OnCollisionEnter() {

		Debug.Log ("Hit something!");
		GlobalVariables.isDead = true;


		StreamWriter write = new StreamWriter(scoreFilePath);
		
		Debug.Log ("Saving...");
		write.WriteLine ("Test!");
		write.WriteLine (GlobalVariables.score);
		write.Close ();
		Debug.Log ("Saved Highscore!");
	}

}
