using UnityEngine;
using System.Collections;

public class GravityField: MonoBehaviour {
	public Planet parent;
	public float gravFieldSize;
	public GameObject field;
	public Color original;
	void Start (){
		/*this.planet = p;
		field = (GameObject)Instantiate (GameObject.CreatePrimitive(PrimitiveType.Cylinder));
		field.transform.position = p.transform.position;
		field.transform.position -= new Vector3 (0, 15F, 0);
		field.transform.localScale = new Vector3 (p.gravFieldSize, 1F, p.gravFieldSize);*/
		original = GetComponent<Renderer> ().material.color;
	}

	void Update (){

	}

	public void SetValues (Planet planet, float fieldSize){
		parent = planet;
		gravFieldSize = fieldSize;
	}

	void OnMouseDown(){
		parent.Selected ();
		Selected ();
	}

	public void Selected(){
		if (parent.isSelected) {
			Color c = original;
			c.g = 0;
			c.b = 0;
			GetComponent<Renderer> ().material.color = c;
		}
		else {
			GetComponent<Renderer> ().material.color = original;
		}
	}

	public void changeSize(bool isIncreasing){
		if (isIncreasing)
			field.transform.localScale += new Vector3(0.1F,0,0.1F);
		else
			field.transform.localScale -= new Vector3(0.1F,0,0.1F);
	}

}
