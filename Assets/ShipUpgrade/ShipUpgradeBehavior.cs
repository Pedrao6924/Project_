using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUpgradeBehavior : MonoBehaviour {


	Rigidbody rb;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(0,0,-4f);
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
