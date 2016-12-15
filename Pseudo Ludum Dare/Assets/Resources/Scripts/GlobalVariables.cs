using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVariables : MonoBehaviour {

	public static int gameState = 1;

	public static int numSelected;

	public static bool isIncreaseSelected, isDecreaseSelected;

	// Use this for initialization
	void Start () {
		numSelected = 0;
		isIncreaseSelected = false;
		isDecreaseSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void increaseHit(){
		isIncreaseSelected = !isIncreaseSelected;
	}

	void decreaseHit(){
		isDecreaseSelected = !isDecreaseSelected;
	}
}
