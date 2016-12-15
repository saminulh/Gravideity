﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject gameControllerObject;

	public GameObject cameraObj;
	public GameObject ship;

	// Use this for initialization
	void Start () {

	}
	
	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
	
	
	void Update()
	{
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			//transform.Translate(-touchDeltaPosition.x * 5F, -touchDeltaPosition.y * 5F, 0);
			if (GetComponent<Camera>().transform.position.x - (touchDeltaPosition.x * 5) > - 700 && GetComponent<Camera>().transform.position.x - (touchDeltaPosition.x * 5) < 700){
				GetComponent<Camera>().transform.position -= new Vector3(touchDeltaPosition.x * 5F, 0, 0);
			}
			if (GetComponent<Camera>().transform.position.z - (touchDeltaPosition.y * 5) > -700 && GetComponent<Camera>().transform.position.z - (touchDeltaPosition.y * 5) < 700){
				GetComponent<Camera>().transform.position -= new Vector3(0, 0, touchDeltaPosition.y * 5F);
			}
		}

		// If there are two touches on the device...
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);
			
			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
			
			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
			
			// If the camera is orthographic...
			if (GetComponent<Camera>().orthographic)
			{
				// ... change the orthographic size based on the change in distance between the touches.
				GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
				
				// Make sure the orthographic size never drops below zero.
				GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
			}
			else
			{
				// Otherwise change the field of view based on the change in distance between the touches.
				GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
				
				// Clamp the field of view to make sure it's between 0 and 180.
				GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 25f, 100f);
			}
		}
	}
}
