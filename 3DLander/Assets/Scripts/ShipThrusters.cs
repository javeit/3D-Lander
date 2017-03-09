using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipThrusters : MonoBehaviour {
	
	public float maxThrusterPower;       //maximum force applied by the thruster
	public float thrusterPowerIncrement; //controls how quickly the thruster reaches full thrust
	public float initialForce;           //the initial force, in the positive x direction applied to the ship
	public float thrusterDelay;          //the number of frames until the thruster kicks in at the start of the game
	public float fuelLimit;              //the amount of fuel the ship can use, set to -1 to disable
	public float fuelUseRate;
	public float fuelLeft;

	private Rigidbody ship;
	private float thrusterPower = 0;

	void Start () {
		ship = GetComponent<Rigidbody> ();  //finds the ship's rigidbody component
		ship.AddForce (initialForce, 0, 0); //adds initial force defined earlier
		fuelLeft = fuelLimit;
	}

	void FixedUpdate () {
		if (fuelLeft > 0) {
			if (thrusterDelay <= 0) {
				if (Input.GetButton ("Jump")) {
					thrusterPower += thrusterPowerIncrement; //increments the thruster power as long as the space bar is pressed;

					if (thrusterPower > maxThrusterPower)
						thrusterPower = maxThrusterPower;
				
					ship.AddForce (transform.up * thrusterPower);

					fuelLeft -= fuelUseRate * Time.deltaTime;
				} else {
					thrusterPower -= thrusterPowerIncrement; //decrements the thruster power as long as the space bar isn't pressed;

					if (thrusterPower < 0)
						thrusterPower = 0;
				}
			} else {
				thrusterDelay--;
			}
		} else {
			noFuelText.SetActive (true);
		}
	}
}
