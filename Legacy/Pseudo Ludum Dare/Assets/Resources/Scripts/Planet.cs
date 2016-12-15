﻿using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	public GameObject planetGUI;

	public float size, gravFieldSize;
	public bool isSelected, increasing, decreasing;
	const float UPPER_BOUND = 200, LOWER_BOUND = 5;

	public static int numSelected;

	// Use this for initialization
	void Start () {
		size = 10;
		transform.localScale = new Vector3(size,size,size);

		GetComponent<Renderer>().material.color = Color.blue;
		increasing = false;
		decreasing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (increasing) {
			changeSize(true);
		}
		if (decreasing) {
			changeSize(false);
		}
	}

	void OnMouseDown(){
		Selected ();
	}

	public void Selected (){
		isSelected = !isSelected;
		if (isSelected) {
			GetComponent<Renderer> ().material.color = Color.green;
			planetGUI.SetActive (true);

			numSelected ++;
		} 
		else {
			GetComponent<Renderer> ().material.color = Color.blue;
			numSelected --;

			if (numSelected <= 0)
				planetGUI.SetActive(false);
		}
	}

	void changeSize(bool isIncreasing){
		if (isIncreasing) {
			size += 0.1F;
		}
		else {
			size -= 0.1F;
		}
		size = Mathf.Max (Mathf.Min (size, UPPER_BOUND), LOWER_BOUND);
		transform.localScale = new Vector3 (size, size, size);
	}

	void upClick(){
		if (isSelected) {
			increasing = !increasing;
		}
	}
	void downClick(){
		if (isSelected) {
			decreasing = !decreasing;
		}
	}
}
