//Will Dudenhoeffer
//CS 4173 Group Project 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrashLanding : MonoBehaviour {
	//public bools reporting landing state
	public bool goodLanding = false;
	public bool badLanding = false;
	bool hasExploded = false;

	//Initialize GameObjects
	Rigidbody EyeRigidBody;
	GameObject ShipL;
	GameObject ShipR;
	GameObject ShipF;
	GameObject Cockpit;
	GameObject Eye;
	GameObject ShipRC;
	GameObject ShipLC;
	public ParticleSystem Boom;
	GameObject Ship;
	GameObject Pads;

	// Use this for initialization
	void Awake () {
		//find all needed gameObjects
		Ship = GameObject.Find("Ship");
		ShipL = GameObject.Find("SaucerL");
		ShipR = GameObject.Find("SaucerR");
		ShipF = GameObject.Find("SaucerF");
		Cockpit = GameObject.Find("Cockpit");
		Eye = GameObject.Find("EyeBall");
		ShipRC = GameObject.Find ("SaucerR/Sphere");
		ShipLC = GameObject.Find ("SaucerL/Sphere");
		Pads = GameObject.Find ("PadArray");
 	}

	
	// Do things on Collision
	void OnCollisionEnter (Collision Collider) { //Crash and Burn
		if (Collider.gameObject.name == "Terrain") {
			//print ("Boom.");
			badLanding = true;
			//Break Cockpit and Legs, as well as ship 'core'
			Destroy (Cockpit);
			Destroy (ShipF);
			//Enable Physics on Ship halves and Eye
			Rigidbody ShipLRigidBody = ShipL.AddComponent<Rigidbody>();
			Rigidbody ShipRRigidBody = ShipR.AddComponent<Rigidbody>();
			EyeRigidBody = Eye.AddComponent<Rigidbody>();
			//EXPLOSIONS
			if (!hasExploded) {
				Boom.Play ();
				hasExploded = true;
			}
			//Stop EyeBob
			Object EyeScript = Eye.GetComponent("EyeBob");
			Destroy (EyeScript);
			//shoot eye up
			EyeRigidBody = Eye.GetComponent<Rigidbody>();
			EyeRigidBody.AddForce (0, 100, 0);
			//Pop Eye
			//bloodSpatter
			//Fade out color and transparency of Ship Bits
			iTween.FadeTo(ShipRC, 0.0f, 1.0f);
			iTween.FadeTo(ShipLC, 0.0f, 1.0f);
		
		} else if (Collider.gameObject.name == "Pad0" ||
			Collider.gameObject.name == "Pad1" ||
			Collider.gameObject.name == "Pad2" ||
			Collider.gameObject.name == "Pad3" ||
			Collider.gameObject.name == "Pad4" ||
			Collider.gameObject.name == "Pad5" ||
			Collider.gameObject.name == "Pad6") {
			//print ("Yay.");
			goodLanding = true;
		}
	}

	void destroy() {
		Destroy (gameObject);
	}
}
