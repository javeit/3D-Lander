using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBob : MonoBehaviour {
	public float bobAmount = .25f;
	public float speed = 2.0f;
	public float xLocation;
	public float zLocation;
	public float startPos;

	void start() {
		startPos = transform.localPosition.y;
	}

	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3 (xLocation, startPos + bobAmount * (1 + Mathf.Sin (Time.time)), zLocation);
		transform.LookAt (Camera.main.transform);
		transform.Rotate (0, -90, 0);
	}
}
