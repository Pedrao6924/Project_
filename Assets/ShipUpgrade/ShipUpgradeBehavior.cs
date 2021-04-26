using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUpgradeBehavior : MonoBehaviour {

	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(0,0,-4f);
	}
	
}
