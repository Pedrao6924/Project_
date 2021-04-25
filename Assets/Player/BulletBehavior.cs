using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	public GameObject ship;

	void Start () {

		GetComponent<Rigidbody>().velocity = new Vector3(0,0,5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
