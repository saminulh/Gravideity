using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	public GameObject sizeChangeUI;

	public float size, gravFieldSize;
	public bool isSelected, increasing, decreasing;
	public GameObject gravField;
	public GravityField field;
	// Use this for initialization
	void Start () {
		Debug.Log ("HI");
		size = 10;
		gravFieldSize = size + 3;
		transform.localScale = new Vector3(size,size,size);
		gravField = (GameObject)Instantiate (GameObject.CreatePrimitive(PrimitiveType.Sphere));
		gravField.transform.position = transform.position;
		gravField.transform.localScale = new Vector3 (gravFieldSize, gravFieldSize, gravFieldSize);
		gravField.GetComponent<Renderer> ().sharedMaterial = (Material)Resources.Load("Materials/Translucent", typeof(Material));
		field = gravField.AddComponent<GravityField> ();
		field.SetValues (this, gravFieldSize);
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
		field.Selected ();
	}

	public void Selected (){
		isSelected = !isSelected;
		if (isSelected) {
			GetComponent<Renderer> ().material.color = Color.green;
			sizeChangeUI.SetActive (true);
		}
		else {
			GetComponent<Renderer> ().material.color = Color.blue;
			sizeChangeUI.SetActive (false);
		}
	}

	void changeSize(bool isIncreasing){
		if (isIncreasing)
			gravField.transform.localScale += new Vector3(0.1F,0.1F,0.1F);
		else
			gravField.transform.localScale -= new Vector3(0.1F,0.1F,0.1F);
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
